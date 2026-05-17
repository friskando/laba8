using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ConsoleApp1
{
    public class ProductDatabase
    {
        private List<Product> _products;
        private readonly string _filePath;

        public ProductDatabase(string filePath)
        {
            _filePath = filePath;
            _products = new List<Product>();
        }

        public bool LoadFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    byte[] bytes = File.ReadAllBytes(_filePath);
                    string json = Encoding.UTF8.GetString(bytes);
                    List<Product> temp = JsonSerializer.
                        Deserialize<List<Product>>(json);

                    if (temp != null)
                    {
                        _products = temp;
                    }
                    else
                    {
                        _products = new List<Product>();
                    }

                    Console.WriteLine("Загружено " + 
                        _products.Count + " записей");
                }
                else
                {
                    Console.WriteLine("Файл не найден. Новая " +
                        "база.");
                    _products = new List<Product>();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                _products = new List<Product>();
                return false;
            }
        }

        public bool SaveToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(_products);
                byte[] bytes = Encoding.UTF8.GetBytes(json);
                File.WriteAllBytes(_filePath, bytes);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка");
                return false;
            }
        }

        public void ViewAllProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("База пуста");
                return;
            }

            var sorted = from p in _products
                         orderby p.Id
                         select p;

            foreach (var p in sorted)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Всего: " + _products.Count);
        }

        public bool DeleteProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                Console.WriteLine("Товар с ID " + id 
                    + " не найден");
                return false;
            }
            _products = _products.Where(p => p.Id != id).ToList();

            Console.WriteLine("Товар удалён");
            return true;
        }

        internal bool AddProduct(Product product)
        {
            if (_products.Any(p => p.Id == product.Id))
            {
                Console.WriteLine("ID уже существует");
                return false;
            }

            _products.Add(product);
            Console.WriteLine("Товар добавлен");
            return true;
        }

        public int GetNextId()
        {
            if (!_products.Any())
            {
                return 1;
            }

            return _products.Max(p => p.Id) + 1;
        }
        public bool HasProducts()
        {
            return _products.Any();
        }

        internal List<Product> GetAllProducts()
        {
            return _products;
        }

        public void ViewProductsByCategory(string category)
        {
            var filtered = _products.Where(p => p.Category
            == category).ToList();

            if (!filtered.Any())
            {
                Console.WriteLine("Нет товаров в" +
                    " категории '" + category);
                return;
            }

            Console.WriteLine("Категория: " + category);
            foreach (var p in filtered)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}