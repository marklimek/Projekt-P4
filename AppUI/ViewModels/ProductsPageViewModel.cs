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
using System.Windows.Input;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class ProductsPageViewModel : ViewModelBase
    {
        public ObservableCollection<SelectableProduct> Products { get; } = new();

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
                Products.Add(new SelectableProduct(item));
        }

        [RelayCommand]
        private void ShowDetails(SelectableProduct product) { 
        //TODO
        }
        [RelayCommand]
        private void Edit(SelectableProduct product) { 
        //TODO
        }
        //Remove rows by clicking icon in action column
        [RelayCommand]
        private void Delete(SelectableProduct product) { 
            if(product is null)
                 return; 
            using var service = new InventoryService();
            service.RemoveProduct(product);
            Products.Remove(product);
        }
        public ICommand DeleteSelectedCommand => new RelayCommand(DeleteSelected);

        public void DeleteSelected()
        {
            var selected = Products.Where(p => p.IsSelected).ToList();
            foreach (var product in selected)
            {
                Products.Remove(product);
            }
        }
    }
}