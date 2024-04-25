
using Newtonsoft.Json;
using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{
    public class Ingredients : Product
    {
        public int Weight;
        ProductController Controller = new ProductController();
        public void ProductSelection(int productID, decimal weight , int id_dishes)
        {
            using var conn = new NpgsqlConnection(Controller.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT name, price FROM products WHERE id = @productId";

            cmd.Parameters.AddWithValue("productId", NpgsqlTypes.NpgsqlDbType.Integer, productID);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string productName = reader.GetString(0);
                decimal productPrice = reader.GetDecimal(1);

               
                var productData = new
                {
                    name = productName,
                    weight = weight
                };
                string jsonString = JsonConvert.SerializeObject(productData);

                addingredients(jsonString, id_dishes);

            }
            else
            {
                Console.WriteLine("Продукт с указанным ID не найден.");
            }
            
        }

        public void addingredients(string json , int id)
        {
            using var conn = new NpgsqlConnection(Controller.connString);
            conn.Open();

            using var insertCmd = new NpgsqlCommand();

            insertCmd.Connection = conn;
            insertCmd.CommandText = "UPDATE dishes SET ingredients = @jsonData WHERE id = @id";
            insertCmd.Parameters.AddWithValue("jsonData", NpgsqlTypes.NpgsqlDbType.Json, json);
            insertCmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);
            insertCmd.ExecuteNonQuery();

        }
    }
}



