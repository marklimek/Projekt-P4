using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Helpers;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using ProjektP4.AppUI.ViewModels.UIModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Categories = ProductCategoryProvider.GetDefaultCategories();
        }

        public ObservableCollection<ProductCategory> Categories { get; }

        [ObservableProperty] private string name = string.Empty;
        [ObservableProperty] private double price;
        [ObservableProperty] private int quantity;
        [ObservableProperty] private ProductCategory selectedCategory;
        [ObservableProperty] private int warrantyPeriod;
        [ObservableProperty] private DateTimeOffset? expirationDate = DateTimeOffset.Now;

        public bool IsFood => SelectedCategory?.ProductType == "FoodProduct";
        public bool IsNonFood => SelectedCategory?.ProductType == "NonFoodProduct";
        public bool IsCategorySelected => SelectedCategory != null;

        partial void OnSelectedCategoryChanged(ProductCategory value)
        {
            OnPropertyChanged(nameof(IsFood));
            OnPropertyChanged(nameof(IsNonFood));
            OnPropertyChanged(nameof(IsCategorySelected));
        }

        [RelayCommand]
        private void Save()
        {
            if (SelectedCategory is null)
                return;

            using var service = new InventoryService();

            Product product = SelectedCategory.ProductType switch
            {
                "FoodProduct" => new FoodProduct(Name, Price, Quantity, SelectedCategory.CategoryName, ExpirationDate?.DateTime ?? DateTime.Now),
                "NonFoodProduct" => new NonFoodProduct(Name, Price, Quantity, SelectedCategory.CategoryName, WarrantyPeriod),
                _ => throw new InvalidOperationException("Nieznany typ produktu")
            };

            service.AddProduct(product);
            _navigate(new ProductsPageViewModel(_navigate));
        }

        [RelayCommand]
        private void Cancel()
        {
            _navigate(new ProductsPageViewModel(_navigate));
        }

        [RelayCommand]
        private void AddCategory()
        {
            // Tu możesz otworzyć popup lub nową stronę do dodania kategorii
            // np. _navigate(new AddCategoryPageViewModel(_navigate));
        }
    }
}
