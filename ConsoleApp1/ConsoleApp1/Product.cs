using System;

namespace ConsoleApp1
{
    [Serializable]
    internal class Product
    {
        private int _id;
        private string _name;
        private string _category;
        private decimal _price;
        private int _stockQuantity;
        private DateTime _addedDate;

        // свойства для доступ
        public int Id
        {
            get 
            { 
                return _id;
            }
            set 
            {
                _id = value; 
            }
        }

        public string Name
        {
            get 
            {
                return _name; 
            }
            set 
            { 
                _name = value; 
            }
        }

        public string Category
        {
            get 
            { 
                return _category; 
            }
            set 
            { 
                _category = value;
            }
        }

        public decimal Price
        {
            get 
            { 
                return _price;
            }
            set 
            { 
                _price = value;
            }
        }

        public int StockQuantity
        {
            get 
            { 
                return _stockQuantity; 
            }
            set 
            { 
                _stockQuantity = value;
            }
        }

        public DateTime AddedDate
        {
            get 
            { 
                return _addedDate;
            }
            set 
            { 
                _addedDate = value; 
            }
        }

        internal Product()
        {
            _id = 0;
            _name = "";
            _category = "";
            _price = 0;
            _stockQuantity = 0;
            _addedDate = DateTime.Now;
        }

        internal Product(int id, string name, string category,
            decimal price, int stockQuantity)
        {
            _id = id;
            _name = name;
            _category = category;
            _price = price;
            _stockQuantity = stockQuantity;
            _addedDate = DateTime.Now;
        }

        public override string ToString()
        {
            string text = $"ID:{_id}|{_name}|{_category}" +
                $"|{_price} руб |{_stockQuantity} шт " +
                $"| {_addedDate}";
            return text;
        }
    }
}