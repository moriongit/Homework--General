using Company_USER_Console_App_Class_task.Models;

namespace Company_USER_Console_App_Class_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Company company = new Company(null);




            Console.WriteLine("Create a company");
            Console.WriteLine("Create an employee");
            Console.WriteLine("Delete employee");
            Console.WriteLine("Update employee");
            Console.WriteLine("See all employees");
            Console.WriteLine("See employee");

            Console.Write("Pick an action");

            int userInput = Convert.ToInt32(Console.ReadLine());




        }
    }
}
