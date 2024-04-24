using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{

    public class ProductController
    {
        readonly string connString = "Server=onlinecafe.postgres.database.azure.com;Database=postgres;Port=5432;User Id=onlineRestaurant;Password= Azamat2005;Ssl Mode=Require;";
        public void AddProduct(Product product)
        {
          
            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;


            cmd.CommandText = "INSERT INTO products (id,name,typeproduct,price) VALUES (@id,@name,@typeproduct,@price)";

            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, product.Id!);
            cmd.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Varchar, product.Name!);
            cmd.Parameters.AddWithValue("typeproduct", NpgsqlTypes.NpgsqlDbType.Varchar, product.TypeProduct!);
            cmd.Parameters.AddWithValue("price", NpgsqlTypes.NpgsqlDbType.Numeric, product.Gramprice);

            cmd.ExecuteNonQuery();
        }

        public void Getall()
        {
            
            Console.WriteLine("Все продукты");
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM products", conn);
            using var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine($" id: {reader["id"]},Название: {reader["name"]}, тип :{reader["typeproduct"]}, цена за грамм: {reader["price"]}");
               
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
            cmd.CommandText = "UPDATE product SET name = @newName, typeproduct = @Newtype, price = @newPrice  WHERE id = @id";


            cmd.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer, product.Id!);
            cmd.Parameters.AddWithValue("newName", NpgsqlTypes.NpgsqlDbType.Varchar, product.Name!);
            cmd.Parameters.AddWithValue("Newtype", NpgsqlTypes.NpgsqlDbType.Varchar, product.TypeProduct!);
            cmd.Parameters.AddWithValue("newPrice", NpgsqlTypes.NpgsqlDbType.Numeric,product.Gramprice);

            cmd.ExecuteNonQuery();
        }

    }

}


