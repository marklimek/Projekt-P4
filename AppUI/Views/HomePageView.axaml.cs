
using Avalonia.Controls;
using Avalonia.Interactivity;
using ProjektP4.AppUI.ViewModels;
using ProjektP4.AppUI.ViewModels.UIModels;

namespace ProjektP4.AppUI.Views
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
            this.AttachedToVisualTree += HomePageView_AttachedToVisualTree;
        }

        private void HomePageView_AttachedToVisualTree(object? sender, Avalonia.VisualTreeAttachmentEventArgs e)
        {
            if (DataContext is HomePageViewModel viewModel)
            {
                viewModel.LoadProducts();
            }
        }

        private void OnShowDetailsClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is ProductRowViewModel productRow)
            {
                var vm = DataContext as HomePageViewModel;
                vm?.ShowDetails(productRow);
            }
        }

        private void OnRestockClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is ProductRowViewModel productRow)
            {
                var vm = DataContext as HomePageViewModel;
                vm?.Restock(productRow);
            }
        }


    }
}