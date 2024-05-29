# Estrutura repetitiva `while` (ENQUANTO)
A estrutura repetitiva `while` em C# é usada para repetir um bloco de código enquanto uma condição especificada for verdadeira. 

**Sintaxe básica `while`:**
```csharp
while (condição)
{
    // Bloco de código a ser repetido enquanto a condição for verdadeira
}
```

**Como a estrutura while funciona:**
1. A expressão condição é avaliada antes de cada iteração do `loop`.
2. Se a condição for avaliada como verdadeira, o bloco de código dentro das chaves `{}` é executado.
3. Após a execução do bloco de código, a condição é verificada novamente. Se a condição ainda for verdadeira, o bloco de código é executado novamente. Esse processo continua até que a condição seja avaliada como falsa.
4. Se a condição for avaliada como falsa desde o início, o bloco de código não será executado e o `loop` não será percorrido.

**Exemplo simples que usa o `while` para imprimir os números de 1 a 5:**
```csharp
int contador = 1;
while (contador <= 5)
{
    Console.WriteLine(contador);
    contador++;
}
```
**Neste exemplo:**
- Uma variável `contador` é inicializada com o valor 1.
- A condição `contador <= 5` é verificada. Enquanto essa condição for verdadeira, o bloco de código dentro do `while` é executado.
- Dentro do `loop`, `Console.WriteLine(contador)` imprime o valor atual de contador.
- A instrução `contador++` incrementa o valor de contador em 1 após cada iteração.
- O `loop` continua até que contador seja maior que 5, momento em que a condição se torna falsa e a execução do `loop` é interrompida.

O uso do `while` é apropriado quando o número de iterações não é conhecido previamente e depende de uma condição específica para continuar.


