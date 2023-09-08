using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Interfaces;
using XamarinFormsApp.Services;
using XamarinFormsApp.Views;

namespace XamarinFormsApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAuthenticationService, AuthenticationService>();
            MainPage = new NavigationPage(new AuthenticationPage(new AuthenticationService()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
