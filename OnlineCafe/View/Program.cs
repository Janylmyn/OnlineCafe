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
            Ingredients ingredients = new Ingredients();
            controller.Getall();
            Console.WriteLine("Выбери продукт");
            product.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько кг возмешь");
            product.Gramprice = Convert.ToInt32(Console.ReadLine());
            ingredients.ProductSelection(product.Id, product.Gramprice);

            /*
                        Console.WriteLine("Добро пожаловать хозяин");
                        Console.WriteLine("укажите id:");
                        product.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("название продукта:");
                        product.Name = Console.ReadLine();
                        Console.WriteLine("цена за килграм продукта:");
                        product.Gramprice = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();
                        controller.AddProduct(product);*/
            /*
                        controller.Getall();
                        Console.WriteLine("Удалите Продукт");
                        product.Id = Convert.ToInt32(Console.ReadLine());
                        controller.DeliteProduct(product);*/

            /*
                        controller.Getall();


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