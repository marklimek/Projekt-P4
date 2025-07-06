using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using ProjektP4.AppUI.ViewModels.Interface;
using ProjektP4.AppUI.ViewModels.UIModels;
using ProjektP4.AppUI.ViewModels.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ProjektP4.AppUI.ViewModels
{
    public partial class HomePageViewModel : ViewModelBase, INavigatable
    {



        public ObservableCollection<ProductRowViewModel> RecentlyAddedProducts { get; } = new();
        public ObservableCollection<ProductRowViewModel> LowStockProducts { get; } = new();

        public ICommand RestockCommand { get; }
        public ICommand ShowDetailsCommand { get; }

        public HomePageViewModel()
        {
            RestockCommand = new RelayCommand<ProductRowViewModel>(Restock);
            ShowDetailsCommand = new RelayCommand<ProductRowViewModel>(ShowDetails);
        }
        public void OnNavigatedTo()
        {
            LoadProducts();
        }

        public void LoadProducts()
        {
            using var service = new InventoryService();
            var allProducts = service.GetAllProducts()
            .OrderByDescending(p => p.AddedDate)
            .ToList();

            Console.WriteLine("Ładowanie produktów do strony głównej...");
            Console.WriteLine("Liczba produktów: " + allProducts.Count);


            RecentlyAddedProducts.Clear();
            foreach (var product in allProducts.Take(10)) // np. 10 ostatnich
                RecentlyAddedProducts.Add(new ProductRowViewModel(product));

            LowStockProducts.Clear();
            foreach (var product in allProducts.Where(p => p.Quantity <= 5))
                LowStockProducts.Add(new ProductRowViewModel(product));
        }

        private void Restock(ProductRowViewModel product)
        {
            //product.Quantity += 10;
            using var service = new InventoryService();
            service.UpdateProduct(product.Product);
            LoadProducts();
        }

        private void ShowDetails(ProductRowViewModel product)
        {
            // Możesz tu np. otworzyć popup albo przejść do szczegółów
            //Console.WriteLine($"Szczegóły: {product.Name}, {product.AdditionalInfo}");
        }
    }
}
