using OnlineCafe.Controller;
using OnlineCafe.Model;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace OnlineCafe.View
{
    static public class Program
    {
        public static void Main(string[] args)
        {
            Product product = new();
            ProductController controller = new();

            DishesController dishesController = new();
            Ingredients ingredients = new();
            RestaurantI restaurant = new();
            EmployeeController employeeController = new();
            Employees employees = new();
            RestaurantController restaurantController = new();
            Dishes dishes = new();



            restaurant.Service = Convert.ToDecimal(Console.ReadLine());
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            restaurant.Service = restaurant.Service > 20 ? restaurant.Service = 20 / 100 : restaurant.Service / 100;
            Console.WriteLine(sum * restaurant.Service);

            /*        Console.WriteLine("Добро пожаловать хозяин");
                    Console.WriteLine("Название ресторана");
                    restaurant.Name = Console.ReadLine();




                    Console.WriteLine("Имя Шеф повара");
                    employees.Name = Console.ReadLine();
                    employees.position = "Шеф повар";
                    restaurant.Chef = employees.Name;
                    Console.WriteLine("обслуживание");
                    restaurant.Service =Convert.ToInt32(Console.ReadLine()) /100;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Обработка данных");
                    Console.WriteLine("пожалуста подожди");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear();
                    employees.restaurant_id = restaurantController.AddRestaurant(restaurant);

                    Console.WriteLine($"зарплата {restaurant.Chef}");
                    employees.salary = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Начало его смены");
                    employees.start_schedule = Console.ReadLine();
                    Console.WriteLine("Конец его смены");
                    employees.end_schedule = Console.ReadLine();

                    employeeController.Addemployees(employees);
        */



            /*            while (dishes.id != null)
                        {
                            dishesController.Getall();
                            dishes.id = Convert.ToInt32(Console.ReadLine());
                            dishesController.DeleteDishes(dishes);
                        }*/

            /*  while (true)
              {
                  restaurantController.Getall();
                  Console.WriteLine("выберите какой хотите удалить");
                  restaurant.id = Convert.ToInt32(Console.ReadLine());
                  restaurantController.DeleteProduct(restaurant);
              }*/





            /*            Console.WriteLine("Добавьте сотрудника");

                        Console.WriteLine("Имя сотрудника");
                        employees.Name = Console.ReadLine();
                        Console.WriteLine("должность");
                        employees.position = Console.ReadLine();
                        Console.WriteLine("зарплата");
                        employees.salary = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Начало его смены");
                        employees.start_schedule = Console.ReadLine();
                        Console.WriteLine("Конец его смены");
                        employees.end_schedule = Console.ReadLine();
                        employeeController.Addemployees(employees);
            */


            /*            Console.WriteLine("Добро пожаловать хозяин");
                        Console.WriteLine("название продукта:");
                        product.Name = Console.ReadLine();
                        Console.WriteLine("Тип продукта");
                        product.TypeProduct = Console.ReadLine();
                        Console.WriteLine("цена за килграм продукта:");
                        product.Gramprice = Convert.ToDecimal(Console.ReadLine());

                        Console.Clear();
                        controller.AddProduct(product);

                        controller.Getall();

            */

            /*            Console.WriteLine("Добавление блюда");



                        Console.WriteLine("Укажите название");
                        dishes.Name = Console.ReadLine();

                        int productid = -1;

                        while (productid != 0)
                        {
                            Console.Clear();
                            controller.Getall();
                            Console.WriteLine("Выбери продукт для ингредиента");
                            productid = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Сколько кг возмешь");
                            decimal Gram = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Чтобы выйти нажмите 0");
                            dishes.Ingredients = ingredients.ProductSelection(productid, Gram);
                        }
                        Console.WriteLine("Укажите цену");
                        dishes.Price = ingredients.sumprice!.Sum();
                        Console.Clear();

                        dishes.weight = ingredients.sumweight!.Sum();
                        dishes.restaurant_id = employees.restaurant_id;
                        dishesController.AddDishes(dishes);*/

/*            dishesController.GetallFromres(12);
            employeeController.GetallFromres(12);*/



            /*          dishesController.Getall();
                      Console.WriteLine("Изменить блюда");
                      Console.WriteLine("выберите блюда");
                      dishes.id = Convert.ToInt32(Console.ReadLine());
                      Console.WriteLine("Измените название");
                      dishes.Name = Console.ReadLine();
                      int productid = -1;

                      Console.Clear();
                      controller.Getall();
                      Console.WriteLine("Выбери продукт для ингредиента");
                      productid = Convert.ToInt32(Console.ReadLine());
                      Console.WriteLine("Сколько кг возмешь");
                      decimal Gram = Convert.ToDecimal(Console.ReadLine());
                      Console.WriteLine("Чтобы выйти нажмите 0");
                      dishes.Ingredients = ingredients.ProductSelection(productid, Gram);

                      dishes.Price = ingredients.sumprice!.Sum();
                      dishes.weight = ingredients.sumweight!.Sum();
                      dishesController.EditDishes(dishes);

                      dishesController.Getall();*/
            /*
                        controller.Getall();
                        Console.WriteLine("Удалите Продукт");
                        product.Id = Convert.ToInt32(Console.ReadLine());
                        controller.DeliteProduct(product);


                        controller.Getall();*/

            /*
                        Console.WriteLine("Выберите продукт");
                        product.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("измените название");
                        product.Name = Console.ReadLine();
                        Console.WriteLine("измените цену");
                        product.Gramprice = Convert.ToDecimal(Console.ReadLine());

                        controller.EditProduct(product);

                        controller.Getall();*/
        }
    }
}