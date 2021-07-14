using System.Collections.Generic;
using System.Linq;

namespace SelfCheckuot.Shop
{
    public class Cart
    {
        private decimal _sum = 0;

        public decimal Sum
        {
            get => _sum;
        }

        private List<Product> _products;

        public List<Product> Products
        {
            get => _products.ToList();
        }

        public Cart()
        {
            _products = new List<Product>();
        }

        public void Add(Product product)
        {
            _products.Add(product);
            _sum += product.Cost;
        }

        public void Delete(int indexOfProduct)
        {
            _sum -= Products[indexOfProduct].Cost;
            Products.RemoveAt(indexOfProduct);
        }
    }
}