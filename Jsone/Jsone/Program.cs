using Jsone.Models;
using Jsone.Services;

namespace Jsone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentService = new StudentService();

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Edit Student");
                Console.WriteLine("4. Display Students");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter student name: ");
                        var name = Console.ReadLine();

                        Console.Write("Enter student surname: ");
                        var surname = Console.ReadLine();

                        Console.Write("Enter student code: ");
                        var code = Console.ReadLine();

                        var newStudent = new Student { Name = name, Surname = surname, Code = code };
                        studentService.AddStudent(newStudent);
                        Console.WriteLine("Student added successfully.");
                        break;

                    case "2":
                        Console.Write("Enter student code to remove: ");
                        var codeToRemove = Console.ReadLine();
                        studentService.RemoveStudent(codeToRemove);
                        Console.WriteLine("Student removed successfully.");
                        break;

                    case "3":
                        Console.Write("Enter student code to edit: ");
                        var codeToEdit = Console.ReadLine();

                        Console.Write("Enter new student name: ");
                        var newName = Console.ReadLine();

                        Console.Write("Enter new student surname: ");
                        var newSurname = Console.ReadLine();

                        Console.Write("Enter new student code: ");
                        var newCode = Console.ReadLine();

                        var editedStudent = new Student { Name = newName, Surname = newSurname, Code = newCode };
                        studentService.EditStudent(codeToEdit, editedStudent);
                        Console.WriteLine("Student edited successfully.");
                        break;

                    case "4":
                        var students = studentService.GetStudents();
                        Console.WriteLine("List of Students:");
                        foreach (var student in students)
                        {
                            Console.WriteLine($"Name: {student.Name}, Surname: {student.Surname}, Code: {student.Code}");
                        }
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}