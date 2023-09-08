using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.ViewModels;

namespace XamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel();
        }

        private void OnImageTapped(object sender, EventArgs e)
        {
            if (BindingContext is ProductViewModel viewModel)
            {
                if (viewModel.AddToCartCommand.CanExecute(null))
                {
                    viewModel.AddToCartCommand.Execute(null);
                }
            }
        }
    }
}