using Npgsql;
using OnlineCafe.Model;
using System;


namespace OnlineCafe.Controller
{
    internal class EmployeeController
    {
        readonly ProductController productController = new();
        public void Addemployees(Employees employees)
        {

            using var conn = new NpgsqlConnection(productController.connString);
            conn.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO employee (name,position,salary,start_schedule,end_schedule,restaurant_id) VALUES (@name,@position,@salary,@start_schedule,@end_schedule,@restaurant_id)";

            cmd.Parameters.AddWithValue("name", NpgsqlTypes.NpgsqlDbType.Varchar, employees.Name!);
            cmd.Parameters.AddWithValue("position", NpgsqlTypes.NpgsqlDbType.Varchar, employees.position!);
            cmd.Parameters.AddWithValue("salary", NpgsqlTypes.NpgsqlDbType.Numeric, employees.salary!);
            cmd.Parameters.AddWithValue("start_schedule", NpgsqlTypes.NpgsqlDbType.Time,TimeSpan.Parse( employees.start_schedule!));
            cmd.Parameters.AddWithValue("end_schedule", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(employees.end_schedule!));
            cmd.Parameters.AddWithValue("restaurant_id", NpgsqlTypes.NpgsqlDbType.Integer, employees.restaurant_id!);
            cmd.ExecuteNonQuery();

        }
        public void Getall()
        {

            Console.WriteLine("Все сотруднки");
            using var conn = new NpgsqlConnection(productController.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM employee", conn);
            using var reader = cmd.ExecuteReader();

          
            if (reader.Read())
            {
                while (reader.Read())
                {
                    Console.WriteLine($" id: {reader["id"]} Имя: {reader["name"]} Должность :{reader["position"]}\n Зарплата: {reader["salary"]}\n Начало работы: {reader["start_schedule"]} Конец работы: {reader["end_schedule"]}");

                }
            }
            else
            {
                Console.WriteLine("Вашем ресторане нет сотрудников");
            }

        }
    }
}
