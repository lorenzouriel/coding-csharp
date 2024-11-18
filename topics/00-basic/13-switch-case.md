# Switch Case

A estrutura de controle `switch-case` em C# é usada para executar diferentes ações com base no valor de uma expressão. Ela oferece uma alternativa mais clara e legível do que uma série de declarações `if-else` aninhadas quando você precisa tomar decisões com base em um valor específico.

Aqui está a sintaxe básica do `switch-case`:
```csharp
switch (expressao)
{
    case valor1:
        // Código a ser executado se expressao for igual a valor1
        break;
    case valor2:
        // Código a ser executado se expressao for igual a valor2
        break;
    // ...
    default:
        // Código a ser executado se nenhum caso corresponder à expressao
        break;
}
```

Aqui estão mais exemplos para ilustrar o uso do `switch-case` em C#:

**Operações Matemáticas:**
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o primeiro número:");
        double num1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Digite o operador (+, -, *, /):");
        char operador = Console.ReadLine()[0];

        Console.WriteLine("Digite o segundo número:");
        double num2 = double.Parse(Console.ReadLine());

        switch (operador)
        {
            case '+':
                Console.WriteLine($"Resultado: {num1 + num2}");
                break;
            case '-':
                Console.WriteLine($"Resultado: {num1 - num2}");
                break;
            case '*':
                Console.WriteLine($"Resultado: {num1 * num2}");
                break;
            case '/':
                if (num2 != 0)
                    Console.WriteLine($"Resultado: {num1 / num2}");
                else
                    Console.WriteLine("Erro: Divisão por zero!");
                break;
            default:
                Console.WriteLine("Operador inválido!");
                break;
        }
    }
}
```


**Configurações de Usuário:**
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Escolha uma opção de configuração:");
        Console.WriteLine("1 - Alterar senha");
        Console.WriteLine("2 - Ajustar volume");
        Console.WriteLine("3 - Atualizar perfil");
        Console.WriteLine("4 - Sair");
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Console.WriteLine("Senha alterada com sucesso!");
                break;
            case 2:
                Console.WriteLine("Volume ajustado!");
                break;
            case 3:
                Console.WriteLine("Perfil atualizado!");
                break;
            case 4:
                Console.WriteLine("Saindo do programa...");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
}
```

**Expressão switch (Introduzida no C# 8.0):**
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um número (1-4) para uma estação do ano:");
        int estacao = int.Parse(Console.ReadLine());

        string resultado = estacao switch
        {
            1 => "Primavera",
            2 => "Verão",
            3 => "Outono",
            4 => "Inverno",
            _ => "Valor inválido!"
        };

        Console.WriteLine($"Estação: {resultado}");
    }
}
```