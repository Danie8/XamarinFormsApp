using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsApp.Models;
using XamarinFormsApp.Services;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System;

namespace XamarinFormsApp.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Product> _products;

        public ICommand AddToCartCommand { get; }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        private readonly ProductService _productProvider;

        public ICommand LoadProductsCommand { get; set; }

        public ProductViewModel()
        {
            _productProvider = new ProductService();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            AddToCartCommand = new Command(async () => await OnAddToCartAsync());

            //ejecuta el comando para cargar los productos
            LoadProductsCommand.Execute(null);
        }

        private async Task ExecuteLoadProductsCommand()
        {
            try
            {
                string token = await SecureStorage.GetAsync("auth_token");
                if (!string.IsNullOrEmpty(token))
                {
                    ProductResponse productResponse = await _productProvider.GetProductsAsync(token);
                    if (productResponse != null)
                    {
                        Products = new ObservableCollection<Product>(productResponse.Products);
                    }
                    else
                    {
                        //respuesta nula
                    }
                }
                else
                {
                    // token no disponible
                }
            }
            catch (Exception ex)
            {
                // excepciones generales
            }
        }


        private async Task OnAddToCartAsync()
        {
            await Application.Current.MainPage.DisplayAlert("Éxito", "Has agregado este objeto a tu carrito", "OK");

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
