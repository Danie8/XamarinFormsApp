using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Models
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
    }
}
