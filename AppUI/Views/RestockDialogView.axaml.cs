using Avalonia.Controls;
using Avalonia.Markup.Xaml; 

namespace ProjektP4.AppUI.Views
{
    public partial class RestockDialogView : Window 
    {
        public RestockDialogView()
        {
            InitializeComponent(); 
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}