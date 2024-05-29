# Funções (sintaxe)
Em C#, funções são blocos de código que realizam uma tarefa específica e podem ser chamados a partir de outras partes do programa. Também conhecidas como **métodos**, as funções em C# seguem uma sintaxe específica.

**Principais vantagens:**
- modularização
- delegação 
- reaproveitamento 

**Dados de entrada e saída:**
- Funções podem receber dados de entrada (parâmetros ou argumentos) 
- Funções podem ou não retornar uma saída 

**Sintaxe:**
```csharp
<modificador> <tipo-de-retorno> <nome-da-funcao>(<lista-de-parâmetros>) 
{
    // Corpo da função (bloco de código)
    // Executa a lógica da função
    // Pode conter declarações de variáveis, estruturas de controle, etc.
    // Retorno (se houver)
    return <valor-de-retorno>;
}
```

Aqui estão os componentes da sintaxe:
- `<modificador>`: Opcionalmente, você pode especificar um modificador de acesso como `public`, `private` ou `protected` para controlar a visibilidade da função.
- `<tipo-de-retorno>`: Especifica o tipo de dado que a função retorna. Pode ser um tipo primitivo (como `int`, `double`, `string`, etc.), um tipo personalizado (como uma `classe`), ou `void` **se a função não retornar um valor.**
- `<nome-da-funcao>`: O nome da função deve ser um identificador único que descreve a tarefa que ela realiza. Seguindo as convenções de nomenclatura, geralmente é em `camelCase`.
- `<lista-de-parâmetros>`: Especifica os parâmetros que a função recebe. Os parâmetros são variáveis ​​que permitem passar valores para a função. Cada parâmetro tem um tipo e um nome. Se a função não requer parâmetros, a lista de parâmetros estará vazia ou ausente.
- **Corpo da função:** O bloco de código dentro das chaves {} é onde você escreve a lógica da função. Pode conter declarações de variáveis, estruturas de controle (como if, for, while), chamadas de outras funções, etc.
- `return`: Se a função tiver um tipo de retorno diferente de `void`, você pode usar a instrução `return` para **especificar o valor a ser retornado pela função.**

**Exemplo:**
```csharp
public int Soma(int a, int b)
{
    int resultado = a + b;
    return resultado;
}
```

Neste exemplo, a função `Soma` tem dois parâmetros do tipo `int` e retorna um valor do tipo `int`. Dentro da função, é realizada a soma dos dois parâmetros e o resultado é retornado usando a instrução `return`.

