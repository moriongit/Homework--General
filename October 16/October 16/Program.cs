using System.Transactions;

namespace October_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            int count = 0;
            bool notInPast;
            int[] array = { 1, 2, 3, 4, 5, 3, 4, 123, 4 };
            for (int eachNumberIndex = 0; eachNumberIndex < array.Length; eachNumberIndex++)
            {
                count = 1;
                notInPast = true;
                for (int indexCompare = 0; indexCompare < array.Length; indexCompare++)
                {
                    if (array[eachNumberIndex] == array[indexCompare])
                    {
                        if (eachNumberIndex>indexCompare)
                        {
                            //If the index of number in  comparison is smaller than the original one
                            //that must means there ammount of same numbers is n>1, so we need to break it
                            //in order to not print it several times
                            notInPast = false;
                            break;
                        }
                        else if (eachNumberIndex!=indexCompare)
                        {
                            count++;

                        }
                    }
                }
                if (notInPast)
                {
                    Console.WriteLine(array[eachNumberIndex] + "-dan " + count +" denedir");
                }
                {

                }
            }

            #endregion 
            #region Task2
            int input = 0;
            string stringInput = "";
            Console.WriteLine("Enter array size:");
            input = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[input];
            Console.Write("Fill array?(y/n)");
            stringInput = Console.ReadLine();

            if (stringInput == "y" || stringInput =="yes" )
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("element"+ i +"=");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                for (int i = 0;i < array.Length; i++)
                {
                    Console.Write(array[i]+",");
                }
            }
            #endregion
        }
    }
}