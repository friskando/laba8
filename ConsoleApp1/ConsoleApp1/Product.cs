using System;

namespace ConsoleApp1
{
    [Serializable]
    public class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public decimal Price;
        public int StockQuantity;
        public DateTime AddedDate;

        public Product()
        {
            Id = 0;
            Name = "";
            Category = "";
            Price = 0;
            StockQuantity = 0;
            AddedDate = DateTime.Now;
        }

        public Product(int id, string name, string category, decimal price, int stockQuantity)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
            AddedDate = DateTime.Now;
        }

        public override string ToString()
        {
            string text = $"ID:{Id}|{Name}|{Category}|{Price} руб |{StockQuantity} шт | {AddedDate}";
            return text;
        }
    }
}