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


            cmd.CommandText = "INSERT INTO dishes (id,name,price) VALUES (@id,@name,@price)";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, dishes.id!);
            cmd.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Varchar, dishes.Name!);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, dishes.Price!);

            int productid = -1;
            cmd.ExecuteNonQuery();
        
           
                controller.Getall();
                Console.WriteLine("Выбери продукт");
                productid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Сколько кг возмешь");
                decimal Gram = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Чтобы выйти нажмите 0");
                ingredients.ProductSelection(productid, Gram, dishes.id);
            
            
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
    }
}
