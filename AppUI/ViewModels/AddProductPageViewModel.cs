using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class AddProductPageViewModel : ViewModelBase
    {

        private readonly Action<ViewModelBase> _navigate;

        public AddProductPageViewModel(Action<ViewModelBase> navigate)
        {
            _navigate = navigate;
        }

        [ObservableProperty] private string name = string.Empty;
        [ObservableProperty] private string category = string.Empty;
        [ObservableProperty] private double price;
        [ObservableProperty] private int quantity;
        [ObservableProperty] private string selectedProductType = "-- wybierz typ --";
        [ObservableProperty] private int warrantyPeriod;
        [ObservableProperty] private DateTimeOffset? expirationDate = DateTimeOffset.Now;

        public List<string> ProductTypes { get; } = new()
        {
            "-- wybierz typ --",
            "FoodProduct",
            "NonFoodProduct"
        };

        public bool IsFood => SelectedProductType == "FoodProduct";
        public bool IsNonFood => SelectedProductType == "NonFoodProduct";
        public bool IsProductTypeSelected => IsFood || IsNonFood;

        partial void OnSelectedProductTypeChanged(string value)
        {
            OnPropertyChanged(nameof(IsFood));
            OnPropertyChanged(nameof(IsNonFood));
            OnPropertyChanged(nameof(IsProductTypeSelected));
        }



        [RelayCommand]
        private void Save()
        {
            using var service = new InventoryService();
            Product product = SelectedProductType switch
            {
                "FoodProduct" => new FoodProduct(Name, Price, Quantity, Category, ExpirationDate?.DateTime ?? DateTime.Now),
                "NonFoodProduct" => new NonFoodProduct(Name, Price, Quantity, Category, WarrantyPeriod),
                _ => throw new InvalidOperationException("Nieznany typ produktu")
            };
            service.AddProduct(product);
            _navigate(new ProductsPageViewModel(_navigate));
        }

        [RelayCommand]
        private void Cancel()
        {
            _navigate(new ProductsPageViewModel(_navigate)); // wróć bez zapisu
        }


    }
}
