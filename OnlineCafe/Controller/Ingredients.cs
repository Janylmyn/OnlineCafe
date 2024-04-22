
using Newtonsoft.Json;
using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{
    internal class Ingredients : Product
    {
        public int Weight;

        readonly string connString = "Server=localhost;Port=5432;Username=postgres;Password=0558200511;Database=OnlineRestaurant";
        public void ProductSelection(int productID, decimal weight)
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT _name, price FROM product WHERE id = @productId";

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


                addingredients(jsonString, 1);

            }
            else
            {
                Console.WriteLine("Продукт с указанным ID не найден.");
            }
            
        }

        public void addingredients(string json , int id)
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using (var insertCmd = new NpgsqlCommand())
            {

                insertCmd.Connection = conn;
                insertCmd.CommandText = "UPDATE dishes SET ingredients = @jsonData WHERE dishes_id = @id";
                insertCmd.Parameters.AddWithValue("jsonData", NpgsqlTypes.NpgsqlDbType.Json, json);
                insertCmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, id);
                int rowsAffected = insertCmd.ExecuteNonQuery();
            }

        }
    }
}



