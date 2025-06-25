using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppUI.ViewModels;
using ProjektP4.AppLogic.Services;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using ProjektP4.AppLogic.Test;

namespace ProjektP4.ViewModels;

    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isPaneOpen = false;

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();
    
        [ObservableProperty]
        private ListItemTemplate? _selectedListItem;

        partial void OnSelectedListItemChanged(ListItemTemplate? value){   
            if (value is null)return;
            var instance = Activator.CreateInstance(value.ModelType);
            if (value is null) return;
            CurrentPage = (ViewModelBase)instance;
        }
        public ObservableCollection<ListItemTemplate> Items { get; } = new()
        {
            new ListItemTemplate(typeof(HomePageViewModel), "Home"),
            new ListItemTemplate(typeof(ProductsPageViewModel), "Products"),
            new ListItemTemplate(typeof(AddProductPageViewModel), "AddProduct"),
            new ListItemTemplate(typeof(RemoveProductPageViewModel), "Delete")
        };

        [RelayCommand]
        private void TriggerPane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
   
    public MainWindowViewModel()
    {

    }

}
    public class ListItemTemplate
    {
        public ListItemTemplate(Type type, string iconKey)
        {
            ModelType = type;
            Label = Regex.Replace(type.Name.Replace("PageViewModel", ""), "(\\B[A-Z])", " $1");

        Application.Current!.TryFindResource(iconKey, out var res);
        ListItemIcon = (StreamGeometry)res!;
        }
        public string Label { get;}
        public Type ModelType { get;}
        public StreamGeometry ListItemIcon { get;}
    }

