# Tratamento de Exceções
O tratamento de exceções em C# é uma parte crucial da programação para lidar com situações imprevistas e garantir que o programa não quebre de maneira incontrolável. O bloco `try-catch` é a estrutura principal para manipulação de exceções em C#.

**Estrutura Básica:**
```csharp
try {
    // Código que pode gerar uma exceção
}
catch (TipoDeExcecao ex) {
    // Tratamento da exceção
}
finally {
    // Código que será executado sempre, independentemente de ocorrer uma exceção ou não
}
```
- Você também pode criar suas próprias exceções personalizadas derivando da classe `Exception`.
- Você pode ter múltiplos blocos `catch` para lidar com diferentes tipos de exceções.
- A partir do C# 6, você pode usar uma cláusula when para adicionar condições ao bloco `catch`.

**Exemplo Básico:**
```csharp
try
{
    int[] numeros = { 1, 2, 3 };
    Console.WriteLine(numeros[5]); // Pode gerar uma exceção IndexOutOfRangeException
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Índice fora do intervalo: " + ex.Message);
}
finally
{
    Console.WriteLine("Bloco finally executado.");
}
```

**Exceções Personalizadas:**
Você também pode criar suas próprias exceções personalizadas derivando da classe `Exception`.
```csharp
public class MinhaExcecaoPersonalizada : Exception
{
    public MinhaExcecaoPersonalizada(string mensagem) : base(mensagem) { }
}

try
{
    throw new MinhaExcecaoPersonalizada("Ocorreu um erro personalizado");
}
catch (MinhaExcecaoPersonalizada ex)
{
    Console.WriteLine(ex.Message);
}
```

**Cláusula `when` no `catch`:**
A partir do C# 6, você pode usar uma cláusula `when` para adicionar condições ao bloco `catch`.
```csharp
try
{
    // Código que pode gerar uma exceção
}
catch (Exception ex) when (ex.Message.Contains("alguma condição"))
{
    // Tratamento específico quando a condição é atendida
    Console.WriteLine("Exceção capturada com condição: " + ex.Message);
}
```

**Exemplo Completo com Múltiplos `catch`:**
```csharp
try
{
    int a = 10, b = 0;
    int resultado = a / b; // Pode gerar uma exceção DivideByZeroException
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Erro: Divisão por zero.");
}
catch (Exception ex)
{
    Console.WriteLine("Erro genérico: " + ex.Message);
}
finally
{
    Console.WriteLine("Execução do bloco finally.");
}
```

**Benefícios do Tratamento de Exceções**
- **Robustez:** O programa pode continuar executando mesmo quando ocorre um erro.
- **Depuração:** Facilita a identificação e correção de problemas.
- **Recursos:** Garante a liberação adequada de recursos.