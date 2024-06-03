# Interfaces (IExemplo)
Interfaces em C# são um **componente fundamental da programação orientada a objetos, permitindo definir contratos que classes ou structs devem implementar.** Uma interface especifica um conjunto de métodos, propriedades, eventos ou indexadores que devem ser implementados, mas não fornece a implementação real desses membros. Isso **permite que diferentes classes implementem a interface de maneira específica, promovendo a reutilização de código e a flexibilidade.**

## Definindo uma Interface
Uma interface é definida usando a palavra-chave interface. Aqui está um exemplo básico de uma interface:
```csharp
public interface IShape
{
    double Area();
    double Perimeter();
}
```

## Implementando uma Interface
Uma classe ou struct que implementa uma interface deve fornecer implementações para todos os membros da interface:
```csharp
public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }

    public double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}

public class Rectangle : IShape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double Area()
    {
        return width * height;
    }

    public double Perimeter()
    {
        return 2 * (width + height);
    }
}
```

## Usando Interfaces
Interfaces **permitem que você escreva código que pode trabalhar com diferentes implementações de uma interface de maneira uniforme:**
```csharp
public class Program
{
    public static void Main()
    {
        IShape circle = new Circle(5);
        IShape rectangle = new Rectangle(4, 6);

        Console.WriteLine($"Circle Area: {circle.Area()}");
        Console.WriteLine($"Circle Perimeter: {circle.Perimeter()}");

        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");
        Console.WriteLine($"Rectangle Perimeter: {rectangle.Perimeter()}");
    }
}
```

### Interface vs Classe Abstrata
- **Interfaces:** Não podem conter implementação de métodos (a partir do C# 8.0, elas podem conter métodos padrão), não podem ter campos, e uma classe pode implementar múltiplas interfaces.
- **Classes Abstratas:** Podem conter implementação parcial de métodos, podem ter campos, e uma classe só pode herdar de uma única classe abstrata.

## Interfaces com Propriedades
Interfaces podem declarar propriedades, e as classes que implementam a interface devem fornecer as implementações dessas propriedades:
```csharp
public interface IPerson
{
    string Name { get; set; }
    int Age { get; set; }
}

public class Student : IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

## Interfaces com Eventos
Interfaces também podem declarar eventos:
```csharp
public interface INotifier
{
    event EventHandler NotificationReceived;
}

public class Notifier : INotifier
{
    public event EventHandler NotificationReceived;

    public void Notify()
    {
        NotificationReceived?.Invoke(this, EventArgs.Empty);
    }
}
```

# nterfaces Genéricas
Interfaces podem ser genéricas, permitindo maior flexibilidade e reutilização de código:
```csharp
public interface IRepository<T>
{
    void Add(T item);
    void Remove(T item);
    T Get(int id);
}

public class Repository<T> : IRepository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public T Get(int id)
    {
        return items[id];
    }
}
```

Interfaces em C# são uma **ferramenta poderosa para definir contratos de comportamento, promovendo a flexibilidade e a reutilização de código.** Elas permitem que **diferentes classes implementem comportamentos comuns de maneiras variadas, facilitando o uso de polimorfismo e abstração.**