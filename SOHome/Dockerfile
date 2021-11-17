#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM ubuntu:latest as base
# Configure locale
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
# Setup NodeJs
RUN apt-get update && apt-get install curl wget apt-transport-https -yq
RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
RUN apt-get install -y nodejs
# Setup Yarn
RUN npm install --global yarn
# Setup vars
WORKDIR /app
EXPOSE 80
# Setup ASPNet Core 6.0
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb
RUN apt-get update && apt-get install aspnetcore-runtime-6.0 -yq

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SOHome/SOHome.csproj", "SOHome/"]
COPY ["SOHome.Domain/SOHome.Domain.csproj", "SOHome.Domain/"]
COPY ["SOHome.Common/SOHome.Common.csproj", "SOHome.Common/"]
RUN dotnet restore "SOHome/SOHome.csproj"
COPY . .
WORKDIR "/src/SOHome"
RUN dotnet build "SOHome.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SOHome.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SOHome.dll"]