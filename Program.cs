using System;
using System.Collections.Generic;
using System.IO;
using SelfCheckuot.Shop;

namespace SelfCheckuot
{
    internal class Program
    {
        private static Dictionary<int, Product> _store = new Dictionary<int, Product>();
        private static Cart _cart = new Cart();

        private static void Help()
        {
            foreach (var item in _store)
            {
                Console.Out.WriteLine("Id of " + item.Value.Name + " is " + item.Value.Id);
            }
        }

        private static void AddProduct(string strIndex)
        {
            int id;
            try
            {
                id = int.Parse(strIndex);
                _cart.Add(_store[id]);
            }
            catch (Exception e)
            {
                Console.WriteLine("incorrect id, please try again");
                Console.WriteLine("error: " + e);
                return;
            }

            Console.WriteLine(_store[id].Name + " added to cart " + " Cost = {0}",
                _store[id].Cost + " Sum = " + _cart.Sum);
        }

        private static void DeleteProduct()
        {
            Console.Out.WriteLine("Delete products by entering its position");
            string index = Console.ReadLine();
            try
            {
                int position = int.Parse(index ?? string.Empty);
                _cart.Delete(position - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("wrong position");
                Console.WriteLine("error: " + e);
                return;
            }

            Console.Out.WriteLine("Delete successfully");
        }

        private static void Cli()
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

            Console.WriteLine("Proceed to checkout " + "Sum = {0}", _cart.Sum);
            PrintCheck();
        }

        

        private const string OutputFolder = @".\checks\";
        private const string OutputExtension = ".txt";

        private static void PrintCheck()
        {
            var fileName = DateTime.Now.ToString().Replace(':', '-');
            using (StreamWriter writer = new StreamWriter(OutputFolder + fileName + OutputExtension))
            {
                foreach (var product in _cart.Products)
                {
                    writer.WriteLine(product.Name+" - "+product.Cost);
                }
                writer.WriteLine("Sum = {0}", _cart.Sum);
            }
        }

        public static void Main(string[] args)
        {
            
            _store=StoreXmlSerializer.Load();
            Cli();
            
        }
    }
}