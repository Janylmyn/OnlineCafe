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
          

            Console.WriteLine("Добро пожаловать хозяин");
            Console.WriteLine("название продукта:");
            product.Name = Console.ReadLine();
            Console.WriteLine("Тип продукта");
            product.TypeProduct = Console.ReadLine();
            Console.WriteLine("цена за килграм продукта:");
            product.Gramprice = Convert.ToDecimal(Console.ReadLine());

            Console.Clear();
            controller.AddProduct(product);

            controller.Getall();

            /*  dishesController.Getall();
              Console.WriteLine("Укажите id");
              dishes.id = Convert.ToInt32(Console.ReadLine());
              Console.WriteLine("Укажите название");
              dishes.Name = Console.ReadLine();
              Console.WriteLine("Укажите цену");
              dishes.Price = Convert.ToInt32(Console.ReadLine());
              dishesController.AddDishes(dishes);
  */


            controller.Getall();
            Console.WriteLine("Удалите Продукт");
            product.Id = Convert.ToInt32(Console.ReadLine());
            controller.DeliteProduct(product);


            controller.Getall();

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