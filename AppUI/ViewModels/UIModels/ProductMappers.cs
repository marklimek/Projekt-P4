using ProjektP4.AppLogic.Models;
using ProjektP4.AppUI.ViewModels.UIModels;

namespace ProjektP4.AppUI.ViewModels.UIModels
{
    public static class ProductMappers
    {
    public static SelectableProduct ToSelectable(this Product product)
        => new(product);
    }


    
}
