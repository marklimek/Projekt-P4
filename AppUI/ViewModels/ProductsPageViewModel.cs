using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektP4.AppLogic.Test;
using CommunityToolkit.Mvvm.Input;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class ProductsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products { get; } = new();

        public ProductsPageViewModel()
        {
           // TestData.AddSampleProduct(); // Dodaj testowy produkt
            LoadProducts();              // Załaduj produkty z bazy
        }
        public void LoadProducts()
        {
            using var service = new InventoryService();
            var items = service.GetAllProducts();
            Products.Clear();
            foreach (var item in items)
                Products.Add(item);
        }

        [RelayCommand]
        private void ShowDetails(Product product) { 
        //TODO
        }
        [RelayCommand]
        private void Edit(Product product) { 
        //TODO
        }
        [RelayCommand]
        private void Delete(Product product) { 
        Products.Remove(product);
        }
    }
}