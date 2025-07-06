using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppUI.ViewModels.UIModels
{

    public class ProductCategory
    {
        public string CategoryName { get; set; }
        public string ProductType { get; set; } // "FoodProduct" lub "NonFoodProduct"

        public override string ToString() => CategoryName;
    }

}
