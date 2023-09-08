using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Interfaces
{
    public interface IAuthenticationService
    {
        Task<(LoginResponse, string)> LoginAsync(LoginRequest request);
        Task<string> GetTokenAsync(LoginRequest request);
    }
}
