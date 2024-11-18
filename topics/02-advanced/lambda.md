# Lambda
Em C#, lambdas são **funções anônimas que podem ser usadas para criar delegados ou expressões de árvore de expressão.** 

Elas são especialmente úteis para **passar código como parâmetros para métodos, tornando o código mais conciso e legível.** Lambdas são **frequentemente usadas com métodos de alta ordem, como aqueles disponíveis em LINQ (Language Integrated Query).**

## Sintaxe de Lambdas
A sintaxe de uma expressão lambda usa o operador `=>`, que pode ser lido como `"vai para"`. **A expressão à esquerda do `=>` representa os parâmetros, e a expressão à direita representa o corpo da função.**
```csharp
(parameters) => expression
```

### Exemplos
**Lambda sem parâmetros:**
```csharp
() => Console.WriteLine("Hello, Lambda!")
```

**Lambda com um parâmetro:**
```csharp
x => x * x
```

**Lambda com múltiplos parâmetros:**
```csharp
(x, y) => x + y
```

**Lambda com um bloco de código:**
```csharp
(x, y) => 
{
    int sum = x + y;
    return sum;
}
```

## Uso de Lambdas com Delegates
Lambdas são **frequentemente usadas para criar instâncias de delegados.**
```csharp
using System;

public class Program
{
    // Definindo um delegate
    public delegate int MathOperation(int a, int b);

    public static void Main()
    {
        // Usando uma expressão lambda para criar um delegate
        MathOperation add = (a, b) => a + b;
        Console.WriteLine($"Addition: {add(3, 4)}");

        // Usando uma expressão lambda para criar outro delegate
        MathOperation multiply = (a, b) => a * b;
        Console.WriteLine($"Multiplication: {multiply(3, 4)}");
    }
}
```

## Uso de Lambdas com `Func` e `Action`
C# **fornece delegados genéricos como `Func` e `Action` para simplificar a definição de lambdas.**
- `Func`: Representa um **método que retorna um valor.** Ele pode ter até 16 parâmetros de entrada.
- `Action`: Representa um **método que não retorna um valor.** Ele pode ter até 16 parâmetros de entrada.
```csharp
using System;

public class Program
{
    public static void Main()
    {
        // Usando Func para criar uma lambda que soma dois números
        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine($"Addition: {add(3, 4)}");

        // Usando Action para criar uma lambda que imprime uma mensagem
        Action<string> printMessage = message => Console.WriteLine(message);
        printMessage("Hello, Action!");
    }
}
```

# Uso de Lambdas com LINQ
Lambdas são amplamente utilizadas com LINQ para manipular coleções de dados de forma declarativa.
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Usando uma expressão lambda com LINQ para filtrar números
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

        // Usando uma expressão lambda com LINQ para transformar números
        var squares = numbers.Select(n => n * n).ToList();
        Console.WriteLine("Squares: " + string.Join(", ", squares));
    }
}
```

Lambdas em C# **são uma maneira poderosa e concisa de definir funções anônimas.** Elas são frequentemente **usadas com delegados, Func, Action, e LINQ para passar código como parâmetros de métodos, tornando o código mais legível e expressivo.** 