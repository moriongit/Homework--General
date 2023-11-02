
using Exception_Reflection_task2.Models;
using System.Reflection;


namespace Exception_Reflection_task2
{
    internal class program
    {
        static void Main()
        {
            Users s = new Users();
            var Age = s.GetType().GetField("_staticage", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Age.SetValue(s, 22);
            Console.WriteLine(Age.GetValue(s));
            
            var Id = s.GetType().GetField("_id", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Id.SetValue(s, "F201");
            Console.WriteLine(Id.GetValue(s));
            
            var Name = s.GetType().GetField("_name", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Name.SetValue(s, "Bob");
            Console.WriteLine(Name.GetValue(s));
        }
    }
}
