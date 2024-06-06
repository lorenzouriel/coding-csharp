# Comandos XML
Eles permitem que você forneça descrições detalhadas de classes, métodos, propriedades, parâmetros e retornos, e essas descrições podem ser utilizadas por ferramentas de documentação, como o Sandcastle, ou aparecer no IntelliSense do Visual Studio, ajudando outros desenvolvedores a entenderem melhor como usar seu código.

Aqui estão alguns comandos XML comuns e exemplos de como usá-los:

### `<summary>`
Este comando é usado para fornecer uma descrição resumida de um membro (classe, método, propriedade, etc.).

**Exemplo:**
```csharp
/// <summary>
/// Esta classe representa um cliente.
/// </summary>
public class Customer
{
    // ...
}

/// <summary>
/// Calcula a média ponderada dos resultados.
/// </summary>
/// <param name="results">Lista de resultados com pesos.</param>
/// <returns>A média ponderada.</returns>
public double CalculateWeightedAverage(List<Result> results)
{
    double weightedAverage = 0;
    foreach (var result in results)
    {
        weightedAverage += result.Score * result.Weight;
    }
    return weightedAverage / results.Sum(r => r.Weight);
}
```

### `<param>`
Usado para descrever um parâmetro de um método.

**Exemplo:**
```csharp
/// <summary>
/// Adiciona um item ao pedido.
/// </summary>
/// <param name="item">O item a ser adicionado.</param>
/// <param name="quantity">A quantidade do item.</param>
public void AddItem(OrderItem item, int quantity)
{
    // ...
}
```

### `<returns>`
Usado para descrever o valor de retorno de um método.

**Exemplo:**
```csharp
/// <summary>
/// Calcula o total do pedido.
/// </summary>
/// <returns>O valor total do pedido.</returns>
public decimal CalculateTotal()
{
    // ...
}
```

### `<remarks>`
Usado para adicionar informações adicionais sobre um membro.

**Exemplo:**
```csharp
/// <summary>
/// Cancela o pedido.
/// </summary>
/// <remarks>
/// Este método lança uma exceção se o pedido já foi enviado.
/// </remarks>
public void CancelOrder()
{
    // ...
}
```

### `<exception>`
Usado para documentar as exceções que um método pode lançar.

**Exemplo:**
```csharp
/// <summary>
/// Processa o pagamento.
/// </summary>
/// <param name="amount">O valor a ser pago.</param>
/// <exception cref="InvalidOperationException">Lançada se o pagamento falhar.</exception>
public void ProcessPayment(decimal amount)
{
    // ...
}
```

### `<example>`
Fornece um exemplo de uso do membro.

**Exemplo:**
```csharp
/// <summary>
/// Adiciona um item ao pedido.
/// </summary>
/// <param name="item">O item a ser adicionado.</param>
/// <param name="quantity">A quantidade do item.</param>
/// <example>
/// <code>
/// var order = new Order();
/// var item = new OrderItem("Produto A", 10);
/// order.AddItem(item, 2);
/// </code>
/// </example>
public void AddItem(OrderItem item, int quantity)
{
    // ...
}
```

### `<value>`
Usado para documentar a descrição de uma propriedade.

**Exemplo:**
```csharp
/// <summary>
/// Obtém ou define o nome do cliente.
/// </summary>
/// <value>
/// O nome do cliente.
/// </value>
public string Name { get; set; }
```

### `<typeparam>`
Usado para descrever um parâmetro de tipo genérico em métodos ou classes genéricas.

**Exemplo:**
```csharp
/// <summary>
/// Representa uma lista genérica.
/// </summary>
/// <typeparam name="T">O tipo de elementos na lista.</typeparam>
public class MyList<T>
{
    // ...
}
```

### `<see>` e `<seealso>`
Usado para criar referências cruzadas a outros membros.

**Exemplo:**
```csharp
/// <summary>
/// Calcula a média ponderada dos resultados.
/// </summary>
/// <param name="results">Lista de resultados com pesos.</param>
/// <returns>A média ponderada.</returns>
/// <seealso cref="Result"/>
public double CalculateWeightedAverage(List<Result> results)
{
    // ...
}
```

### Exemplo Completo
Aqui está um exemplo completo de uma classe com documentação XML abrangente:
```csharp
/// <summary>
/// Representa um pedido de cliente.
/// </summary>
public class Order
{
    /// <summary>
    /// Obtém ou define o identificador do pedido.
    /// </summary>
    /// <value>
    /// O identificador do pedido.
    /// </value>
    public int OrderId { get; set; }

    /// <summary>
    /// Obtém ou define a lista de itens do pedido.
    /// </summary>
    /// <value>
    /// A lista de itens do pedido.
    /// </value>
    public List<OrderItem> Items { get; set; }

    /// <summary>
    /// Adiciona um item ao pedido.
    /// </summary>
    /// <param name="item">O item a ser adicionado.</param>
    /// <param name="quantity">A quantidade do item.</param>
    /// <exception cref="ArgumentException">Lançada se a quantidade for menor ou igual a zero.</exception>
    /// <example>
    /// <code>
    /// var order = new Order();
    /// var item = new OrderItem("Produto A", 10);
    /// order.AddItem(item, 2);
    /// </code>
    /// </example>
    public void AddItem(OrderItem item, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        }
        // Adiciona o item ao pedido
        Items.Add(item);
    }

    /// <summary>
    /// Calcula o total do pedido.
    /// </summary>
    /// <returns>O valor total do pedido.</returns>
    public decimal CalculateTotal()
    {
        return Items.Sum(item => item.Price * item.Quantity);
    }
}
```