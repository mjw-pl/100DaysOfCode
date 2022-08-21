using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Day002.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;
        private AuthenticationState anonymous;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            this.anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await localStorage.GetItemAsync<string>("token");

            if (string.IsNullOrWhiteSpace(token))
            {
                return anonymous;
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt")));
        }

        public async Task<AuthenticationState> NotifyUserAuthentication(string token)
        {
            var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public async Task<AuthenticationState> NotifyUserLogout()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(anonymous));

            return anonymous;

        }
    }
}
