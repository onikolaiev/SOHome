#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM ubuntu:latest as base
RUN apt-get update 
RUN apt-get install -yq wget curl apt-transport-https tzdata gnupg2
ENV TZ=America/Sao_Paulo 
ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime 
RUN echo $TZ > /etc/timezone
RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - 
RUN rm packages-microsoft-prod.deb
RUN apt-get install -yq nodejs gcc g++ make dotnet-sdk-6.0
RUN /usr/bin/npm install -g npm
# Setup vars
WORKDIR /app
EXPOSE 5000

FROM base AS build
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