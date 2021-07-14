using System;
using System.Collections.Generic;
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

        public static void FillStore()
        {
            store[1000] = new Product(1000, "Bag", new decimal(0.12));
            store[1001] = new Product(1001, "Cheese", new decimal(3.42));
            store[1002] = new Product(1002, "Bread", new decimal(0.89));
            store[1003] = new Product(1003, "Milk", new decimal(2.43));
            store[1004] = new Product(1004, "Sugar", new decimal(1.5));
            store[1005] = new Product(1005, "Meat", new decimal(7.56));
        }

        public static void CLI()
        {
            Console.Out.WriteLine("Add any products to UR cart ");
            Console.Out.WriteLine("Bag is included to sum (it's cost 0.12) ");
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
        }

        public static void Main(string[] args)
        {
            FillStore();
            CLI();
        }
    }
}