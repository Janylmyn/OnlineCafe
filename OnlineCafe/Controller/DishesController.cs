using Newtonsoft.Json;
using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{
    public class DishesController
    {
        readonly ProductController controller = new();
        Ingredients ingredients = new();
        public void AddDishes(Dishes dishes)
        {

            using var conn = new NpgsqlConnection(controller.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            string jsonString = JsonConvert.SerializeObject(dishes.Ingredients);
            cmd.CommandText = "INSERT INTO dishes (name,price,ingredients,weight) VALUES (@name,@price,@ingredients,@weight)";

            cmd.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Varchar, dishes.Name!);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.Price!);
            cmd.Parameters.AddWithValue("ingredients", NpgsqlTypes.NpgsqlDbType.Json, jsonString);
            cmd.Parameters.AddWithValue("weight", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.weight!);

            cmd.ExecuteNonQuery();
        }

        public void Getall()
        {
            Console.WriteLine("Все продукты");
            using var conn = new NpgsqlConnection(controller.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM dishes", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($" id: {reader["id"]},Название: {reader["name"]}, Цена :{reader["price"]},\n состав: {reader["ingredients"]},\n Грамовка: {reader["weight"]}");

            }

        }

        public void DeliteDishes(Dishes dishes)
        {
            Console.Clear();
            using var conn = new NpgsqlConnection(controller.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM dishes WHERE id = @value";


            cmd.Parameters.AddWithValue("value", NpgsqlTypes.NpgsqlDbType.Integer, dishes.id!);

            int rowsAffected = cmd.ExecuteNonQuery();

        }
        public void EditDishes(Dishes dishes)
        {
            Console.Clear();
            using var conn = new NpgsqlConnection(controller.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE dishes SET name = @newName, ingredients = @ingredients, price = @price, weight = @weight  WHERE id = @id";
            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, dishes.id!);
            cmd.Parameters.AddWithValue("newName", NpgsqlTypes.NpgsqlDbType.Varchar, dishes.Name!);
            cmd.Parameters.AddWithValue("price",NpgsqlTypes.NpgsqlDbType.Numeric,dishes.Price!);
            cmd.Parameters.AddWithValue("ingredients", NpgsqlTypes.NpgsqlDbType.Json, dishes.Ingredients!);
            cmd.Parameters.AddWithValue("weight",NpgsqlTypes.NpgsqlDbType.Numeric, dishes.weight!);

            cmd.ExecuteNonQuery();
        }

    }
}
