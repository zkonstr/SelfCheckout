namespace SelfCheckuot.Shop
{
    public class Product
    {
        public decimal Cost { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Product(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}