﻿using Npgsql;
using OnlineCafe.Model;

namespace OnlineCafe.Controller
{
    internal class RestaurantController
    {
        readonly ProductController productController = new();
        public int AddRestaurant(RestaurantI restaurant)
        {
            using var conn = new NpgsqlConnection(productController.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO restaurant (name, chef_name, servicecharge) VALUES (@name, @chef_name, @servicecharge) RETURNING restaurant_id";

            cmd.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Varchar, restaurant.Name!);
            cmd.Parameters.AddWithValue("chef_name", NpgsqlTypes.NpgsqlDbType.Varchar, restaurant.Chef!);
            cmd.Parameters.AddWithValue("servicecharge", NpgsqlTypes.NpgsqlDbType.Numeric, restaurant.Service!);

            int insertedId = (int)cmd.ExecuteScalar()!;

            return insertedId;
        }
        public void Getall()
        {

            Console.WriteLine("Все Рестораны");
            using var conn = new NpgsqlConnection(productController.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM restaurant", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($" id: {reader["restaurantid"]},Название: {reader["name"]}, Шеф повар :{reader["chef_name"]}, Обслуживание: {reader["servicecharge"]}");

            }

        }
        public void DeleteProduct(RestaurantI restaurant)
        {
            Console.Clear();
            using var conn = new NpgsqlConnection(productController.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            // Удаление блюд по ID ресторана
            cmd.CommandText = "DELETE FROM dishes WHERE restaurant_id = @restaurantId";
            cmd.Parameters.AddWithValue("restaurantId", NpgsqlTypes.NpgsqlDbType.Integer, restaurant.id!);
            cmd.ExecuteNonQuery();

            // Удаление сотрудников по ID ресторана
            cmd.CommandText = "DELETE FROM employee WHERE restaurant_id = @restaurantId";
            cmd.ExecuteNonQuery();

            // Удаление самого ресторана
            cmd.CommandText = "DELETE FROM restaurant WHERE restaurantid = @restaurantId";
            cmd.ExecuteNonQuery();
        }

    }
}
