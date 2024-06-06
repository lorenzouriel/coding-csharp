# Entity Framework

O **Entity Framework (EF)** é um **framework de mapeamento objeto-relacional (ORM) desenvolvido pela Microsoft para a plataforma .NET.** Ele permite que os desenvolvedores trabalhem com dados relacionais usando objetos .NET, eliminando a necessidade de grande parte do código de acesso a dados que os desenvolvedores normalmente precisariam escrever.

### Principais Abordagens do Entity Framework
- **Database First:** Começa com um banco de dados existente e gera classes de entidade e contexto.
- **Model First:** Começa com um modelo de dados (design de esquema) e gera o banco de dados e classes de entidade.
- **Code First:** Começa com classes de entidade e gera o banco de dados.

### Instalação do Entity Framework
Antes de começar, você precisa instalar o pacote do Entity Framework via NuGet. Abra o Package Manager Console e execute o seguinte comando:
```shell
Install-Package EntityFramework
```

### Exemplo de Code First
**1. Defina as Classes de Entidade**
As classes de entidade são representações das tabelas do banco de dados. Aqui está um exemplo de como definir duas classes de entidade: `Customer` e `Order`.
```csharp
public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
```

**2. Defina a Classe DbContext**
A classe `DbContext` gerencia as entidades e as interações com o banco de dados.
```csharp
public class MyDatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public MyDatabaseContext() : base("name=MyDatabaseContext")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configurações adicionais do modelo
        base.OnModelCreating(modelBuilder);
    }
}
```

**3. Configure a String de Conexão**
No arquivo `App.config` ou `Web.config`, adicione a string de conexão que o `DbContext` usará para conectar ao banco de dados.
```csharp
<connectionStrings>
    <add name="MyDatabaseContext" connectionString="Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

**4. Execute as Migrações para Criar o Banco de Dados**
Use o console do Gerenciador de Pacotes NuGet para habilitar migrações e criar o banco de dados.

- Habilitar migrações:
```shell
Enable-Migrations
```

- Adicionar uma migração inicial:
```shell
Add-Migration InitialCreate
```

- Atualizar o banco de dados:
```shell
Update-Database
```

### Operações CRUD
Agora você pode usar o DbContext para realizar operações de Create, Read, Update e Delete.

**Exemplo de uso:**
```csharp
using (var context = new MyDatabaseContext())
{
    // Criar um novo cliente
    var customer = new Customer
    {
        Name = "John Doe",
        Email = "john.doe@example.com"
    };
    context.Customers.Add(customer);
    context.SaveChanges();

    // Consultar clientes
    var customers = context.Customers.ToList();

    // Atualizar um cliente
    var existingCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
    if (existingCustomer != null)
    {
        existingCustomer.Name = "Jane Doe";
        context.SaveChanges();
    }

    // Excluir um cliente
    context.Customers.Remove(existingCustomer);
    context.SaveChanges();
}
```

### Configurações Avançadas - Fluent API**
A Fluent API é usada para configurar o modelo de dados no EF. Você pode usar a **Fluent API** no método `OnModelCreating` do `DbContext` para definir configurações como mapeamentos de tabelas, chaves primárias e estrangeiras, etc.

**Exemplo:**
```csharp
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    modelBuilder.Entity<Customer>()
        .HasKey(c => c.CustomerId);

    modelBuilder.Entity<Order>()
        .HasKey(o => o.OrderId);

    modelBuilder.Entity<Order>()
        .HasRequired(o => o.Customer)
        .WithMany(c => c.Orders)
        .HasForeignKey(o => o.CustomerId);

    base.OnModelCreating(modelBuilder);
}
```

### Configurações Avançadas - Data Annotations
Além da Fluent API, você também pode usar Data Annotations para configurar o modelo. As **Data Annotations são atributos que você adiciona às propriedades das classes de entidade.**

**Exemplo:**
```csharp
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
```

O Entity Framework facilita o trabalho com bancos de dados em aplicações .NET, permitindo aos desenvolvedores interagir com dados usando objetos .NET.
- **A abordagem Code First é particularmente útil para começar com o modelo de domínio e gerar o esquema do banco de dados.** 

Com as ferramentas e práticas discutidas, você pode configurar e utilizar o Entity Framework de maneira eficaz em seus projetos.