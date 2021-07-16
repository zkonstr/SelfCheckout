using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using SelfCheckuot.Shop;

namespace SelfCheckuot
{
    internal class Program
    {
        private static Dictionary<int, Product> store = new Dictionary<int, Product>();
        private static Cart cart = new Cart();

        public static void Help()
        {
            foreach (var item in store)
            {
                Console.Out.WriteLine("Id of " + item.Value.Name + " is " + item.Value.Id);
            }
        }

        public static void AddProduct(string strIndex)
        {
            int id;
            try
            {
                id = int.Parse(strIndex);
                cart.Add(store[id]);
            }
            catch (Exception e)
            {
                Console.WriteLine("incorrect id, please try again");
                return;
            }

            Console.WriteLine(store[id].Name + " added to cart " + " Cost = {0}",
                store[id].Cost + " Sum = " + cart.Sum);
        }

        public static void DeleteProduct()
        {
            Console.Out.WriteLine("Delete products by entering its position");
            string index = Console.ReadLine();
            try
            {
                int position = int.Parse(index);
                cart.Delete(position - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("wrong position");
                return;
            }

            Console.Out.WriteLine("Delete successfully");
        }

        public static void CLI()
        {
            Console.Out.WriteLine("Add any products to UR cart ");
            Console.Out.WriteLine("Enter 'help' to see all Ids ");
            string cmd;
            while ((cmd = Console.ReadLine()) != "")
            {
                switch (cmd)
                {
                    case "help":
                        Help();
                        break;
                    case "delete":
                        DeleteProduct();
                        break;
                    default:
                        AddProduct(cmd);
                        break;
                }
            }

            Console.WriteLine("Proceed to checkout " + "Sum = {0}", cart.Sum);
            PrintCheck();
        }

        

        private const string OutputFolder = @".\checks\";
        private const string OutputExtension = ".txt";
        public static void PrintCheck()
        {
            var fileName = DateTime.Now.ToString().Replace(':', '-');
            using (StreamWriter writer = new StreamWriter(OutputFolder + fileName + OutputExtension))
            {
                foreach (var product in cart.Products)
                {
                    writer.WriteLine(product.Name+" - "+product.Cost);
                }
                writer.WriteLine("Sum = {0}", cart.Sum);
            }
        }

        public static void Main(string[] args)
        {
            
            store=StoreXmlSerializer.Load();
            CLI();
            
        }
    }
}