using System;
using MyProject.Models;
using MyProject.Exceptions;

class Program
{
    static void Main()
    {
        User user = new User();

        bool isValidInput;
        string input;

        do
        {
            isValidInput = true;

            Console.Write("Enter name: ");
            input = Console.ReadLine();
            try
            {
                user.Name = input;
            }
            catch (InvalidNameException e)
            {
                Console.WriteLine(e.Message);
                isValidInput = false;
            }
        } while (!isValidInput);

        do
        {
            isValidInput = true;

            Console.Write("Enter age: ");
            input = Console.ReadLine();
            try
            {
                user.Age = int.Parse(input);
            }
            catch (InvalidAgeException e)
            {
                Console.WriteLine(e.Message);
                isValidInput = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid age format. Please enter a valid number.");
                isValidInput = false;
            }
        } while (!isValidInput);

        do
        {
            isValidInput = true;

            Console.Write("Enter phone number: ");
            input = Console.ReadLine();
            try
            {
                user.PhoneNumber = input;
            }
            catch (InvalidPhoneFormatException e)
            {
                Console.WriteLine(e.Message);
                isValidInput = false;
            }
        } while (!isValidInput);

        do
        {
            isValidInput = true;

            Console.Write("Enter password: ");
            input = Console.ReadLine();
            try
            {
                user.Password = input;
            }
            catch (PasswordException e)
            {
                Console.WriteLine(e.Message);
                isValidInput = false;
            }
        } while (!isValidInput);

        Console.WriteLine("User registration successful!");
    }
}