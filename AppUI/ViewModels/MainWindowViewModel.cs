using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using ProjektP4.AppLogic.Test;
using ProjektP4.AppUI.ViewModels;
using ProjektP4.AppUI.ViewModels.UIModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjektP4.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    private readonly HomePageViewModel _homePageViewModel;
    public MainWindowViewModel()
    {


        using var service = new InventoryService();
        if (!service.GetAllProducts().Any())
        {
            TestData.AddSampleProduct();
        }

        _homePageViewModel = new HomePageViewModel();
       // _homePageViewModel.LoadProducts(); 

        CurrentPage = _homePageViewModel;
        SelectedListItem = Items.FirstOrDefault(i => i.ModelType == typeof(HomePageViewModel));

    }

    [ObservableProperty]
    private bool _isPaneOpen = false;

    [ObservableProperty]
    private ViewModelBase _currentPage;

    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;

    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
        new ListItemTemplate(typeof(HomePageViewModel), "Home"),
        new ListItemTemplate(typeof(ProductsPageViewModel), "Products"),
        new ListItemTemplate(typeof(AddProductPageViewModel), "AddProduct"),
        //new ListItemTemplate(typeof(RemoveProductPageViewModel), "Delete") 
    };

    public void NavigateTo(ViewModelBase viewModel)
    {
        CurrentPage = viewModel;
    }

    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value == null) return;

        if (value.ModelType == typeof(ProductsPageViewModel))
        {
            CurrentPage = new ProductsPageViewModel(NavigateTo);
        }
        else if (value.ModelType == typeof(AddProductPageViewModel))
        {
            CurrentPage = new AddProductPageViewModel(NavigateTo);
        }
        else if (value.ModelType == typeof(HomePageViewModel))
        {
            CurrentPage = _homePageViewModel;
        }
        else if (Activator.CreateInstance(value.ModelType) is ViewModelBase vm)
        {
            CurrentPage = vm;
        }
    }



    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}


