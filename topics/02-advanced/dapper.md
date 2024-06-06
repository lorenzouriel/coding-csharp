# Dapper
**Dapper é um micro ORM (Object-Relational Mapper) para .NET**, que fornece uma maneira simples e eficiente de realizar operações de banco de dados em C#. Ele é conhecido por seu desempenho rápido e uso intuitivo. Abaixo estão algumas orientações sobre como usar Dapper em C#.

### Instalação
Para instalar Dapper, você pode usar o **NuGet Package Manager.** Execute o seguinte comando no Package Manager Console:
```shell
Install-Package Dapper
```

### Uso Básico de Dapper
**1. Configuração da Conexão:** Você precisa de uma conexão com o banco de dados. Normalmente, isso é feito usando `SqlConnection` da biblioteca `System.Data.SqlClient`.

**2. Operações CRUD (Create, Read, Update, Delete):** Aqui estão exemplos de como realizar operações CRUD usando Dapper.

**Conexão com o Banco de Dados**
```csharp
using System.Data.SqlClient;
using Dapper;

string connectionString = "your_connection_string_here";
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    // Suas operações com Dapper aqui
}
```

**SELECT (Read)**
- Para ler dados do banco de dados, você pode usar o método Query de Dapper, que retorna uma coleção de objetos.
```csharp
public IEnumerable<Produto> GetProdutos()
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string sql = "SELECT * FROM Produtos";
        var produtos = connection.Query<Produto>(sql);
        return produtos;
    }
}
```

**INSERT (Create)**
- Para inserir dados, use o método Execute de Dapper.
```csharp
public void AddProduto(Produto produto)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string sql = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
        connection.Execute(sql, new { produto.Nome, produto.Preco });
    }
}
```

**UPDATE**
- Para atualizar dados, também use o método `Execute`.
```csharp
public void UpdateProduto(Produto produto)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco WHERE Id = @Id";
        connection.Execute(sql, new { produto.Nome, produto.Preco, produto.Id });
    }
}
```

**DELETE**
- Para deletar dados, use o método `Execute`.
```csharp
public void DeleteProduto(int id)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string sql = "DELETE FROM Produtos WHERE Id = @Id";
        connection.Execute(sql, new { Id = id });
    }
}
```

### Exemplo Completo
Vamos juntar tudo em um exemplo completo:
```csharp
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

// Models > Produto.cs
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

// Data > ProdutoRepository.cs
public class ProdutoRepository
{
    private string connectionString = "your_connection_string_here";

    public IEnumerable<Produto> GetProdutos()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Produtos";
            return connection.Query<Produto>(sql);
        }
    }

    public Produto GetProdutoById(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM Produtos WHERE Id = @Id";
            return connection.QueryFirstOrDefault<Produto>(sql, new { Id = id });
        }
    }

    public void AddProduto(Produto produto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
            connection.Execute(sql, new { produto.Nome, produto.Preco });
        }
    }

    public void UpdateProduto(Produto produto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco WHERE Id = @Id";
            connection.Execute(sql, new { produto.Nome, produto.Preco, produto.Id });
        }
    }

    public void DeleteProduto(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sql = "DELETE FROM Produtos WHERE Id = @Id";
            connection.Execute(sql, new { Id = id });
        }
    }
}

// Program.cs
using Models;
using Data;

class Program
{
    static void Main()
    {
        ProdutoRepository repo = new ProdutoRepository();

        // Adicionar um novo produto
        repo.AddProduto(new Produto { Nome = "Produto A", Preco = 10.00M });

        // Obter todos os produtos
        var produtos = repo.GetProdutos();
        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Id}: {produto.Nome} - {produto.Preco}");
        }

        // Atualizar um produto
        var produtoParaAtualizar = repo.GetProdutoById(1);
        produtoParaAtualizar.Preco = 12.00M;
        repo.UpdateProduto(produtoParaAtualizar);

        // Deletar um produto
        repo.DeleteProduto(1);
    }
}
```