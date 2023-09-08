using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Interfaces;
using XamarinFormsApp.ViewModels;

namespace XamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage(IAuthenticationService authenticationService)
        {
            InitializeComponent();
            this.BindingContext = new AuthenticationViewModel(authenticationService);


        }
    }
}