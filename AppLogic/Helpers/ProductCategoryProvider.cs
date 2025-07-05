using ProjektP4.AppUI.ViewModels.UIModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppLogic.Helpers
{

    public static class ProductCategoryProvider
    {
        public static ObservableCollection<ProductCategory> GetDefaultCategories() => new()
 {
 new ProductCategory { CategoryName = "Nabiał", ProductType = "FoodProduct" },
 new ProductCategory { CategoryName = "Warzywa", ProductType = "FoodProduct" },
 new ProductCategory { CategoryName = "Owoce", ProductType = "FoodProduct" },
 new ProductCategory { CategoryName = "Elektronika", ProductType = "NonFoodProduct" },
 new ProductCategory { CategoryName = "Pieczywo", ProductType = "FoodProduct" },
 new ProductCategory { CategoryName = "Odzież", ProductType = "NonFoodProduct" },
 new ProductCategory { CategoryName = "AGD", ProductType = "NonFoodProduct" },
 new ProductCategory { CategoryName = "Narzędzia", ProductType = "NonFoodProduct" },
 new ProductCategory { CategoryName = "Elektronarzędzia", ProductType = "NonFoodProduct" },
 new ProductCategory { CategoryName = "Mięso", ProductType = "FoodProduct" }
 };
    }
}
