using Newtonsoft.Json;
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
            IngredientsController ingredients = new();
            RestaurantI restaurant = new();
            EmployeeController employeeController = new();
            Employees employees = new();
            RestaurantController restaurantController = new();
            Dishes dishes = new();
            DataOutput dataOutput = new();




            Console.WriteLine("Добро пожаловать господин \n что желаете :)");

           string input = InputHelper.GetValueFromConsole("1.Добавить ресторан\n2.Посмотреть рестораны\n3.Удалить ресторан\n4.Изменить ресторан","1","2","3","4");
            switch (input)
            {
                case "1":
                    Console.WriteLine("Название ресторана");
                    restaurant.Name = Console.ReadLine();
                    Console.WriteLine("Имя Шеф повара");
                    employees.Name = Console.ReadLine();
                    employees.position = "Шеф повар";
                    restaurant.Chef = employees.Name;
                    Console.WriteLine("обслуживание");
                    decimal service = Convert.ToDecimal(Console.ReadLine());
                    restaurant.Service = service / 100;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Обработка данных");
                    Console.WriteLine("пожалуста подожди");
                    Console.ResetColor();
                    employees.restaurant_id = restaurantController.AddRestaurant(restaurant);
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine($"зарплата вашего шефа {restaurant.Chef}");
                    employees.salary = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Начало его смены");
                    employees.start_schedule = Console.ReadLine();
                    Console.WriteLine("Конец его смены");
                    employees.end_schedule = Console.ReadLine();
                    
                    Console.WriteLine("Хотите добавить блюда в ваш ресторан");
                
                    break;
                case "2":
                    break;
                case "3":
                    break; 
                case "4": 
                    break;
            }



            









            /*          while (true)
                      {
                          restaurantController.Getall();
                          restaurant.id = Convert.ToInt32(Console.ReadLine());
                          restaurantController.DeleteRestaurant(restaurant);
                      }*/



            /*      Console.WriteLine("Добавьте сотрудника");

                  Console.WriteLine("Имя сотрудника");
                  employees.Name = Console.ReadLine();
                  Console.WriteLine("должность\n1шеф-повар\n2офик\n3менеджер");
                  employees.position = Console.ReadLine();
                  switch (employees.position)
                  {
                      case "1":
                          employees.position = "Шеф повар";
                          break;
                      case "2":
                          employees.position = "Официант";
                          break;
                      case "3":
                          employees.position = "Менеджер";
                          break;
                  }

                  Console.WriteLine("зарплата");
                  employees.salary = Convert.ToDecimal(Console.ReadLine());
                  Console.WriteLine("Начало его смены");
                  employees.start_schedule = Console.ReadLine();
                  Console.WriteLine("Конец его смены");
                  employees.end_schedule = Console.ReadLine();
                  employees.restaurant_id = 8;
                  employeeController.Addemployees(employees);

                  employeeController.GetAllFromRestaurant(8);*/

            /*            while (true)
                        {
                            Console.WriteLine("Добро пожаловать хозяин");
                            Console.WriteLine("название продукта:");
                            product.Name = Console.ReadLine();
                            Console.WriteLine("Тип продукта");
                            Console.WriteLine("1.Фрукты\n2.Овощи\n3.Мясо");
                            product.TypeProduct = Console.ReadLine();
                            switch (product.TypeProduct){
                                case "1":
                                    product.TypeProduct = "Фрукты";
                                    break;
                                case "2":
                                    product.TypeProduct = "Овощи";
                                    break;
                                case "3":
                                    product.TypeProduct = "Мясо";
                                    break;
                            }
                            Console.WriteLine("цена за килграм продукта:");
                            product.Gramprice = Convert.ToDecimal(Console.ReadLine());

                            Console.Clear();
                            controller.AddProduct(product);

                            controller.GetAll();
                        }*/




            /*           Console.WriteLine("изменение ресторана");*/




            Console.WriteLine("Добавление блюда");



              Console.WriteLine("Укажите название");
              dishes.Name = Console.ReadLine();

              int productid = -1;

              while (productid != 0)
              {
                  Console.Clear();
                  controller.GetAll();
                  Console.WriteLine("Выбери продукт для ингредиента");
                  productid = Convert.ToInt32(Console.ReadLine());

                  Console.WriteLine("Сколько кг возмешь");
                  decimal Gram = Convert.ToDecimal(Console.ReadLine());
                  Console.WriteLine("Чтобы выйти нажмите 0");
                  ingredients.productData = ingredients.ProductSelection(productid, Gram);
                  string json = JsonConvert.SerializeObject(ingredients.productData);
                  dishes.Ingredients = json;
              }
              Console.WriteLine("Укажите цену");
              dishes.Price = ingredients.sumprice!.Sum();
              Console.Clear();

              dishes.weight = ingredients.sumweight!.Sum();
              dishes.restaurant_id = 13;
              dishesController.AddDishes(dishes);

              dishesController.GetallFromres(dishes);


              var mostFrequentIngredient = controller.FrequentlyUsedProductFromRestaurant().GroupBy(x => x)
                                                .OrderByDescending(g => g.Count())
                                                .FirstOrDefault();
              string mostFrequentIngredientValue = mostFrequentIngredient!.Key;
              Console.WriteLine(mostFrequentIngredientValue);
            /* employeeController.GetallFromres(12);*/



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
                        controller.DeleteProduct(product);


                        controller.Getall();*/
            /*
                        while (true)
                        {
                            Console.WriteLine("Выберите продукт");
                            product.Id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("измените название");
                            product.Name = Console.ReadLine();
                                Console.WriteLine("Тип продукта");
                                        Console.WriteLine("1.Фрукты\n2.Овощи\n3.Мясо");
                                        product.TypeProduct = Console.ReadLine();
                                        switch (product.TypeProduct){
                                            case "1":
                                                product.TypeProduct = "Фрукты";
                                                break;
                                            case "2":
                                                product.TypeProduct = "Овощи";
                                                break;
                                            case "3":
                                                product.TypeProduct = "Мясо";
                                                break;
                                        }
                            Console.WriteLine("измените цену");
                            product.Gramprice = Convert.ToDecimal(Console.ReadLine());

                            controller.EditProduct(product);

                            controller.GetAll();
                        }*/

        }
    }
}