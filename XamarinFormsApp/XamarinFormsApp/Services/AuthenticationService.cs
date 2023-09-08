using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Interfaces;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public HttpClient _httpClient;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(LoginResponse, string)> LoginAsync(LoginRequest request)
        {
            try
            {
                string json = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(Constants.LoginEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<LoginResponse>(responseString), null);
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Dictionary<string, string> errorResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                    string ok = errorResponse.ContainsKey("message") ? errorResponse["message"] : "Error desconocido";

                    return (null, ok);
                }
                else
                {
                    return (null, "Servicio no Disponible");
                }
            }
            catch (HttpRequestException e)
            {
                return (null, "Error en la conexión: " + e.Message);
            }
            catch (Exception e)
            {
                return (null, "Error desconocido: " + e.Message);
            }
        }


        public async Task<string> GetTokenAsync(LoginRequest request)
        {
            (LoginResponse loginResponse, string errorMessage) = await LoginAsync(request);

            if (loginResponse != null)
            {
                return loginResponse.Token;
            }
            else
            {
                return null;
            }
        }

    }
}
