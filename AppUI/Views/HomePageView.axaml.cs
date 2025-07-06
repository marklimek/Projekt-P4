
using Avalonia.Controls;
using ProjektP4.AppUI.ViewModels;

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
    }
}