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
            cmd.Parameters.AddWithValue("start_schedule", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(employees.start_schedule!));
            cmd.Parameters.AddWithValue("end_schedule", NpgsqlTypes.NpgsqlDbType.Time, TimeSpan.Parse(employees.end_schedule!));
            cmd.Parameters.AddWithValue("restaurant_id", NpgsqlTypes.NpgsqlDbType.Integer, employees.restaurant_id!);
            cmd.ExecuteNonQuery();

        }
        public void GetAllFromRestaurant(int restaurantId)
        {
            Console.WriteLine($"Все сотрудники ресторана с id {restaurantId}");
            using var conn = new NpgsqlConnection(productController.connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT e.id, e.name, e.position, e.salary, e.start_schedule, e.end_schedule FROM employee e WHERE e.restaurant_id = @restaurantId", conn);
            cmd.Parameters.AddWithValue("restaurantId", restaurantId);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TimeSpan startSchedule = reader.GetTimeSpan(reader.GetOrdinal("start_schedule"));
                TimeSpan endSchedule = reader.GetTimeSpan(reader.GetOrdinal("end_schedule"));

                TimeSpan currentTime = DateTime.Now.TimeOfDay;

                bool isWorking = currentTime >= startSchedule && currentTime <= endSchedule;

                string job = isWorking ? "Он пашит в данное время" : "он ушел"; 
                Console.WriteLine($" id: {reader["id"]}, имя: {reader["name"]}, должность: {reader["position"]},\n зарплата: {reader["salary"]},\n начало работы: {reader["start_schedule"]} \n  конец работы :{reader["end_schedule"]} \n {job}");

                
            }
        }

    }
}
