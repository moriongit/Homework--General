using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October_19
{
    public class User
    {
        public string UserName;
        public string Password;
        public int Count = 0;


        public void Login()
        {
            Console.WriteLine("User has successfully logged in");
            Count++;
            if (Count > 1)
            {
                Console.WriteLine("User has logged in before");
            }
            else if (Count == 1)
            {
                Console.WriteLine("User has never logged in before");

            }

        }
        public void Logout()
        {
            Console.WriteLine("User has successfully logged out");

        }
    }
}
