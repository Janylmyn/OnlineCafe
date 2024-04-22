using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Model
{
    public class RestaurantInfo 
    {
        public string? RestaurantName {  get; set; }
        public Employee? Chef;
        public List<Dishes>? Menu; // Список блюд ресторана
        public List<Employee>? Employee;
        public decimal ServiceCharge { get; set; } // Обслуживание ресторана вуа

    }
}

