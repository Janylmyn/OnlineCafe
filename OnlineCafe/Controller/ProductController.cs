using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{

    public class ProductController
    {
        readonly string connString = "Server=localhost;Port=5432;Username=postgres;Password=0558200511;Database=OnlineRestaurant";
        public void AddProduct(Product product)
        {
          
            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;


            cmd.CommandText = "INSERT INTO product (_name,price,id) VALUES (@_name ,@price,@id)";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, product.Id!);
            cmd.Parameters.AddWithValue("_name", NpgsqlTypes.NpgsqlDbType.Text, product.Name!);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, product.Gramprice);

            cmd.ExecuteNonQuery();
        }

        public void Getall()
        {
            
            Console.WriteLine("Все продукты");
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM product", conn);
            using var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine($" id: {reader["id"]},Название: {reader["_name"]}, цена за грамм: {reader["price"]}");
               
            }

        }  
        public void DeliteProduct(Product product)
        {
            Console.Clear();
            using var conn = new NpgsqlConnection( connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM product WHERE id = @value";

            
            cmd.Parameters.AddWithValue("value", NpgsqlTypes.NpgsqlDbType.Integer, product.Id!);

            int rowsAffected = cmd.ExecuteNonQuery();

        }
        public void EditProduct(Product product)
        {
            Console.Clear();
            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE product SET _name = @newName, price = @newPrice WHERE id = @id";


            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, product.Id!);
            cmd.Parameters.AddWithValue("newName", NpgsqlTypes.NpgsqlDbType.Text, product.Name!);
            cmd.Parameters.AddWithValue("newPrice", NpgsqlTypes.NpgsqlDbType.Numeric,product.Gramprice);

            cmd.ExecuteNonQuery();
        }

    }

}


