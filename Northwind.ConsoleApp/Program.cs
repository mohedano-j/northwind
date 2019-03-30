using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Northwind.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Northwind.Services.Data.NorthwindDataContext())
            {
                var productList = ctx.Products.ToList();
                foreach (var product in productList)
                {
                    Console.WriteLine(product.ProductName);
                }

                var catList = ctx.Categories.Include(c => c.Products).ToList();
                foreach (var cat in catList)
                {
                    Console.WriteLine(cat.CategoryName);

                    foreach (var prod in cat.Products)
                    {
                        Console.WriteLine("--" + prod.ProductName);
                    }
                }
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
