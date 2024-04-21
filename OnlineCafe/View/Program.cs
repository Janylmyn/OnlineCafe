using OnlineCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.View
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantInfo rest1 = new RestaurantInfo
            {
                RestaurantName = "Империя пиццы",
                Chef = "Ким Артур"
            };
            RestaurantInfo rest2 = new RestaurantInfo
            {
                RestaurantName = "Додо Пицца",
                Chef = "Павлов Антон"
            };
        }
        
        
    }
}