# EF Core Power Tools

O EF Core Power Tools é uma extensão poderosa para o Visual Studio que facilita a geração de modelos de dados a partir de um banco de dados no Entity Framework Core. Abaixo estão os passos para usar o EF Core Power Tools para gerar modelos no estilo "`Database First`":

## Instale o EF Core Power Tools
1. Abra o Visual Studio.
2. No menu principal, vá para Extensions > Manage Extensions.
3. Na janela de extensões, pesquise por EF Core Power Tools.
4. Clique em Download e reinicie o Visual Studio para concluir a instalação.

## Prepare o Projeto
Certifique-se de que o projeto tem as dependências do EF Core instaladas. Use o NuGet Package Manager para instalar os pacotes necessários:
```bash
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

## Use o EF Core Power Tools para Gerar os Modelos
1. Clique com o botão direito do mouse no projeto no Solution Explorer.

2. Selecione EF Core Power Tools > Reverse Engineer.

3. No assistente de configuração:
- Configure a Conexão ao Banco de Dados:
    - Clique em Add New Connection.
    - Insira os detalhes de conexão para o seu banco de dados.
    - Teste a conexão e clique em OK.
- Escolha a conexão e clique em Next.

4. Selecione as Tabelas e Objetos:
- Escolha as tabelas, views ou stored procedures que deseja incluir no modelo.
- Clique em Next.

5. Configure as Opções do Modelo:
- Escolha um nome para a classe de contexto (por exemplo, MyDbContext).
- Configure outras opções, como:
    - Use Database Names: Mantém os nomes das tabelas e colunas exatamente como estão no banco.
    - Use Fluent API Only: Configura mapeamento de entidades apenas com Fluent API (sem anotações de dados).
    - Pluralize/Singularize Names: Ajusta os nomes das classes e coleções.
- Clique em Generate.

6. O EF Core Power Tools irá gerar:
- O DbContext (classe de contexto do EF Core).
- As entidades para cada tabela selecionada.
- Os mapeamentos configurados automaticamente.

## Utilizando os Modelos Gerados
Depois de gerados, você pode usar o DbContext para interagir com o banco de dados. Por exemplo:
```csharp
using (var context = new MyDbContext())
{
    var items = context.YourEntity.ToList();
    foreach (var item in items)
    {
        Console.WriteLine(item.PropertyName);
    }
}
```

## Atualizando o Modelo
Caso o banco de dados sofra alterações:
1. Repita o processo do EF Core Power Tools para regenerar as entidades e atualizar o contexto.
2. Alternativamente, use o comando no console do NuGet para gerar novos arquivos de modelo:
```bash
Scaffold-DbContext "YourConnectionString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

## Vantagens do EF Core Power Tools
- Interface amigável no Visual Studio.
- Suporte a diversos provedores de banco de dados.
- Opções avançadas, como configurar namespaces personalizados e gerenciar relacionamentos complexos.

Essa ferramenta é ideal para quem prefere uma abordagem prática e integrada para o desenvolvimento Database First com EF Core.