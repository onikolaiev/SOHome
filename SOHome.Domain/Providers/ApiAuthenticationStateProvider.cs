using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using SOHome.Common.DataModels;
using SOHome.Domain.Models;
using SOHome.Domain.Services;

using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace SOHome.Domain.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;

        public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await localStorage.GetItemAsStringAsync("authToken");
            if (string.IsNullOrEmpty(savedToken))
            {
                var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymousUser);
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
            var claims = ParseClaimsFromJwt(savedToken);
            var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
            var authTask = Task.FromResult(authState);
            NotifyAuthenticationStateChanged(authTask);
            return authState;
        }

        public void MarkUserAuthenticated(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var claimIdentity = new ClaimsIdentity(claims, "apiAuth");
            var authenticatedUser = new ClaimsPrincipal(claimIdentity);

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));

            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            foreach (var keyValue in keyValuePairs)
            {
                var valor = keyValue.Value.ToString();
                var chave = keyValue.Key;
                if (chave == "unique_name")
                    chave = ClaimTypes.Name;
                else if (chave == "role")
                    chave = ClaimTypes.Role;

                keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
                if (roles != null)
                {
                    if (roles.ToString().Trim().StartsWith("["))
                    {
                        var parseRoles = JsonSerializer.Deserialize<List<string>>(roles.ToString());
                        parseRoles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
                    }
                    else
                        claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }
                Console.WriteLine($"Chave: {keyValue.Key} - Valor: {valor}");
                claims.Add(new Claim(chave, valor));
            }

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
                default:
                    break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}
