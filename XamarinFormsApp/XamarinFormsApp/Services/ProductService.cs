using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Services
{
    internal class ProductService
    {
        public HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ProductResponse> GetProductsAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _httpClient.GetAsync(Constants.ProductsEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ProductResponse>(responseString);
                }
                else
                {
                    //Manerjo de exccepciones
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Token no válido, probablemente sesión expirada, redirige al inicio de sesión
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Recurso no encontrado
                    }
                    else
                    {
                        // Otro tipo de error
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales (por ejemplo, falta de conexión a Internet)
                return null;
            }
        }


    }
}
