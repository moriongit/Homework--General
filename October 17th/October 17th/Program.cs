using System.ComponentModel;

namespace October_17th
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fullName("Salamova", "Meftune", "Memmed"));
        }


        static int Area(int a, int b)
        {
            int sduzb = a*b;
            return sduzb;

        }
        static void Area(int a, int b, int c)
        {
            int s = 2*(Area(a, b)+a*c+b*c);
            Console.WriteLine(s);

        }
        static float Area(float r, float p = 3)
        {
            float s = p*r*r;
            return s;

        }

        static int Area(int a, int b, int c, int r)
        {
            int p = (a+b+c)/2;
            int s = p *r;

            return s;


        }
        static void calculator(int a, int b, string operatr)
        {
            if (operatr == "+")
            {
                Console.WriteLine(a+b);
            }
            if (operatr == "-")
            {
                Console.WriteLine(a-b);
            }
            if (operatr == "*")
            {
                Console.WriteLine(a*b);
            }
            if (operatr == "/")
            {
                Console.WriteLine(a/b);
            }


        }
        static void power(int a, int b = 2)
        {
            int number = 1;
            int count = 1;
            for (int i = 1; i <= b; i++)
            {
                number = number*a;
            }
            Console.WriteLine(number);
        }
        static string fullName(string name)
        {
            return name;
        }
        static string fullName(string name, string surname)
        {
            return surname+ " " + name;
        }
        static string fullName(string name, string surname, string fathersName)
        {
            return name[0] + "." + surname +" "+ fathersName;
        }
    }
}
