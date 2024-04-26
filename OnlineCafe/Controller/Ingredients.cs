
using Newtonsoft.Json;
using Npgsql;
using OnlineCafe.Model;
using System.Diagnostics;
using System.Text;

namespace OnlineCafe.Controller
{
    public class Ingredients : Product
    {
        public int Weight;
        public Dictionary<string, decimal> productData = [];
        public List<decimal> sumprice = [], sumweight = [];
        readonly ProductController Controller = new ProductController();

        public Dictionary<string,decimal> ProductSelection(int productID, decimal weight)
        {
            using var conn = new NpgsqlConnection(Controller.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT name, price FROM product WHERE id = @productId";

            cmd.Parameters.AddWithValue("productId", NpgsqlTypes.NpgsqlDbType.Integer, productID);

            using var reader = cmd.ExecuteReader();
           
            if (reader.Read())
            {
                string productName = reader.GetString(0);
                decimal productPrice = reader.GetDecimal(1);

                sumprice!.Add(productPrice * weight);
                sumweight!.Add(weight);
                productData.Add(productName, weight);

            }
            else
            {
                Console.WriteLine("Продукт с указанным ID не найден.");
            }
            return productData;
            
        }

       
    }
}



