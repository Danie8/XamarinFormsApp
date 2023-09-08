using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsApp.ViewModels;
using XamarinFormsApp.Views;

namespace XamarinFormsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AuthenticationPage");
        }
    }
}
