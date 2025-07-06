using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class ProductDetailsViewModel : ViewModelBase
    {
        private readonly Product _product;
        private readonly Action<ViewModelBase> _navigate;
        public string Name => _product.Name;
        public string Category => _product.Category;
        public double Price => _product.Price;
        public int Quantity => _product.Quantity;
        public DateTime AddedDate => _product.AddedDate;

        public bool IsFoodProduct => _product is FoodProduct;
        public bool IsNonFoodProduct => _product is NonFoodProduct;

        public DateTime? ExpirationDate => IsFoodProduct ? ((FoodProduct)_product).ExpirationDate : (DateTime?)null;
        public int? WarrantyPeriod => IsNonFoodProduct ? ((NonFoodProduct)_product).WarrantyPeriod : (int?)null;

        public string AdditionalInfo => _product.AdditionalInfo;
        public bool IsExpiringSoon => IsFoodProduct && ((FoodProduct)_product).IsExpiringSoon;
        public ProductDetailsViewModel(Product product, Action<ViewModelBase> navigate)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
            _navigate = navigate ?? throw new ArgumentNullException(nameof(navigate));
        }
        [RelayCommand]
        private void GoBack()
        {
            _navigate(new ProductsPageViewModel(_navigate));
        }
    }
}