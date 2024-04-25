using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCafe.Controller;

namespace OnlineCafe.Model
{
    public class Dishes
    {
        public int id;
        public string? Name;
        public decimal? Price;
        public List<Ingredients>? Ingredients;
        public float? weight;

    }
}
