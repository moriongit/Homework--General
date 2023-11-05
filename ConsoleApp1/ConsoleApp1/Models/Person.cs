using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    abstract public class Person
    {
       

        public string Name { get; set; }
        public string Surname { get; set; }
        private static int _id=1;
        public int Id { get; private set; }

        public Person()
        {
            Id = _id;
            _id++;
        }
        public int Age { get; set; }

       
    }
}
