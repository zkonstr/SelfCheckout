using System.Collections.Generic;
using System.Data.SQLite;
using SelfCheckuot.Shop;

namespace SelfCheckuot.Database
{
    public class StoreSqliteDao : IStoreDao
    {
        private SQLiteConnection _connection;
        private readonly string _tableName;

        public StoreSqliteDao(string tableName)
        {
            _tableName = tableName;
        }

        public bool Connect(string url)
        {
            var connString = $"Data Source={url};Version=3;";
            _connection = new SQLiteConnection(connString);
            _connection.Open();
            var cmd = _connection.CreateCommand();
            cmd.CommandText =
                $"CREATE TABLE IF NOT EXISTS {_tableName}(ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME TEXT, COST REAL)";
            cmd.ExecuteScalar();
            return true;
        }

        public bool Disconnect()
        {
            _connection.Close();
            return true;
        }

        public bool InsertProduct(Product product)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText =
                $"INSERT INTO {_tableName} (ID,NAME,COST) VALUES({product.Id},'{product.Name}',{product.Cost});";
            return cmd.ExecuteScalar() != null;
        }

        public Product ReadProduct(int id)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {_tableName} WHERE ID = {id};";
            var reader = cmd.ExecuteReader();
            var product = new Product();
            while (reader.Read())
            {
                product.Id = (int) reader["ID"];
                product.Name = (string) reader["NAME"];
                product.Cost = (decimal) reader["COST"];
            }

            return product;
        }

        public Product[] ReadAllProducts()
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {_tableName};";
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product();
                product.Id = (int) (long) reader["ID"];
                product.Name = (string) reader["NAME"];
                product.Cost = (decimal) (double) reader["COST"];
                products.Add(product);
            }

            return products.ToArray();
        }

        public bool UpdateProduct(Product product)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText =
                $"UPDATE {_tableName} SET NAME = {product.Name}, COST = {product.Cost} WHERE ID= {product.Id};";
            return cmd.ExecuteScalar() != null;
        }

        public bool DeleteProduct(int id)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"DELETE * FROM {_tableName} WHERE ID = {id};";
            return cmd.ExecuteScalar() != null;
        }
    }
}