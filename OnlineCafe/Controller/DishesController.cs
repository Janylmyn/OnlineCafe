using Newtonsoft.Json;
using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{
    public class DishesController
    {
        readonly ProductController controller;
        readonly Ingredients ingredients;

        public DishesController()
        {
            controller = new ProductController();
            ingredients = new Ingredients();
        }

        public void AddDishes(Dishes dishes)
        {

            using var conn = new NpgsqlConnection(controller.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            string jsonString = JsonConvert.SerializeObject(dishes.Ingredients);
            cmd.CommandText = "INSERT INTO dishes (name,price,ingredients,weight,restaurant_id) VALUES (@name,@price,@ingredients,@weight,@restaurant_id)";

            cmd.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Varchar, dishes.Name!);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.Price!);
            cmd.Parameters.AddWithValue("ingredients", NpgsqlTypes.NpgsqlDbType.Json, jsonString);
            cmd.Parameters.AddWithValue("weight", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.weight!);
            cmd.Parameters.AddWithValue("restaurant_id", NpgsqlTypes.NpgsqlDbType.Integer, dishes.restaurant_id!);

            cmd.ExecuteNonQuery();
        }

        public void Getall()
        {
            Console.WriteLine("Все Блюда");
            using var conn = new NpgsqlConnection(controller.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT d.id, d.name, d.price, d.ingredients, d.weight, r.name AS restaurant_name FROM dishes d LEFT JOIN restaurants r ON d.restaurant_id = r.id", conn);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                do
                {
                    Console.WriteLine($" id: {reader["id"]}, Название: {reader["name"]}, Цена: {reader["price"]},\n состав: {reader["ingredients"]},\n Грамовка: {reader["weight"]},\n из Ресторана: {reader["restaurant_name"]} ");
                } while (reader.Read());
            }
            else
            {
                Console.WriteLine("Вашем ресторане нет блюд");
            }
        }

        public void DeleteDishes(Dishes dishes)
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
            string jsonString = JsonConvert.SerializeObject(dishes.Ingredients);
            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, dishes.id!);
            cmd.Parameters.AddWithValue("newName", NpgsqlTypes.NpgsqlDbType.Varchar, dishes.Name!);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.Price!);
            cmd.Parameters.AddWithValue("ingredients", NpgsqlTypes.NpgsqlDbType.Json, jsonString);
            cmd.Parameters.AddWithValue("weight", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.weight!);

            cmd.ExecuteNonQuery();
        }

    }
}
