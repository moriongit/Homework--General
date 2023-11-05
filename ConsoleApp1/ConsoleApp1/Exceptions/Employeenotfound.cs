using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {

        public EmployeeNotFoundException(string message)
            : base(message) { }


    }
}
