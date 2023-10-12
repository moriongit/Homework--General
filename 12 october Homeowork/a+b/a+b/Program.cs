/*#region Birinci ededi ikinciye menimsetmek
int firstNumber = 21;
int secondNumber = 22;
firstNumber = firstNumber + secondNumber;
secondNumber = firstNumber - secondNumber;
firstNumber = firstNumber - secondNumber;
Console.WriteLine(firstNumber);
Console.WriteLine(secondNumber);
#endregion*/

#region Fibonacci
Console.WriteLine("Input your number:");
int input = Convert.ToInt32(Console.ReadLine());
int fibFirstNumber = 0;
int fibSecondNumber = 1;
int Fib = fibFirstNumber + fibSecondNumber;
while (Fib <= input)
{
    Console.WriteLine(Fib);
    fibFirstNumber = fibSecondNumber;
    fibSecondNumber = Fib;
    Fib = fibFirstNumber + fibSecondNumber;
    
}
#endregion
