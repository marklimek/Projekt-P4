using Models;
using Services;
using System;
using System.Collections.ObjectModel;
using Test;

namespace Projekt_P4.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Products { get; } = new();
        public MainWindowViewModel() {

            TestData.AddSampleProduct(); // Dodaj testowy produkt
            LoadProducts();              // Załaduj produkty z bazy
            Console.WriteLine($"Liczba produktów: {Products.Count}");

        }
        public void LoadProducts()
        {
            using var service = new InventoryService();
            var items = service.GetAllProducts();
            Products.Clear();
            foreach (var item in items) 
                Products.Add(item);
        }
        public string Greeting { get; } = "Welcome to Avalonia!";
    }
}
