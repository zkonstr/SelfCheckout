using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using SelfCheckuot.Shop;

namespace SelfCheckuot
{
    public class StoreXmlSerializer
    {
        public static Dictionary<int, Product> Load()
        {
            List<Product> products;
            using (var fs = new StreamReader("check.xml"))
            {
                var xs = new XmlSerializer(typeof(List<Product>));
                products = (List<Product>) xs.Deserialize(fs);
            }

            var store = new Dictionary<int, Product>();
            foreach (var product in products) store[product.Id] = product;

            return store;
        }

        public static void Save(Dictionary<int, Product> store)
        {
            var products = store.Values.ToList();
            using (var fs = new StreamWriter("check.xml"))
            {
                var xs = new XmlSerializer(typeof(List<Product>));
                xs.Serialize(fs, products);
            }
        }
    }
}