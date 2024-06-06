# Events (Eventos)
Eventos em C# são **uma maneira poderosa e flexível de implementar o padrão de design observador, permitindo que uma classe (o "publicador") notifique outras classes (os "assinantes") sobre alterações em seu estado ou outras ocorrências significativas.** 

Eventos são **baseados em delegados e são amplamente utilizados em programação de interface gráfica e em sistemas baseados em eventos.**

## Conceitos Básicos de Eventos
- **Declaração de um Evento:** Um evento é declarado em uma classe e associado a um tipo de *delegate*.
- **Assinatura de um Evento:** Outras classes podem se inscrever para ouvir eventos, adicionando seus métodos de manipulação ao evento.
- **Disparo de um Evento:** O evento é disparado na classe publicadora, notificando todos os assinantes.

## Exemplo Completo
Aqui está um exemplo básico que demonstra como declarar, assinar e disparar eventos em C#.
```csharp
using System;

public class Program
{
    // Declaração de um delegate que define a assinatura dos métodos manipuladores de eventos
    public delegate void EventHandler(string message);

    // Declaração de um evento baseado no delegate
    public event EventHandler MyEvent;

    public static void Main()
    {
        Program p = new Program();

        // Assinatura do evento com métodos manipuladores
        p.MyEvent += Handler1;
        p.MyEvent += Handler2;

        // Disparo do evento
        p.RaiseEvent("Hello, Events!");

        // Desassinar um método do evento
        p.MyEvent -= Handler1;

        // Disparo do evento novamente
        p.RaiseEvent("Hello, Events after unsubscribe!");
    }

    // Método para disparar o evento
    public void RaiseEvent(string message)
    {
        // Verificação de null para garantir que há assinantes
        MyEvent?.Invoke(message);
    }

    // Métodos manipuladores de eventos
    public static void Handler1(string message)
    {
        Console.WriteLine($"Handler1 received: {message}");
    }

    public static void Handler2(string message)
    {
        Console.WriteLine($"Handler2 received: {message}");
    }
}
```

## Usando `EventHandler` Predefinido
C# fornece um delegate predefinido chamado `EventHandler` (e `EventHandler<TEventArgs>` para eventos com dados), o que simplifica a declaração de eventos.
```csharp
using System;

public class Program
{
    // Declaração de um evento usando o delegate predefinido EventHandler
    public event EventHandler MyEvent;

    public static void Main()
    {
        Program p = new Program();

        // Assinatura do evento com métodos manipuladores
        p.MyEvent += OnMyEvent;

        // Disparo do evento
        p.RaiseEvent(EventArgs.Empty);

        // Desassinar um método do evento
        p.MyEvent -= OnMyEvent;

        // Disparo do evento novamente
        p.RaiseEvent(EventArgs.Empty);
    }

    // Método para disparar o evento
    public void RaiseEvent(EventArgs e)
    {
        // Verificação de null para garantir que há assinantes
        MyEvent?.Invoke(this, e);
    }

    // Método manipulador de eventos
    public static void OnMyEvent(object sender, EventArgs e)
    {
        Console.WriteLine("Event received!");
    }
}
```

## Usando `EventHandler<TEventArgs>`
Para eventos que transportam dados adicionais, podemos usar `EventHandler<TEventArgs>` e criar uma classe que derive de `EventArgs`.
```csharp
using System;

public class Program
{
    // Declaração de um evento usando o delegate predefinido EventHandler<TEventArgs>
    public event EventHandler<MyEventArgs> MyEvent;

    public static void Main()
    {
        Program p = new Program();

        // Assinatura do evento com métodos manipuladores
        p.MyEvent += OnMyEvent;

        // Disparo do evento
        p.RaiseEvent(new MyEventArgs("Hello, EventArgs!"));

        // Desassinar um método do evento
        p.MyEvent -= OnMyEvent;

        // Disparo do evento novamente
        p.RaiseEvent(new MyEventArgs("Hello again, EventArgs!"));
    }

    // Método para disparar o evento
    public void RaiseEvent(MyEventArgs e)
    {
        // Verificação de null para garantir que há assinantes
        MyEvent?.Invoke(this, e);
    }

    // Método manipulador de eventos
    public static void OnMyEvent(object sender, MyEventArgs e)
    {
        Console.WriteLine($"Event received with message: {e.Message}");
    }
}

// Classe que deriva de EventArgs para transportar dados do evento
public class MyEventArgs : EventArgs
{
    public string Message { get; }

    public MyEventArgs(string message)
    {
        Message = message;
    }
}
```

Eventos em C# fornecem uma **maneira robusta de implementar comunicação entre objetos.** Usando **delegados, `EventHandler` e `EventHandler<TEventArgs>`, é possível criar eventos personalizados que notificam assinantes sobre mudanças de estado ou outras ocorrências.** 

Esses conceitos são fundamentais para a programação orientada a eventos, especialmente em aplicações com interfaces gráficas e sistemas assíncronos.