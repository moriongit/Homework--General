using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_modifiers.Models
{
    public class Notebook : Product
    {
        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set
            {
                if (value.Length > 3)
                {
                    if (value.Length < 30)
                    {
                        _brand = value;

                    }
                    else
                    {
                        Console.WriteLine("Brand name length should be higher than 3 less than 30");
                        return;
                    }
                }
            }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set
            {
                if (value.Length > 3)
                {
                    if (value.Length < 30)
                    {
                        _model = value;

                    }
                    else
                    {
                        Console.WriteLine("Model name length should be higher than 3 less than 30");
                        return;
                    }
                }
            }
        }

       
        private int _ram;
        public int Ram
        {
            get { return _ram; }
            set
            {
                if (value >0 && value<128)
                {
                    _ram = value;
                }
                else
                {
                    Console.WriteLine("Ram should be more than 0 and less than 128");
                    return;
                }
            }
        }
        private int _storage;
        public int Storage
        {
            get { return _storage; }
            set
            {
                if (Storage>0)
                {
                    _storage = value;
                }
                else
                {
                    Console.WriteLine("Storage should be more than 0");
                    return;
                }
            }
        }
        public Notebook(string model,int count, decimal price) : base(count, price)
        {
            this.Model = model;
            
        }
    }
}
