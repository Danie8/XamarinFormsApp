using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsApp.Services;
using System.Threading.Tasks;
using XamarinFormsApp.Interfaces;
using Xamarin.Essentials;
using XamarinFormsApp.Views;

namespace XamarinFormsApp.ViewModels
{
    internal class AuthenticationViewModel : INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authentication;

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }

        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authentication = authenticationService;
            LoginCommand = new Command(async () => await LoginAsync());

            // Establecer valores predeterminados para no hacer engorrosas las pruebas
            Username = "kminchelle";
            Password = "0lelplR";
        }

        private async Task LoginAsync()
        {
            (Models.LoginResponse loginResponseResult, string messageResult) = await _authentication.LoginAsync(new Models.LoginRequest { Username = this.Username, Password = this.Password });

            if (loginResponseResult==null || string.IsNullOrEmpty(loginResponseResult.Token))
            {
                await Application.Current.MainPage.DisplayAlert("Error", messageResult, "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Has iniciado sesión correctamente", "OK");
                await SecureStorage.SetAsync("auth_token", loginResponseResult.Token);
                await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
