using OnlineCafe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCafe.Controller
{
    internal class ShowMenu
    {;
            public Menu(string RestaurantName, decimal Price, List<Dishes>)
            {
                Console.WriteLine($"Меню ресторана {RestaurantName}:");
                foreach (var dishes in List<Dishes>)
                {
                    Console.WriteLine($"{dishes.Name} - {dishes.Price} сом.");
                }
            }

        }
    }
    }
