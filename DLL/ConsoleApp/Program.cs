using System;
using DLL;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = MathService.Divide(20, 5);
            Console.WriteLine(result);

            Console.Read();
        }
    }
}
