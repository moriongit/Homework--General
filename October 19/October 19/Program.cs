namespace October_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User ID1 = new User();
            ID1.UserName = "Bob";
            ID1.Password = "password";
            ID1.Login();
            ID1.Login();
            ID1.Logout();
        }
    }
}