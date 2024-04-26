using OnlineCafe.Controller;
using OnlineCafe.Model;
using System.Xml.Linq;

namespace OnlineCafe.View
{
    static public class Program
    {
        public static void Main(string[] args)
        {
            Product product = new();
            ProductController controller = new();
            Dishes dishes = new();
            DishesController dishesController = new();
            Ingredients ingredients = new();

            /*
                        Console.WriteLine("Добро пожаловать хозяин");
                        Console.WriteLine("название продукта:");
                        product.Name = Console.ReadLine();
                        Console.WriteLine("Тип продукта");
                        product.TypeProduct = Console.ReadLine();
                        Console.WriteLine("цена за килграм продукта:");
                        product.Gramprice = Convert.ToDecimal(Console.ReadLine());

                        Console.Clear();
                        controller.AddProduct(product);

                        controller.Getall();*/

            /*      dishesController.Getall();
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

                  dishesController.AddDishes(dishes);

                  dishesController.Getall();*/



            dishesController.Getall();
            Console.WriteLine("Изменить блюда");
            Console.WriteLine("выберите блюда");
            dishes.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Измените название");
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
            dishes.Price = ingredients.sumprice!.Sum();
            dishes.weight = ingredients.sumweight!.Sum();
            Console.Clear();
            dishesController.EditDishes(dishes);

            dishesController.Getall();
            /*
                        controller.Getall();
                        Console.WriteLine("Удалите Продукт");
                        product.Id = Convert.ToInt32(Console.ReadLine());
                        controller.DeliteProduct(product);


                        controller.Getall();

            *//*
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