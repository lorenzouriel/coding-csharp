# Estrutura condicional `if-else`
Em C#, a estrutura condicional if-else é usada para executar diferentes blocos de código com base em certas condições. Aqui está uma visão geral de como usar `if`, `else if`, e `else` em C#:

**Estrutura Básica do `if-else`:**
```csharp
if (condicao) 
{
    // Bloco de código a ser executado se a condição for verdadeira
}
else 
{
    // Bloco de código a ser executado se a condição for falsa
}
```

**Exemplo com `if-else`:**
```csharp
int numero = 10;

if (numero > 0) 
{
    Console.WriteLine("O número é positivo.");
} 
else 
{
    Console.WriteLine("O número não é positivo.");
}
```

**Estrutura com `else if`:**
```csharp
if (condicao1) 
{
    // Bloco de código a ser executado se a condição1 for verdadeira
} 
else if (condicao2) 
{
    // Bloco de código a ser executado se a condição2 for verdadeira
} 
else 
{
    // Bloco de código a ser executado se nenhuma das condições for verdadeira
}
```

**Exemplo com `else if`:**
```csharp
int numero = 0;

if (numero > 0) 
{
    Console.WriteLine("O número é positivo.");
} 
else if (numero < 0) 
{
    Console.WriteLine("O número é negativo.");
} 
else 
{
    Console.WriteLine("O número é zero.");
}
```

**Aninhamento de Estruturas Condicionais:**
Você pode aninhar estruturas condicionais dentro de outras estruturas condicionais
```csharp
int a = 5;
int b = 10;

if (a > 0) 
{
    if (b > 0) 
    {
        Console.WriteLine("Ambos os números são positivos.");
    } 
    else 
    {
        Console.WriteLine("a é positivo, mas b não é positivo.");
    }
} 
else 
{
    Console.WriteLine("a não é positivo.");
}
```

**Expressão condicional ternária:**
Estrutura opcional ao `if-else` quando se deseja decidir um VALOR com base em uma condição.

```csharp
// Sintaxe
variavel = (condicao) ? valor_se_verdadeiro : valor_se_falso;

// Exemplo
int idade = 20;
string mensagem = (idade >= 18) ? "Maior de idade" : "Menor de idade";
Console.WriteLine(mensagem); // Saída: "Maior de idade"
```