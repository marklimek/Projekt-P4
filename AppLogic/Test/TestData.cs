using ProjektP4.AppLogic.Models;
using ProjektP4.AppLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppLogic.Test
{

    public class TestData
    {
        public static void AddSampleProduct()
        {
            using var service = new InventoryService();


            var food = new FoodProduct("Mleko", 3.99, 10, "Spożywcze", DateTime.Now.AddDays(7));
            var nonFood = new NonFoodProduct("Laptop", 2999.99, 5, "Elektronika", 24);

            service.AddProduct(food);
            service.AddProduct(nonFood);


        }

    }
}
