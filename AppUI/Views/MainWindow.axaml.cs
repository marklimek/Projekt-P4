using Avalonia.Controls;
using ProjektP4.ViewModels;

namespace ProjektP4.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}