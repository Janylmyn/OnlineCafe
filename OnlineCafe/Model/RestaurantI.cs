using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Model
{
    internal class RestaurantInfo 
    {
        public string Name { get; set; }
        public string Chef { get; set; } // Имя шефа этого ресторана
        private List<Dishes> menu = new List<Dishes>(); // Список блюд ресторана
        public string Description { get; set; } // Описание ресторана
        public List<Employees>? Employees;
        public decimal ServiceCharge { get; set; } // Обслуживание ресторана

    }
}
