# `System.Data.SqlClient`
`System.Data.SqlClient` é um namespace que fornece classes para trabalhar com o SQL Server. A classe principal é `SqlConnection`, que é usada para abrir uma conexão com um banco de dados SQL Server. Outras classes importantes incluem `SqlCommand`, `SqlDataReader`, e `SqlParameter`.

### Instalação
Certifique-se de ter a biblioteca instalada. No .NET Core ou .NET 5+, você pode precisar instalar o pacote NuGet:
```shell
Install-Package System.Data.SqlClient
```

### Exemplo de Uso
Aqui está um exemplo de como realizar operações básicas de banco de dados usando `System.Data.SqlClient`.

**Configuração da Conexão**
- Primeiro, você precisa de uma string de conexão para se conectar ao seu banco de dados. Certifique-se de substituir **"your_connection_string_here"** pela string de conexão do seu banco de dados.
```csharp
string connectionString = "your_connection_string_here";
```

**SELECT (Read)**
- Aqui está um exemplo de como ler dados de um banco de dados usando `SqlCommand` e `SqlDataReader`.
```csharp
using System;
using System.Data.SqlClient;

public class DatabaseExample
{
    private string connectionString = "your_connection_string_here";

    public void GetProdutos()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM Produtos";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}: {reader["Nome"]} - {reader["Preco"]}");
                    }
                }
            }
        }
    }
}
```

**INSERT (Create)**
- Aqui está um exemplo de como inserir dados em um banco de dados.
```csharp
public void AddProduto(string nome, decimal preco)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@Nome", nome);
            command.Parameters.AddWithValue("@Preco", preco);
            command.ExecuteNonQuery();
        }
    }
}
```

**UPDATE**
- Aqui está um exemplo de como atualizar dados em um banco de dados.
```csharp
public void UpdateProduto(int id, string nome, decimal preco)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco WHERE Id = @Id";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Nome", nome);
            command.Parameters.AddWithValue("@Preco", preco);
            command.ExecuteNonQuery();
        }
    }
}
```

**DELETE**
- Aqui está um exemplo de como deletar dados de um banco de dados.
```csharp
public void DeleteProduto(int id)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string sql = "DELETE FROM Produtos WHERE Id = @Id";
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
```

### Exemplo Completo
Aqui está um exemplo completo de uma classe que realiza operações CRUD usando `System.Data.SqlClient`.
```csharp
using System;
using System.Data.SqlClient;

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

    public void GetProdutos()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM Produtos";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}: {reader["Nome"]} - {reader["Preco"]}");
                    }
                }
            }
        }
    }

    public void AddProduto(string nome, decimal preco)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Preco", preco);
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateProduto(int id, string nome, decimal preco)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Preco", preco);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteProduto(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sql = "DELETE FROM Produtos WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
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
        repo.AddProduto("Produto A", 10.00M);

        // Obter todos os produtos
        repo.GetProdutos();

        // Atualizar um produto
        repo.UpdateProduto(1, "Produto A Atualizado", 12.00M);

        // Deletar um produto
        repo.DeleteProduto(1);
    }
}
```
