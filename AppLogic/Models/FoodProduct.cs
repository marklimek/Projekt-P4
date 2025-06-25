using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppLogic.Models
{

    public class FoodProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public FoodProduct() { }

        public FoodProduct(string name, double price, int quantity, string category, DateTime expirationDate)
        : base(name, price, quantity, category)
        {
            ExpirationDate = expirationDate;
        }
    }
}
