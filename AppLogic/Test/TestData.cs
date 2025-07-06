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
            var now = DateTime.Now;

            var products = new List<Product>
             {
             new FoodProduct("Jogurt naturalny", 2.49, 15, "Nabiał", now.AddDays(10)),
             new FoodProduct("Ser żółty", 5.99, 8, "Nabiał", now.AddDays(20)),
             new FoodProduct("Jabłka", 3.29, 20, "Owoce", now.AddDays(14)),
             new FoodProduct("Pomarańcze", 4.19, 12, "Owoce", now.AddDays(10)),
             new FoodProduct("Chleb pełnoziarnisty", 3.49, 10, "Pieczywo", now.AddDays(3)),
             new FoodProduct("Bułki pszenne", 0.89, 30, "Pieczywo", now.AddDays(2)),
             new FoodProduct("Szynka", 6.99, 6, "Mięso", now.AddDays(5)),
             new FoodProduct("Kurczak filet", 12.99, 10, "Mięso", now.AddDays(4)),
             new FoodProduct("Czekolada mleczna", 2.99, 25, "Słodycze", now.AddDays(180)),
             new FoodProduct("Woda mineralna", 1.49, 50, "Napoje", now.AddDays(365)),

             new NonFoodProduct("Smartfon", 1999.99, 4, "Elektronika", 24),
             new NonFoodProduct("Pralka", 1499.00, 2, "AGD", 36),
             new NonFoodProduct("Mikser kuchenny", 299.99, 5, "AGD", 24),
             new NonFoodProduct("Koszulka sportowa", 49.99, 20, "Odzież", 6),
             new NonFoodProduct("Spodnie jeansowe", 89.99, 15, "Odzież", 6),
             new NonFoodProduct("Zabawka edukacyjna", 39.99, 10, "Zabawki", 12),
             new NonFoodProduct("Krem do twarzy", 24.99, 18, "Kosmetyki", 6),
             new NonFoodProduct("Płyn do naczyń", 7.99, 30, "Chemia gospodarcza", 12),
             new NonFoodProduct("Książka - powieść", 29.99, 12, "Książki", 0),
             new NonFoodProduct("Piłka nożna", 59.99, 8, "Sport i rekreacja", 12),

             new FoodProduct("Masło", 6.49, 12, "Nabiał", now.AddDays(14)),
             new FoodProduct("Sałata lodowa", 3.99, 10, "Warzywa", now.AddDays(5)),
             new FoodProduct("Winogrona", 7.99, 8, "Owoce", now.AddDays(7)),
             new FoodProduct("Sok pomarańczowy", 4.49, 20, "Napoje", now.AddDays(90)),
             new FoodProduct("Ciastka owsiane", 5.29, 15, "Słodycze", now.AddDays(120)),
             new FoodProduct("Kiełbasa wiejska", 9.99, 10, "Mięso", now.AddDays(6)),
             new FoodProduct("Twaróg", 4.79, 14, "Nabiał", now.AddDays(10)),
             new FoodProduct("Papryka czerwona", 5.49, 9, "Warzywa", now.AddDays(6)),
             new FoodProduct("Gruszki", 4.99, 11, "Owoce", now.AddDays(8)),
             new FoodProduct("Herbata zielona", 8.99, 18, "Napoje", now.AddDays(365)),

             new NonFoodProduct("Tablet", 1299.00, 3, "Elektronika", 24),
             new NonFoodProduct("Suszarka do włosów", 89.99, 7, "AGD", 24),
             new NonFoodProduct("Bluza z kapturem", 119.99, 10, "Odzież", 6),
             new NonFoodProduct("Zestaw narzędzi", 249.99, 5, "Narzędzia", 36),
             new NonFoodProduct("Wiertarka udarowa", 349.99, 4, "Elektronarzędzia", 24),
             new NonFoodProduct("Zestaw kredek", 14.99, 30, "Artykuły papiernicze", 0),
             new NonFoodProduct("Gra planszowa", 89.99, 6, "Zabawki", 12),
             new NonFoodProduct("Perfumy", 149.99, 8, "Kosmetyki", 12),
             new NonFoodProduct("Program antywirusowy", 99.00, 20, "Oprogramowanie", 12),
             new NonFoodProduct("Ręcznik kąpielowy", 29.99, 25, "Odzież", 6)

             };

            foreach (var product in products)
            {
                product.AddedDate = now;
                service.AddProduct(product);
            }


        }

    }
}
