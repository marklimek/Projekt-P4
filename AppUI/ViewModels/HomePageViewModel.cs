
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using ProjektP4.AppUI.ViewModels.Interface;
using ProjektP4.AppUI.ViewModels.UIModels;
using ProjektP4.AppUI.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class HomePageViewModel : ViewModelBase, INavigatable
    {
        private readonly Action<ViewModelBase> _navigate;

        public ObservableCollection<ProductRowViewModel> RecentlyAddedProducts { get; } = new();
        public ObservableCollection<ProductRowViewModel> LowStockProducts { get; } = new();

        public HomePageViewModel(Action<ViewModelBase> navigate)
        {
            _navigate = navigate ?? throw new ArgumentNullException(nameof(navigate));
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

            RecentlyAddedProducts.Clear();
            foreach (var product in allProducts.Take(10))
                RecentlyAddedProducts.Add(new ProductRowViewModel(product));

            LowStockProducts.Clear();
            foreach (var product in allProducts.Where(p => p.Quantity <= 5))
                LowStockProducts.Add(new ProductRowViewModel(product));
        }


        [RelayCommand]
        public async Task Restock(ProductRowViewModel? productRowViewModel)
        {
            if (productRowViewModel?.Product == null) return;

            var dialogViewModel = new RestockDialogViewModel(productRowViewModel.Product);
            var dialog = new RestockDialogView
            {
                DataContext = dialogViewModel
            };

            var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;

            dialogViewModel.CloseRequested += quantityToAdd =>
            {
                dialog.Close(quantityToAdd);
            };

            var result = await dialog.ShowDialog<int?>(mainWindow);

            if (result.HasValue && result.Value > 0)
            {
                using var service = new InventoryService();
                productRowViewModel.Product.Quantity += result.Value;
                service.UpdateProduct(productRowViewModel.Product);
                LoadProducts();
            }
        }


        [RelayCommand]
        public void ShowDetails(ProductRowViewModel? product)
        {
            if (product?.Product != null)
            {
                var detailsViewModel = new ProductDetailsViewModel(product.Product, _navigate);
                _navigate(detailsViewModel);
            }
        }
    }
}
