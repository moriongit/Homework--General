using Delegates.Models;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                List<Exam> exams = new List<Exam>();

                Console.Write("Enter the number of exams: ");
                int numberOfExams = int.Parse(Console.ReadLine());

                for (int i = 0; i < numberOfExams; i++)
                {
                    Console.WriteLine($"Enter details for Exam {i + 1}:");
                    Exam exam = new Exam();

                    Console.Write("Student Name: ");
                    exam.Student = Console.ReadLine();

                    Console.Write("Subject: ");
                    exam.Subject = Console.ReadLine();

                    Console.Write("Points: ");
                    exam.Point = int.Parse(Console.ReadLine());

                    Console.Write("Start Date (MM/dd/yyyy HH:mm): ");
                    exam.StartDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy HH:mm", null);

                    Console.Write("End Date (MM/dd/yyyy HH:mm): ");
                    exam.EndDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy HH:mm", null);

                    exams.Add(exam);
                }

               
                Console.WriteLine("Exams with Points above 50:");
                ShowExams(exams, e => e.Point > 50);

                //duzunu desem date time hissesini tekrar yazsam 99% sehv yazacam cunki internetden baxib yazmisam 
                DateTime oneWeekAgo = DateTime.Now.AddDays(-7);
                Console.WriteLine("Exams in the past 1 week:");
                ShowExams(exams, e => e.StartDate >= oneWeekAgo);

                
                Console.WriteLine("Exams longer than 1 hour:");
                ShowExams(exams, e => e.Duration.TotalHours > 1);
            }

            static void ShowExams(List<Exam> exams, Func<Exam, bool> filter)
            {
                foreach (var exam in exams)
                {
                    if (filter(exam))
                    {
                        Console.WriteLine($"StudentName: {exam.Student}, Subject: {exam.Subject}, Point: {exam.Point}, Duration: {exam.Duration.TotalHours} hours");
                    }
                }
            }
        }
    }
