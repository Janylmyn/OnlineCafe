using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Model
{
    internal class RestaurantI
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Employees>? Employees;
        public decimal? Service { get; set; }

    }
}
