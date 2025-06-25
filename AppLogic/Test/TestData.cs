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

            var product = new FoodProduct(
            name: "Jajko",
            price: 1.99,
            quantity: 12,
            category: "Nabiał",
            expirationDate: DateTime.Now.AddDays(30)
            );

            service.AddProduct(product);

        }
    }
}
