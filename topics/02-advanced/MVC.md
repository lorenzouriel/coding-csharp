# MVC (Model - View - Controller)
MVC (Model-View-Controller) é um padrão de arquitetura de software comumente usado para criar aplicativos web. Ele separa a aplicação em três componentes principais: o **Modelo (Model)**, a **Visão (View)** e o **Controlador (Controller)**. No contexto do ASP.NET MVC, essa separação ajuda a organizar o código de maneira clara e modular.

### Componentes do MVC
**1. Model (Modelo)**:
- Representa os dados da aplicação e a lógica de negócios.
- Normalmente, inclui classes que mapeiam para tabelas no banco de dados e manipulam a lógica de negócios.

**2. View (Visão):**
- Responsável pela apresentação dos dados ao usuário.
- Geralmente, inclui arquivos HTML e Razor (arquivos .cshtml no ASP.NET) que geram a interface do usuário.

**3. Controller (Controlador):**
- Intermediário entre o Model e a View.
- Trata as requisições do usuário, realiza operações usando os modelos, e retorna a View apropriada.

## Criando um Projeto ASP.NET MVC
Aqui está um guia passo a passo para criar um projeto básico em ASP.NET MVC.

**Passo 1: Criar um Novo Projeto ASP.NET MVC**
- Abra o Visual Studio.
- Vá para File > New > Project.
- Selecione ASP.NET Web Application (.NET Framework).
- Escolha MVC e clique em Create.

**Passo 2: Estrutura do Projeto**

Ao criar um novo projeto MVC, a estrutura básica será gerada automaticamente:
- Controllers: Contém classes de controladores.
- Models: Contém classes de modelo.
- Views: Contém arquivos de visualização.

**Passo 3: Criar um Modelo**

Primeiro, vamos criar uma classe de modelo. Suponha que estamos criando uma aplicação para gerenciar produtos.
```csharp
namespace MvcApp.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
```

**Passo 4: Criar um Controlador**

Em seguida, criaremos um controlador para gerenciar os produtos.

- Clique com o botão direito na pasta Controllers.
- Selecione Add > Controller.
- Escolha MVC 5 Controller - Empty e clique em Add.

```csharp
using System.Collections.Generic;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class ProdutosController : Controller
    {
        private static List<Produto> produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto A", Preco = 10.0M },
            new Produto { Id = 2, Nome = "Produto B", Preco = 20.0M }
        };

        public ActionResult Index()
        {
            return View(produtos);
        }

        public ActionResult Detalhes(int id)
        {
            var produto = produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
    }
}
```

**Passo 5: Criar Visualizações**

Agora, criaremos as visualizações correspondentes.
- Clique com o botão direito na ação Index no controlador ProdutosController.
- Selecione Add View.
- Nomeie a View como Index e escolha o modelo List de Produto.

*Views/Produtos/Index.cshtml:*
```csharp
@model IEnumerable<MvcApp.Models.Produto>

<h2>Produtos</h2>
<table class="table">
    <tr>
        <th>Id</th>
        <th>Nome</th>
        <th>Preço</th>
        <th></th>
    </tr>
    @foreach (var item in Model)
    {
        <tr>
            <td>@item.Id</td>
            <td>@item.Nome</td>
            <td>@item.Preco</td>
            <td>
                @Html.ActionLink("Detalhes", "Detalhes", new { id = item.Id })
            </td>
        </tr>
    }
</table>
```

Repita o processo para a ação `Detalhes`.

*Views/Produtos/Detalhes.cshtml:*
```csharp
@model MvcApp.Models.Produto

<h2>Detalhes do Produto</h2>

<div>
    <h4>Produto</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>Id</dt>
        <dd>@Model.Id</dd>
        <dt>Nome</dt>
        <dd>@Model.Nome</dd>
        <dt>Preço</dt>
        <dd>@Model.Preco</dd>
    </dl>
</div>

<p>
    @Html.ActionLink("Voltar para Lista", "Index")
</p>
```

**Executar a Aplicação**
- Pressione F5 ou clique no botão Run para iniciar a aplicação.
- Navegue até /Produtos para ver a lista de produtos.
- Clique no link "Detalhes" para ver os detalhes de um produto específico.