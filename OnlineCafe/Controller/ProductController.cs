using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{

    public class ProductController
    {
       public readonly string connString = "Server=psql-online-rest.postgres.database.azure.com;Database=postgres;Port=5432;User Id=postgres;Password=Azamat2005!;";
        public void AddProduct(Product product)
        {
          
            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;


            cmd.CommandText = "INSERT INTO product (name,product_type,price) VALUES (@name,@typeproduct,@price)";


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

            using var cmd = new NpgsqlCommand("SELECT * FROM product", conn);
            using var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine($" id: {reader["id"]},Название: {reader["name"]}, тип :{reader["product_type"]}, цена за грамм: {reader["price"]}");
               
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


