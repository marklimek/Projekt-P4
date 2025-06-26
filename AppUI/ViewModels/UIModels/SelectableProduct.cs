using ProjektP4.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppUI.ViewModels.UIModels
{

    public class SelectableProduct : Product
    {
        public bool IsSelected { get; set; }

        public SelectableProduct(Product product)
        : base(product.Name, product.Price, product.Quantity, product.Category)
        {
            Id = product.Id;
        }
    }

}
