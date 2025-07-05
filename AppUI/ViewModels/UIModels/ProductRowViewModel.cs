using ProjektP4.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppUI.ViewModels.UIModels
{

    public class ProductRowViewModel
    {
        public bool IsSelected { get; set; }
        public Product Product { get; }

        public ProductRowViewModel(Product product)
        {
            Product = product;
        }

        public int Id => Product.Id;
        public string Name => Product.Name;
        public string Category => Product.Category;
        public double Price => Product.Price;
        public int Quantity => Product.Quantity;

        public string AdditionalInfo =>
        Product is FoodProduct food ? $"Ważne do: {food.ExpirationDate:dd.MM.yyyy}" :
        Product is NonFoodProduct nonFood ? $"Gwarancja: {nonFood.WarrantyPeriod} mies." :
        string.Empty;
    }
}
