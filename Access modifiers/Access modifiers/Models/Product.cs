using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_modifiers.Models
{
    public class Product
    {
        public int Count { get; set; }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value>0)
                {
                    _price = value;
                }
                else
                {
                    Console.WriteLine("Price should be more than 0");
                    return;
                }

             
            }
        }
        public Product(int count, decimal price)
        {
            this.Count = count;
            this.Price = price;
        }
    }
}