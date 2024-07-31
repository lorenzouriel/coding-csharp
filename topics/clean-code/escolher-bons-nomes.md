# Diretrizes Para Escolher Bons Nomes
**Escolher bons nomes é fundamental para escrever código limpo e legível.** Nomes claros e descritivos ajudam a entender a função e o propósito dos diferentes componentes do código. 

Aqui estão algumas diretrizes e dicas para escolher bons nomes em C# para:
- namespaces
- eventos 
- interfaces
- campos
- classes
- métodos
- parâmetros de métodos
- propriedades
- variáveis
- variáveis booleanas
- parâmetros de tipo genérico 
- enums

### Namespaces
- **Use nomes organizacionais e funcionais:** Inclua o nome da empresa ou projeto e o propósito do namespace.
- **Hierarquia clara:** Use hierarquias que façam sentido e que representem a estrutura do projeto.

**Exemplo:**
```csharp
namespace Company.Project.Feature
{
    // Classes e outros membros
}

namespace Company.Project.Library
{
    // Classes e outros membros
}

namespace Company.Project.Service
{
    // Classes e outros membros
}
```

### Eventos
- **Use o sufixo "Event":** Adicione "Event" ao final do nome do evento.
- **Descrição de ação:** O nome deve descrever claramente a ação que está ocorrendo.

**Exemplo:**
```csharp
public event EventHandler DataLoadedEvent;
```

### Interfaces
- **Prefixo "I":** Use o prefixo "I" para interfaces.
- **Descrição clara:** O nome deve descrever o comportamento ou capacidade.

**Exemplo:**
```csharp
public interface ILogger
{
    void Log(string message);
}
```

### Campos
- **CamelCase:** Use camelCase para campos privados.
**Nome descritivo:** O nome deve indicar claramente o propósito do campo.

**Exemplo:**
```csharp
private int userCount;
```

### Classes
- **PascalCase:** Use PascalCase para nomes de classes.
- **Nome singular:** Use nomes no singular para classes que representam uma entidade única.

**Exemplo:**
```csharp
public class Customer
{
    // Propriedades e métodos
}
```

### Métodos
- **Verbos:** Use verbos para métodos para descrever a ação que o método realiza.
- **PascalCase:** Use PascalCase para nomes de métodos.

**Exemplo:**
```csharp
public void SaveCustomer(Customer customer)
{
    // Lógica de salvamento
}
```

### Parâmetros de Métodos
- **camelCase:** Use camelCase para parâmetros de métodos.
- **Nome descritivo:** O nome deve indicar claramente o propósito do parâmetro.

**Exemplo:**
```csharp
public void AddItem(OrderItem item, int quantity)
{
    // Lógica de adição
}
```

### Propriedades
- **PascalCase:** Use PascalCase para nomes de propriedades.
- **Nome descritivo:** O nome deve indicar claramente o que a propriedade representa.

**Exemplo:**
```csharp
public string CustomerName { get; set; }
```

### Variáveis
- **camelCase:** Use camelCase para variáveis locais.
- **Nome descritivo:** O nome deve indicar claramente o propósito da variável.

**Exemplo:**
```csharp
int itemCount = 0;
```

### Variáveis Booleanas
- **Prefixo "`is`", "`has`", "`can`", etc.:** Use prefixos que indiquem claramente que a variável é booleana.
- **Nome descritivo:** O nome deve indicar claramente a condição que a variável representa.

**Exemplo:**
```csharp
bool isCompleted = false;
bool hasAccess = true;
```

### Parâmetros de Tipo Genérico
- **T como prefixo:** Use "T" como prefixo para parâmetros de tipo genérico.
- **Nome descritivo:** Use um nome que indique claramente o tipo ou propósito.

**Exemplo:**
```csharp
public class Repository<TEntity>
{
    // Métodos e propriedades
}
```

### Enums
- **PascalCase:** Use PascalCase para nomes de enums e seus valores.
- **Nome descritivo:** O nome deve indicar claramente o conjunto de valores que representa.

**Exemplo:**
```csharp
public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}
```

### Outras Dicas
- **Cuidado com Case Sensitive:** Não dependa da sensibilidade de maiúsculas e minúsculas do C# para diferenciar nomes de variáveis, pois isso pode causar confusão e erros no código.

- **Consistência nos Nomes:** Use convenções de nomenclatura consistentes para operações semelhantes (por exemplo, sempre use "open" em vez de misturar "open" e "load") para manter a clareza do código.

- **Evite Prefixos e Sufixos:** Não adicione prefixos ou sufixos desnecessários a propriedades ou métodos, pois isso dificulta a leitura e compreensão do código.

- **Nomes Descritivos e Significativos:** Use nomes claros e descritivos, sem abreviações, termos criptográficos ou nomes engraçados, para melhorar a legibilidade do código.

- **Termo Único para Conceito Único:** Use um único termo de forma consistente para um único conceito (por exemplo, não use "Instituto" e "Universidade" de forma intercambiável) para evitar confusões.