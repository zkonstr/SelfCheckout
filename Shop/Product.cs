using System;

namespace SelfCheckuot.Shop
{
    [Serializable]
    public class Product
    {
        public Product(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}