namespace October_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -1, 2, -3, 4, -5 };
            PosInt(array);
        }
        static void PosInt(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]<0)
                {
                    array[i] = array[i]*-1;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}