# Null Check Validation
A validação de nulos é uma prática comum em C# para garantir que variáveis, parâmetros e propriedades não sejam nulos antes de realizar operações com eles. Isso ajuda a prevenir `NullReferenceException` e manter o código robusto e sem erros. Abaixo estão vários métodos para realizar a validação de nulos em C#:

### Verificação Básica de Nulo
A maneira mais simples de verificar se é nulo é usando uma instrução `if`:
```csharp
if (algumObjeto == null)
{
    throw new ArgumentNullException(nameof(algumObjeto), "O parâmetro não pode ser nulo");
}
```

### Usando o Operador Null-Conditional
Para propriedades ou métodos, você pode usar o operador **null-conditional** `?`. para acessar membros de forma segura:
```csharp
var comprimento = algumObjeto?.Propriedade.Length;
```
- Isso retorna `null` se `algumObjeto` for `null`, em vez de lançar uma exceção.

### Operador de Coalescência Nula
Você pode usar o operador de **coalescência nula** `??` para fornecer um valor padrão quando o objeto for nulo:
```csharp
var valor = algumObjeto ?? valorPadrao;

var valor = nome ?? string.Empty();
```

### ArgumentNullException em Parâmetros de Método
É uma boa prática validar os parâmetros do método no início de um método:
```csharp
public void AlgumMetodo(AlgumTipo algumParametro)
{
    if (algumParametro == null)
    {
        throw new ArgumentNullException(nameof(algumParametro));
    }
    // Implementação do método
}
```

### Tipos de Referência Nulos no C# 8.0
O C# 8.0 introduziu tipos de referência nulos, permitindo especificar se uma variável de tipo de referência pode ser nula. Para habilitar tipos de referência nulos, adicione o seguinte ao seu arquivo `.csproj`:
```xml
<Nullable>enable</Nullable>
```

Depois, use `?` para indicar que um tipo pode ser nulo:
```csharp
string? stringNula = null; // String nula
string stringNaoNula = "Olá"; // String não nula
```

O compilador fornecerá avisos quando um tipo nulo for desreferenciado sem uma verificação de nulo.

### Usando is com Pattern Matching
O pattern matching com `is` pode ser usado para verificações de nulo:
```csharp
if (algumObjeto is null)
{
    // Tratar o caso de nulo
}
```

### Usando Clauses de Guarda
Usar clauses de guarda ajuda a manter o código limpo e garantir que as verificações de nulo sejam feitas no início:
```csharp
public void AlgumMetodo(AlgumTipo algumParametro)
{
    _ = algumParametro ?? throw new ArgumentNullException(nameof(algumParametro));
    // Implementação do método
}
```

### Exemplo de Validação de Nulo em uma Classe
Aqui está um exemplo de uma classe com validação de nulo:
```csharp
public class ExemploClasse
{
    private readonly string _nome;

    public ExemploClasse(string nome)
    {
        _nome = nome ?? throw new ArgumentNullException(nameof(nome), "O nome não pode ser nulo");
    }

    public void ImprimirNome()
    {
        if (_nome == null)
        {
            throw new InvalidOperationException("O nome não pode ser nulo");
        }

        Console.WriteLine(_nome);
    }
}
```