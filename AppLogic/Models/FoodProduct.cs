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
        public override string AdditionalInfo => $"Data ważności: {ExpirationDate:dd.MM.yyyy}";
        public bool IsExpiringSoon => ExpirationDate <= DateTime.Now.AddDays(7);

        public FoodProduct() { }
        public FoodProduct(string name, double price, int quantity, string category, DateTime expirationDate)
        : base(name, price, quantity, category)
        {
            ExpirationDate = expirationDate;
        }
    }
}
