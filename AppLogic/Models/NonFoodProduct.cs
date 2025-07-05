using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppLogic.Models
{

    public class NonFoodProduct : Product
    {
        public int WarrantyPeriod { get; set; }
        public override string AdditionalInfo => $"Gwarancja: {WarrantyPeriod} miesięcy";
        public NonFoodProduct() { }
        public NonFoodProduct(string name, double price, int quantity, string category, int warrantyPeriod)
        : base(name, price, quantity, category)
        {
            WarrantyPeriod = warrantyPeriod;
        }
    }
}
