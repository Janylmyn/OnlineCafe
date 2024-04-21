using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OnlineCafe.Model
{
    internal class PrintMenu
    {
        public static void PrintMenu()
        {
            Console.WriteLine($"Меню ресторана {RestaurantName}:");
            foreach (var dishes in menu)
            {
                Console.WriteLine($"{dishes.Name} - {dishes.Price} сом.");
            }
        }

    }
}
