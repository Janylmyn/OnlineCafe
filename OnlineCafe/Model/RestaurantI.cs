using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Model
{
    internal class RestaurantInfo 
    {
        public string? RestaurantName {  get; set; }
        public string? Chef { get; set; } // Имя шефа этого ресторана
        private List<Dishes> Menu; // Список блюд ресторана
        public string? Description { get; set; } // Описание ресторана
        public List<Employee>? Employee;
        public decimal ServiceCharge { get; set; } // Обслуживание ресторана

    }
}

