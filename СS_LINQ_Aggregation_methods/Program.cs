/*
    Методы агрегирования
1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.
2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen, цена которых превышает 1000 грн.
3) Вычислить среднее значение всех цен товаров.
4) Вывести список категорий без повторений.
5) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по названию.
6) Посчитать суммарное количество товаров категорий Сar и Mobile.
7) Вывести список категорий и количество товаров каждой категории.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LINQ
{
    public class Good
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        class Program
        {
            static void Main(string[] args)
            {
                List<Good> goods1 = new List<Good>()
                {
                new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99,      Category = "Mobile" },
                new Good() { Id = 2, Title = "Iphone 4", Price = 5000,          Category = "Mobile" },
                new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
                new Good() { Id = 4, Title = "Mixer", Price = 150,              Category = "Kitchen" },
                new Good() { Id = 5, Title = "Magnitola", Price = 1499,         Category = "Car" },
                new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100,    Category = "Mobile" },
                new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300,      Category = "Car" },
                new Good() { Id = 8, Title = "Owen", Price = 700,               Category = "Kitchen" },
                new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199,     Category = "Mobile" },
                new Good() { Id = 10, Title = "Lighter", Price = 150,           Category = "Car" }
                };

                // 1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.
                Console.WriteLine("\n1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.\n");

                var mobile = from good in goods1
                             where good.Category == "Mobile"
                             where good.Price > 1000
                             select new
                             {
                                 good.Title,
                                 good.Price,
                                 good.Category
                             };

                foreach (var m in mobile)
                {
                    Console.WriteLine(m.Title + '\t' + m.Price + '\t' + m.Category);
                }

                // методы расширения
                var mobile1 = goods1.Where(good => good.Category == "Mobile").Where(good => good.Price > 1000);               

                Console.WriteLine("\nметоды расширения\n");

                foreach (var m in mobile1)
                {
                    Console.WriteLine("{0} \t {1} \t {2}", m.Title, m.Price, m.Category);
                }

                //2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen, цена которых превышает 1000 грн.

                Console.WriteLine("\n2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen, цена которых превышает 1000 грн.\n");

                var noKitchen = from good in goods1
                             where good.Category != "Kitchen"
                              where good.Price > 1000
                             select new
                             {
                                 good.Title,
                                 good.Price,
                                 good.Category
                             };

                foreach (var m in noKitchen)
                {
                    Console.WriteLine("{0} \t {1} \t {2}", m.Title, m.Price, m.Category);
                }

                // методы расширения
                Console.WriteLine("\nметоды расширения");

                var noKitchen1 = goods1.Where(good => good.Category != "Kitchen").Where(good => good.Price > 1000);            

                foreach (var m in noKitchen1)
                {
                    Console.WriteLine("{0} \t {1} \t {2}", m.Title, m.Price, m.Category);
                }

                //3) Вычислить среднее значение всех цен товаров.

                var avergePrice = goods1.Average(good => good.Price);

                Console.WriteLine("\n3) среднее значение всех цен товаров = " + avergePrice);


                //4) Вывести список категорий без повторений.

                var categories = goods1.Select(good => good.Category).ToList().Distinct();

                Console.WriteLine("\n4) список категорий без повторений:\n");

                foreach (var c in categories)
                {
                    Console.WriteLine(c);
                }

                //5) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по названию.

                var titlesCategories = from good in goods1
                                       orderby good.Title
                                       select new
                                       {
                                           t = good.Title,
                                           c = good.Category
                                       };

                Console.WriteLine("\n5) названия и категории товаров в алфавитном порядке, упорядоченных по названию:" + "\nНазвание:" + "\tКатегория:");

                foreach (var c in titlesCategories)
                {
                    Console.WriteLine("{0} \t\t {1}", c.t, c.c);
                }

                // методы расширения
                Console.WriteLine("\nметоды расширения");

                var titlesCategoriesA = goods1.Select(good => good.Title).Order();

                foreach (var c in titlesCategories)
                {
                    Console.WriteLine("{0} \t\t {1}", c.t, c.c);
                }

                //6) Посчитать суммарное количество товаров категорий Сar и Mobile                          

                Console.Write("\n6) Cуммарное количество товаров категорий Сar и Mobile = ");

                var selectByCategories = from good in goods1
                                      where good.Category == "Mobile" ||
                                            good.Category == "Car"
                                      select good ;

                Console.WriteLine(selectByCategories.Count());

                // методы расширения                                                                  
                Console.WriteLine("\nметоды расширения");

                var countCategoriesA = goods1.Where(c => c.Category == "Mobile" || c.Category == "Car").Count();

                Console.WriteLine("\nCуммарное количество товаров категорий Сar и Mobile = " + countCategoriesA);

                Console.WriteLine('\n');

                //7) Вывести список категорий и количество товаров каждой категории.
                var countGoodsByCategory = from good in goods1
                                           group good by good.Category into g
                                           select new
                                           {
                                               category = g.Key,
                                               count = g.Count()
                                           };

                Console.WriteLine("\n7) Cписок категорий и количество товаров каждой категории.\n");

                foreach (var c in countGoodsByCategory)
                {
                    Console.WriteLine("{0} \t\t {1}", c.category, c.count);
                }
                Console.WriteLine('\n');

                // методы расширения                                                                       
                Console.WriteLine("\nметоды расширения");

                var countGoodsByCategoryA = goods1.GroupBy(c => c.Category).Select(g => new { category = g.Key , count = g.Count() });

                foreach (var c in countGoodsByCategoryA)
                {
                    Console.WriteLine("{0} \t\t {1}", c.category , c.count);
                }
                Console.WriteLine('\n');

            }
        }
    }
}