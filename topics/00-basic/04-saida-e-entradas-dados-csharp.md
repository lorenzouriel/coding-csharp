# Saída e Entrada de Dados em C#

## Saída de dados em C#
Para realizar a saída de dados, você pode utilizar o `Console.WriteLine`

**Exemplo:**
```csharp
string nome = "Alice";
int idade = 25;
Console.WriteLine("Olá, meu nome é {0} e tenho {1} anos.", nome, idade);
```
- Este código irá exibir a mensagem formatada com os valores das variáveis `nome` e `idade`.

## Entrada de dados em C#
você pode ler dados de entrada do usuário por meio do console usando a classe `Console`.
```csharp
string input = Console.ReadLine();

int number = Convert.ToInt32(Console.ReadLine());

double number = Convert.ToDouble(Console.ReadLine());

char character = Console.ReadKey().KeyChar;
```

Esse código irá ler uma linha de texto digitada pelo usuário e armazená-la na variável `input` como uma string.

**Exemplo de entrada e saída com vetor:**
- ![entrada-e-saida-com-vetor](/images/entrada-e-saida-com-vetor.png)


**Como funciona o split de um vetor?**
- ![split_vetor](/images/split_vetor.png)

