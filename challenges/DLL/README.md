# Example of how to create a DLL file

1. Create New Visual Studio Solution
2. Add Console App Project for Test Purposes
3. Add Class Library Project to Build the DLL File
4. When finished, build the project
5. Go to Console App and add the DLL to `ConsoleApp` > `refereces` > `Add Reference`, find the DLL in `Debug Folder` then add to the project

### DLL Code - MathService.cs
```csharp
using System;

namespace DLL
{
    public static class MathService
    {
        public static int Divide (int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }
    }
}
```

### ConsoleApp - Program.cs
```csharp
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
```