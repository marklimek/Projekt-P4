﻿using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using ProjektP4.AppLogic.Test;
using ProjektP4.AppUI.ViewModels.UIModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektP4.AppUI.ViewModels
{
    public partial class ProductsPageViewModel : ViewModelBase
    {
        public ObservableCollection<ProductRowViewModel> Products { get; } = new();

        [ObservableProperty] private string _searchQuery;
        private List<ProductRowViewModel> _allProducts = new();
        private Action<ViewModelBase> _navigate;

        public ProductsPageViewModel(Action<ViewModelBase> navigate)
        {
            _navigate = navigate ?? throw new ArgumentNullException(nameof(navigate));
            LoadProducts();
        }

        public void LoadProducts()
        {
            using var service = new InventoryService();
            var items = service.GetAllProducts();
            _allProducts = items.Select(p => new ProductRowViewModel(p)).ToList();
            FilterProducts();
        }


        partial void OnSearchQueryChanged(string value)
        {
            FilterProducts();
        }

        private void FilterProducts()
        {
            Products.Clear();
            var filtered = string.IsNullOrWhiteSpace(SearchQuery)
            ? _allProducts
            : _allProducts.Where(p =>
            p.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
            p.Category.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var item in filtered)
                Products.Add(item);
        }



        [RelayCommand]
        private void ShowDetails(ProductRowViewModel productRow) {
            if (productRow?.Product != null)
            {
                var detailsViewModel = new ProductDetailsViewModel(productRow.Product, _navigate);
                _navigate(detailsViewModel);
            }
        }

        [RelayCommand]
        private void Edit(ProductRowViewModel product) {
            if (product?.Product != null)
            {
                var editViewModel = new ProductEditViewModel(product.Product, _navigate);
                _navigate(editViewModel);
            }
        }

        //Remove rows by clicking icon in action column
        [RelayCommand]
        private async Task DeleteAsync(ProductRowViewModel row)
        {
            if (row is null)
                return;

            var messageBox = MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.YesNo,
                ContentTitle = "Potwierdzenie",
                ContentMessage = $"Czy na pewno chcesz usunąć produkt: {row.Name}?",
                Icon = Icon.Warning
            });

            var result = await messageBox.ShowAsPopupAsync(App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null);

            if (result == ButtonResult.Yes)
            {
                using var service = new InventoryService();
                service.RemoveProduct(row.Product);
                Products.Remove(row);
            }
        }


        [RelayCommand]
        public async Task DeleteSelectedAsync()
        {
            var selected = Products.Where(p => p.IsSelected).ToList();
            if (!selected.Any())
                return;

            var messageBox = MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.YesNo,
                ContentTitle = "Potwierdzenie",
                ContentMessage = $"Czy na pewno chcesz usunąć zaznaczone produkty? Ilość: {selected.Count}",
                Icon = Icon.Warning
            });

            var result = await messageBox.ShowAsPopupAsync(App.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop ? desktop.MainWindow : null);


            if (result == ButtonResult.Yes)
            {
                using var service = new InventoryService();
                foreach (var row in selected)
                {
                    service.RemoveProduct(row.Product);
                    Products.Remove(row);
                }
            }
        }

        [RelayCommand]
        public void AddProduct() {
            _navigate(new AddProductPageViewModel(_navigate));
        }        

    }
}