# Strings

O `String` em C# é uma classe da biblioteca base do .NET que representa uma sequência imutável de caracteres. Isso significa que, uma vez criada, o conteúdo de uma string não pode ser alterado diretamente. Sempre que você modifica uma string, uma nova instância é criada na memória.

## Características do `String` em C#:

1. **Imutabilidade:** Strings são imutáveis, ou seja, qualquer operação que aparentemente modifica o conteúdo de uma string (como concatenar ou substituir caracteres) na verdade cria uma nova string.
```csharp
string original = "Olá";
string modificado = original + " Mundo"; // Cria uma nova string
Console.WriteLine(original); // Saída: "Olá"
```

2. **Classe de Alto Nível:** A classe `String` fornece métodos e propriedades para manipular textos, como busca, substituição, divisão e formatação.

3. **Namespace:** A classe String pertence ao namespace `System`.

4. **Operações Comuns:**
    - Comparação (`==`, `.Equals()`)
    - Concatenação (`+`, `.Concat()`)
    - Substring (`.Substring()`)

5. **Strings Literais:** Strings são representadas por aspas duplas (`"`).
```csharp
string saudacao = "Olá, mundo!";
```

6. **Verificação de Null e Vazio:**
    - Strings podem conter valores null ou estar vazias (`""`).
    - Para verificar se uma string é nula ou vazia, usamos: `if (String.IsNullOrEmpty(minhaString)) { ... }`

## Declaração de `Strings` em C#
Existem duas formas de declarar uma string em C#:

1. Com a palavra-chave `string` (minúscula)
```csharp
string texto = "Exemplo de texto";
```

2. Com a classe `System.String` (maiúscula)
```csharp
System.String texto = "Exemplo de texto";
```

Essas duas formas são equivalentes, já que `string` é apenas um alias para `System.String`.

## `String` vs `StringBuilder`
Se você precisa manipular textos extensivamente (como concatenar muitas vezes), é mais eficiente usar a classe `StringBuilder`, pois ela é mutável.
```csharp
using System.Text;

StringBuilder sb = new StringBuilder("Olá");
sb.Append(" Mundo");
Console.WriteLine(sb.ToString()); // Saída: "Olá Mundo"
```

A diferença principal é que `StringBuilder` modifica o texto na mesma instância, enquanto `String` cria novas instâncias a cada alteração.

## Funções Interessantes para `Strings` em C#

### Formatação
- `ToLower()`: Converte todos os caracteres da string para minúsculas.
- `ToUpper()`: Converte todos os caracteres da string para maiúsculas.
- `Trim()`: Remove todos os espaços em branco no início e no fim da string.

### Busca
- `IndexOf(valor)`: Retorna o índice da primeira ocorrência de um valor.
- `LastIndexOf(valor)`: Retorna o índice da última ocorrência de um valor.

### Recorte
- `Substring(início)`: Retorna a substring a partir de um índice específico.
- `Substring(início, tamanho)`: Retorna uma substring com um tamanho específico a partir de um índice inicial.

### Substituição
- `Replace(caractereAntigo, caractereNovo)`: Substitui todas as ocorrências de um caractere por outro.
- `Replace(stringAntiga, stringNova)`: Substitui todas as ocorrências de uma string por outra.

### Validação
- `String.IsNullOrEmpty(string)`: Verifica se a string é nula ou está vazia.
- `String.IsNullOrWhiteSpace(string)`: Verifica se a string é nula, está vazia ou contém apenas espaços em branco.

### Divisão
- `Split('caractere')`: Divide a string em partes com base no caractere delimitador fornecido e retorna um array.

### Conversão para Número
- `int.Parse(string)`: Converte uma string para um inteiro.
- `Convert.ToInt32(string)`: Converte uma string para um inteiro, com tratamento adicional para valores nulos.

### Conversão de Número para String
- `x.ToString()`: Converte um número para string.
- `x.ToString("C")`: Formata o número como moeda.
- `x.ToString("F2")`: Formata o número com duas casas decimais.
- `x.ToString("C3")`: Formata o número como moeda com três casas decimais.