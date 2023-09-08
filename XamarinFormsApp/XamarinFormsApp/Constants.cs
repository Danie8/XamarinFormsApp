using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp
{
    public static class Constants
    {
        // Almacenar el dominio base del servicio
        public static readonly string BaseDomain = "https://dummyjson.com";

        // Endpoint para la autenticación
        public static readonly string LoginEndpoint = $"{BaseDomain}/auth/login";

        // Nuevo endpoint para obtener productos
        public static readonly string ProductsEndpoint = $"{BaseDomain}/auth/products";
    }
}
