using Access_modifiers.Models;

namespace Access_modifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Notebook count:");
            int input = Convert.ToInt32 (Console.ReadLine());
            Notebook[] notebooks = new Notebook[input];
            for (int i = 0;i<input;i++)
            {
                Console.Write("Modenl name");
                string model = Console.ReadLine();
                Console.WriteLine("Count");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter price");
                decimal price = Convert.ToInt32(Console.ReadLine());

                Notebook notebook1 = new Notebook(model, count, price);
                notebook1.Model = model;
                notebook1.Count = count;
                notebook1.Price = price;
                notebooks[i] = notebook1;

            }
            for (int i = 0;i<input;i++)
            {
                Console.WriteLine(notebooks[i].Model + " ");
                Console.WriteLine(notebooks[i].Price + " ");
                Console.WriteLine(notebooks[i].Count + " ");
            }
        }
    }
}