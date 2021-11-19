using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using SOHome.Common;
using SOHome.Common.DataModels;
using SOHome.Common.Exceptions;
using SOHome.Common.Interfaces;
using SOHome.Domain.Providers;

using System.Net;
using System.Net.Http.Headers;

namespace SOHome.Domain.Services
{
    public class APIAuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public APIAuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<UserDto> LoginAsync(LoginModel model)
        {
            var userDto = await httpClient.PostAsync<UserDto>("api/account/login", model);
            if (userDto.StatusCode == HttpStatusCode.Unauthorized)
                throw new LoginException("Usuário ou senha inválidos!");
            else if (userDto.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(userDto.Content);

            await localStorage.SetItemAsStringAsync(AppSettings.AuthToken, userDto.Value.Token);
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAuthenticated(userDto.Value.Token);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userDto.Value.Token);
            return userDto.Value;
        }

        public async Task LogoutAsync()
        {
            await localStorage.RemoveItemAsync(AppSettings.AuthToken);
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<UserDto> RegisterAsync(RegisterModel model)
        {
            var userDto = await httpClient.PostAsync<UserDto>("api/account/register", model);
            if (userDto.StatusCode == HttpStatusCode.Unauthorized)
                throw new RegisterException(userDto.Content);
            else if (userDto.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(userDto.Content);

            await localStorage.SetItemAsStringAsync(AppSettings.AuthToken, userDto.Value.Token);
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAuthenticated(userDto.Value.Token);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userDto.Value.Token);

            return userDto.Value;
        }
    }
}
