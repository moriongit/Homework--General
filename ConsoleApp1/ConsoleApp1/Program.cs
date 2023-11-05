using ConsoleApp1.Models;
using ConsoleApp1.Exceptions;

namespace ConsoleApp1

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company myCompany = new Company("MyTech");

            while (true)
            {
                Console.WriteLine("Visual Menu:");
                Console.WriteLine("1. Create employee");
                Console.WriteLine("2. Get employee details by id");
                Console.WriteLine("3. Get all employees");
                Console.WriteLine("4. Update employee details");
                Console.WriteLine("5. Delete employee records by id");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateEmployee();
                        break;
                    case "2":
                        GetEmployeeById();
                        break;
                    case "3":
                        DisplayAllEmployees();
                        break;
                    case "4":
                        UpdateEmployee();
                        break;
                    case "5":
                        DeleteEmployeeById();
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}