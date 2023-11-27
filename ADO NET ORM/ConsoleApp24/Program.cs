using ConsoleApp24.Models;
using ConsoleApp24.Services;
using System;
using System.Text;

namespace ConsoleApp24
{
 
    class Program
    {
        static void Main()
        {

            Console.OutputEncoding = UTF8Encoding.UTF8;

            UserServices userService = new UserServices();

            Users newUser = new Users
            {
                Name = "John",
                Surname = "Salamski",
                Username = "Bobsalamski",
                Password = "Parol123" 
            };

            userService.Create(newUser);


            UserServices userServiceLogin = new UserServices();

            string username = "Bobsalamski";
            string password = "Parol123";

            if (userService.Authenticate(username, password))
            {
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Wrong Login ");
            }

            foreach (var user in userService.GetAll()) 
            {
                Console.WriteLine($"{user.Id} {user.Name} {user.Surname} {user.Password}");
            }



        }
    }

}