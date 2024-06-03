# Delegates
Delegates são **tipos que representam referências a métodos com uma *assinatura específica em C#*.** Eles permitem que **métodos sejam passados como parâmetros e sejam chamados de forma assíncrona.** 

Delegates são essenciais para **implementar callbacks e são amplamente utilizados em eventos e programação assíncrona.**

## Declaração e Uso de Delegates
**1. Declaração de um Delegate:**
Um delegate é **declarado usando a palavra-chave delegate seguida pela assinatura do método que ele pode referenciar.**
```csharp
public delegate void MyDelegate(string message);
```

**2. Instanciação de um Delegate:**
Uma instância de um delegate é criada apontando para um método específico.
```csharp
MyDelegate del = new MyDelegate(MyMethod);
```

**3. Chamada de um Delegate:**
O delegate pode ser invocado da mesma forma que o método que ele referencia.
```csharp
del("Hello, Delegate!");
```

## Exemplo Completo
Aqui está um exemplo completo que demonstra como declarar, instanciar e usar um delegate em C#.
```csharp
using System;

public class Program
{
    // Declaração de um delegate
    public delegate void MyDelegate(string message);

    public static void Main()
    {
        // Instanciação do delegate apontando para um método específico
        MyDelegate del = new MyDelegate(MyMethod);
        
        // Chamada do delegate
        del("Hello, Delegate!");

        // Também é possível usar uma expressão lambda
        MyDelegate delLambda = message => Console.WriteLine($"Lambda received: {message}");
        delLambda("Hello, Lambda!");
    }

    // Método que corresponde à assinatura do delegate
    public static void MyMethod(string message)
    {
        Console.WriteLine($"MyMethod received: {message}");
    }
}
```

## Multicast Delegates
Delegates em C# são multicast, o que significa que eles podem referenciar mais de um método. **Quando o delegate é chamado, todos os métodos que ele referencia são invocados.**
```csharp
using System;

public class Program
{
    // Declaração de um delegate
    public delegate void MyDelegate(string message);

    public static void Main()
    {
        // Instanciação de delegates
        MyDelegate del1 = new MyDelegate(MyMethod1);
        MyDelegate del2 = new MyDelegate(MyMethod2);

        // Combinação de delegates
        MyDelegate combinedDel = del1 + del2;

        // Chamada do delegate combinado
        combinedDel("Hello, Multicast Delegate!");
    }

    public static void MyMethod1(string message)
    {
        Console.WriteLine($"MyMethod1 received: {message}");
    }

    public static void MyMethod2(string message)
    {
        Console.WriteLine($"MyMethod2 received: {message}");
    }
}
```

## Delegates Genéricos
C# fornece delegados genéricos predefinidos `Func` e `Action`, que são **muito úteis para evitar a necessidade de declarar delegados personalizados.**
- `Action`: Representa um método que não retorna um valor.
- `Func`: Representa um método que retorna um valor.
```csharp
using System;

public class Program
{
    public static void Main()
    {
        // Usando Action para um método que não retorna valor
        Action<string> action = message => Console.WriteLine($"Action received: {message}");
        action("Hello, Action!");

        // Usando Func para um método que retorna um valor
        Func<int, int, int> func = (a, b) => a + b;
        int result = func(3, 4);
        Console.WriteLine($"Func result: {result}");
    }
}
```

Delegates são uma característica poderosa de C# que permite a criação de referências a métodos e a execução de métodos de forma flexível. Eles são **essenciais para a implementação de callbacks, manipulação de eventos e execução assíncrona.** Com o uso de delegates genéricos como `Func` e `Action`, o código se torna mais conciso e legível.
