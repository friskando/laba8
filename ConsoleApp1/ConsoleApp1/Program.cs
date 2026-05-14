using System;

namespace ConsoleApp1
{
    class Program
    {
        static string DataFile = "catalog.dat";
        static ProductDatabase db;

        static void Main(string[] args)
        {
            Console.WriteLine("КАТАЛОГ ПРОДУКЦИИ");

            db = new ProductDatabase(DataFile);
            db.LoadFromFile();

            int choice = 0;

            while (choice != 5)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Просмотр");
                Console.WriteLine("2 - Добавить");
                Console.WriteLine("3 - Удалить");
                Console.WriteLine("4 - По категории");
                Console.WriteLine("5 - Выход");
                Console.Write("Выбор: ");

                string input = Console.ReadLine();
                choice = int.Parse(input);

                if (choice == 1)
                {
                    Console.Clear();
                    db.ViewAllProducts();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    AddProduct();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    DeleteProduct();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    ViewByCategory();
                }
                else if (choice == 5)
                {
                    db.SaveToFile();
                    Console.WriteLine("Конец");
                }
                else
                {
                    Console.WriteLine("Неверный выбор");
                }
            }
        }

        static void AddProduct()
        {
            Console.WriteLine("ДОБАВЛЕНИЕ ТОВАРА");

            int id = db.GetNextId();
            Console.WriteLine("Новый ID: " + id);

            Console.Write("Название: ");
            string name = Console.ReadLine();

            Console.Write("Категория: ");
            string category = Console.ReadLine();

            Console.Write("Цена: ");
            string priceStr = Console.ReadLine();
            decimal price = decimal.Parse(priceStr);

            Console.Write("Количество: ");
            string quantityStr = Console.ReadLine();
            int quantity = int.Parse(quantityStr);

            Product newProduct = new Product(id, name, category,
                price, quantity);
            db.AddProduct(newProduct);
            db.SaveToFile();
        }

        static void DeleteProduct()
        {
            Console.WriteLine("УДАЛЕНИЕ ТОВАРА");

            db.ViewAllProducts();

            Console.Write("Введите ID для удаления: ");
            string idStr = Console.ReadLine();
            int id = int.Parse(idStr);

            if (db.DeleteProductById(id))
            {
                db.SaveToFile();
            }
        }

        static void ViewByCategory()
        {
            Console.WriteLine("ПРОСМОТР ПО КАТЕГОРИИ");

            Console.Write("Введите категорию: ");
            string category = Console.ReadLine();

            db.ViewProductsByCategory(category);
        }
    }
}