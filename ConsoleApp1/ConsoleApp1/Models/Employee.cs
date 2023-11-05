using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public enum Gender
        {
            Male,
            Female,
            Other
        }
    }
}
