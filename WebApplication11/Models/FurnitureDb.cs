using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{
    public class Furniture
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }

    public class PostHiddenViewModel
    {
        public string Foo { get; set; }
    }

    public class AddFurnitureViewModel
    {
        public int Count { get; set; }
    }

    public class FurnitureDb
    {
        private readonly string _connectionString;

        public FurnitureDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int GetTotalCount()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Furniture";
                connection.Open();
                return (int) cmd.ExecuteScalar();
            }
        }
        
        public void Add(Furniture furniture)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Furniture (Name, Color, Price, QuantityInStock) " +
                                  "VALUES (@name, @color, @price, @quantity)";
                cmd.Parameters.AddWithValue("@name", furniture.Name);
                cmd.Parameters.AddWithValue("@color", furniture.Color);
                cmd.Parameters.AddWithValue("@price", furniture.Price);
                cmd.Parameters.AddWithValue("@quantity", furniture.QuantityInStock);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}