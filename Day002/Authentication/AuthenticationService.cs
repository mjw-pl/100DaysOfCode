using System.Net;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Day002.Models;

namespace Day002.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authProvider;
        private readonly ILocalStorageService localStorageService;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorageService, AuthenticationStateProvider authProvider)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.authProvider = authProvider;
        }

        public async Task<bool> Login(DtoUserLoginRequest request)
        {
                var bodyContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var authResult = await httpClient.PostAsync("http://localhost:80/api/Auth", bodyContent);

                if (authResult.IsSuccessStatusCode)
                {
                    var authContent = await authResult.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<DtoUserLoginResponse>(authContent);
                    await localStorageService.SetItemAsync("token", result.token);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.token);

                    await ((CustomAuthenticationStateProvider)authProvider).NotifyUserAuthentication(result.token);

                    Thread.Sleep(2000); // For better local/network experience
                    
                    return true;
                }
                
                if (authResult.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                
                return false;
        }

        public async Task<bool> Logout()
        {
            await localStorageService.RemoveItemAsync("token");
            await ((CustomAuthenticationStateProvider)authProvider).NotifyUserLogout();

            return true;
        }
    }
}
