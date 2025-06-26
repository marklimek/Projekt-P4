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
using ProjektP4.AppUI.ViewModels.UIModels;

namespace ProjektP4.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen = false;

    [ObservableProperty]
    private ViewModelBase _currentPage = new HomePageViewModel();

    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;



    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value?.ModelType == typeof(ProductsPageViewModel))
        {
            CurrentPage = new ProductsPageViewModel(NavigateTo);
        }
        else if (value?.ModelType is not null && Activator.CreateInstance(value.ModelType) is ViewModelBase vm)
        {
            CurrentPage = vm;
        }
    }


    public ObservableCollection<ListItemTemplate> Items { get; } = new()
    {
            new ListItemTemplate(typeof(HomePageViewModel), "Home"),
            new ListItemTemplate(typeof(ProductsPageViewModel), "Products"),
            new ListItemTemplate(typeof(AddProductPageViewModel), "AddProduct"),
            new ListItemTemplate(typeof(RemoveProductPageViewModel), "Delete")

    };


    public void NavigateTo(ViewModelBase viewModel)
    {
        CurrentPage = viewModel;
    }


    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    } 
}


