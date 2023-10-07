using ConsoleApp1.Context;
using ConsoleApp1.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            //Import the  productContext and use it
            using ProductContext productContext = new ProductContext();

            //ReadOnlyMemory the json file and send it to the database

            var json = File.ReadAllText("D:/Work/First Task/products.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            productContext.product.AddRange(products);

            Product product01 = new Product()
            {
                ProductName = "سلطة لبنانيه",
                ProductImage = "https://smapi.gtwit.net/images/items/37b6b949-8170-4e21-aa1b-24d84296b51a.jpg",
                ProductDescription = "سلطة شهية مليئة بتشكيلة من الخضار الطازجة مع قطع من الجبنة البيضاء اللذيذة"
            };

            //Add product
            productContext.product.Add(product01);

            productContext.SaveChanges();

            //show one product

            var showProduct = productContext.product.Find(1);
            Console.WriteLine(showProduct.ProductImage);

            Console.WriteLine("--------------------------------------------------------------");

            //show all products
            var showProducts = productContext.product.ToList();
            foreach (var product in showProducts)
            {
                Console.WriteLine(product.ProductImage);
            }

            //Update product
            var showProduct02 = productContext.product.Find(2);
            showProduct02.ProductName = "سلطة بلدي";
            productContext.SaveChanges();

            //delete product

            var showProduct03 = productContext.product.Find(3);
            productContext.Remove(showProduct03);
            productContext.SaveChanges();
        }
    }
}