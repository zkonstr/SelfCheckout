using System.Collections.Generic;
using System.Linq;

namespace SelfCheckuot.Shop
{
    public class Cart
    {
        private readonly List<Product> _products;

        public Cart()
        {
            _products = new List<Product>();
        }

        public decimal Sum { get; private set; }

        public List<Product> Products => _products.ToList();

        public void Add(Product product)
        {
            _products.Add(product);
            Sum += product.Cost;
        }

        public void Delete(int indexOfProduct)
        {
            Sum -= Products[indexOfProduct].Cost;
            Products.RemoveAt(indexOfProduct);
        }
    }
}