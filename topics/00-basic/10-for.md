# Estrutura repetitiva `for` (PARA)
A estrutura repetitiva `for` em C# é usada para repetir um bloco de código um número específico de vezes. É particularmente útil quando o número de iterações é conhecido previamente.

**Sintaxe Básica do `for`:**
```csharp
for (inicialização; condição; incremento/decremento)
{
    // Bloco de código a ser repetido enquanto a condição for verdadeira
}
```

**Funcionamento da Estrutura `for`:**
1. **Inicialização:** Executada uma única vez no início do loop. É usada para definir e inicializar variáveis de controle.
2. **Condição:** Avaliada antes de cada iteração do `loop`. Se a condição for verdadeira, o bloco de código dentro das chaves `{}` é executado. Se a condição for falsa, o `loop` termina.
3. **Incremento/Decremento:** Executado após cada iteração do `loop`. É usado para atualizar a variável de controle.

**Exemplo de Uso do `for`:**
Aqui está um exemplo simples que usa o for para imprimir os números de 1 a 5.
```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

**Neste exemplo:**
- **Inicialização:** `int i = 1`; define a variável `i` e a inicializa com o valor `1`.
- **Condição:** `i <= 5`; verifica se `i` é menor ou igual a 5 antes de cada iteração. Se a condição for verdadeira, o `loop` continua; se for falsa, o `loop` termina.
- **Incremento:** `i++` incrementa o valor de `i` em 1 após cada iteração.

**Exemplo de Loop com Decremento:**
O for também pode ser usado para loops de decremento. Aqui está um exemplo que imprime os números de 5 a 1.
```csharp
for (int i = 5; i >= 1; i--)
{
    Console.WriteLine(i);
}
```

**Neste exemplo:**
- **Inicialização:** `int i = 5`; define a variável `i` e a inicializa com o valor 5.
- **Condição:** `i >= 1`; verifica se `i` é maior ou igual a 1 antes de cada iteração.
- **Decremento:** `i--` decrementa o valor de i em 1 após cada iteração.

