using System.ComponentModel.DataAnnotations;

namespace ProjektP4.AppLogic.Models
{

    public abstract class Product 
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public virtual string AdditionalInfo => string.Empty;
        protected Product() { }
        protected Product(string name, double price, int quantity, string category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }
    }

}