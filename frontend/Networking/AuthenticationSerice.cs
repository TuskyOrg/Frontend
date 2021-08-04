using frontend.Pages;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Net.Http;
using System;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace frontend.Networking
{

    public class AuthenticationService : IAuthenticationService
    {
        const string RegisterUrl = "http://localhost:8007/auth/register";
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
         
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient client,  ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _localStorage = localStorage;
        }
        public async Task<RegistrationReponse> Register(UserRegistration userRegistration)
        {

            var content = JsonSerializer.Serialize(userRegistration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var registrationResult = await _client.PostAsync("register", bodyContent);
            var registrationContent = await registrationResult.Content.ReadAsStringAsync();
          
            if (registrationResult.StatusCode == HttpStatusCode.Created)
            {
                RegistrationReponse result = JsonSerializer.Deserialize<RegistrationReponse>(registrationContent, _options);
                result.SuccessfulReponse = true;
                return result;
            }

            return new RegistrationReponse { SuccessfulReponse = false };

        }

         public async Task<LoginResponse> Login(string data)
        {
            var bodyContent = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

            var authResult = await _client.PostAsync("jwt/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponse>(authContent, _options);

            if (!authResult.IsSuccessStatusCode)
                return result;

            await _localStorage.SetItemAsync("authToken", result.access_token);
            await _localStorage.SetItemAsync("refreshToken", result.refresh_token);
           // ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Token);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.access_token);
            result.IsSuccessful = true;
            return result;
        }




    }
}