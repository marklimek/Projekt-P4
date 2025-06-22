using System.ComponentModel.DataAnnotations;

namespace Models
{

    public abstract class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

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