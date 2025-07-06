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
using System.Xml.Linq;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class ProductEditViewModel : ViewModelBase
    {
        private Product _originalProduct;
        private Action<ViewModelBase> _navigate;
        public ProductEditViewModel(Product product, Action<ViewModelBase> navigate)
        {
            _originalProduct = product;
            _navigate = navigate;
            Categories = ProductCategoryProvider.GetDefaultCategories();

            // Wypełnij dane z istniejącego produktu
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            SelectedCategory = Categories.FirstOrDefault(c => c.CategoryName == product.Category);

            if (product is FoodProduct food)
                ExpirationDate = food.ExpirationDate;
            else if (product is NonFoodProduct nonFood)
                WarrantyPeriod = nonFood.WarrantyPeriod;
        }

        public ObservableCollection<ProductCategory> Categories { get; }

        [ObservableProperty] private string name;
        [ObservableProperty] private double price;
        [ObservableProperty] private int quantity;
        [ObservableProperty] private ProductCategory selectedCategory;
        [ObservableProperty] private int warrantyPeriod;
        [ObservableProperty] private DateTimeOffset? expirationDate;

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

            Product updatedProduct = SelectedCategory.ProductType switch
            {
                "FoodProduct" => new FoodProduct(Name, Price, Quantity, SelectedCategory.CategoryName, ExpirationDate?.DateTime ?? DateTime.Now),
                "NonFoodProduct" => new NonFoodProduct(Name, Price, Quantity, SelectedCategory.CategoryName, WarrantyPeriod),
                _ => throw new InvalidOperationException("Nieznany typ produktu")
            };

            updatedProduct.Id = _originalProduct.Id;
            updatedProduct.AddedDate = _originalProduct.AddedDate;

            service.UpdateProduct(updatedProduct);
            _navigate(new ProductsPageViewModel(_navigate));
        }

        [RelayCommand]
        private void Cancel()
        {
            _navigate(new ProductsPageViewModel(_navigate));
        }
    }
}
