# EF 6.x DbContext Generator

O **Entity Framework 6.x DbContext Generator** é uma ferramenta poderosa para gerar classes de contexto (`DbContext`) e classes de entidade com base em um modelo de dados. Isso é especialmente útil quando você está trabalhando com um banco de dados existente e deseja criar uma camada de acesso a dados em um projeto C#.

Aqui está um guia passo a passo para configurar e utilizar o **DbContext Generator no Entity Framework 6.x:**

### Instale o Entity Framework
- Se você ainda não instalou o Entity Framework no seu projeto, faça isso através do NuGet Package Manager.
```csharp
Install-Package EntityFramework
```

### Crie um Modelo de Dados
Você pode criar um modelo de dados usando o ADO.NET Entity Data Model. Aqui, você pode optar por **"Code First from Database"** ou **"Database First"**.
- **Database First:** Usado quando você já possui um banco de dados existente.
- **Code First from Database:** Gera classes de entidade e contexto a partir de um banco de dados existente.

### Exemplo Database First
