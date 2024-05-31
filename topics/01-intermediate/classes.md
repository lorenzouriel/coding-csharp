# Classes
- Tipos estruturados que podem conter **atributos (dados/campos)** e **métodos (funções/operações).**
- Podem fornecer recursos adicionais como **construtores**, **sobrecarga**, **encapsulamento**, **herança** e **polimorfismo**.
- Podem representar **entidades** (como Produto, Cliente, Triângulo) ou **serviços** (como ProdutoService, ClienteService, EmailService, StorageService).
- Além disso, podem incluir **controladores** (ProdutoController, ClienteController), **utilitários** (Calculadora, Compactador) e outros **componentes** (views, repositórios, gerenciadores, etc.).

### Modificadores de Acesso
São `public`, `private`, `protected`, entre outros, para controlar o acesso aos membros de uma classe.

**`public`:** 
- **Acesso:** Os membros públicos são acessíveis de qualquer lugar do código, seja dentro da própria classe, em outras classes do mesmo projeto ou em classes de projetos externos.
- **Uso:** Use `public` quando desejar que o membro seja acessível em toda a aplicação, independentemente de onde esteja sendo utilizado.

**`private`:**
- **Acesso:** Os membros privados só são acessíveis dentro da própria classe em que foram declarados.
- **Uso:** Use `private` para ocultar detalhes de implementação e restringir o acesso direto a membros internos da classe.

**`protected`:**
- **Acesso:** Os membros protegidos são acessíveis dentro da própria classe e também pelas classes derivadas (herdadas) dessa classe.
- **Uso:** Use `protected` quando desejar que o membro seja acessível para a classe derivada, mas não para outras classes que não são suas derivadas.

### Propriedades (Properties)
Permitem definir atributos de um objeto, com códigos associados para `get` e `set`.

Podem ter validações dentro do `get` e `set`.

Podem ser automáticas, com `set` privado para evitar modificações externas.
```csharp
public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}

// COM REGRAS

public string Nome {
     get { return _nome; }  
     set {
        if (value != null && value.Length > 1) { _nome = value;} 
        }
    }

// COM PROPRIEDADES AUTOMÁTICAS

public double Preco { get; private set; }
```

### Atributos ou Campos (Fields):
Variáveis que armazenam os dados da classe, podendo ser públicos, privados, protegidos, etc.
```csharp
public class Carro
{
    public string Modelo;
    public int Ano;
}
```

### Métodos (Methods):
Definem o comportamento da classe, são funções que realizam tarefas específicas.
```csharp
public class Calculadora
{
    public int Somar(int a, int b)
    {
        return a + b;
    }
}
```

### Construtores (Constructors)
Métodos especiais chamados quando um objeto é criado.

Inicializam os campos ou propriedades da classe e permitem a inicialização dos membros da classe no momento da criação do objeto.
```csharp
public class Pessoa
{
    public string Nome;
    public int Idade;
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}
```

Assim, nunca instanciamos atributos vazios, **sera sempre necessário adicionar os valores - ISSO É UM CONSTRUTOR**
```csharp
pessoa = new Pessoa(“Lorenzo”, 22)
```

### Eventos (Events):
Permitem que uma classe notifique outros objetos quando algo acontece.
```csharp
public class ContaBancaria
{
    public event EventHandler SaldoBaixo;
    // ... código para acompanhar o saldo e disparar o evento quando for baixo ...
}
```

### Sobrecarga (Overloading)
Permite ter múltiplos métodos com o mesmo nome, mas diferentes parâmetros e identifica automaticamente qual método deve ser chamado baseado nos argumentos passados.
```csharp
public class Calculadora
{
    // Método para somar dois inteiros
    public int Somar(int a, int b)
    {
        return a + b;
    }
    // Método para somar dois doubles
    public double Somar(double a, double b)
    {
        return a + b;
    }
    // Método para somar três inteiros
    public int Somar(int a, int b, int c)
    {
        return a + b + c;
    }
}
```

### Encapsulamento
Esconde os detalhes internos de uma classe e controla o acesso aos membros da classe usando modificadores de acesso.
```csharp
public class ContaBancaria
{
    private double saldo;
    public double Saldo
    {
        get { return saldo; }
        private set { saldo = value; }
    }

    public ContaBancaria(double saldoInicial)
    {
        saldo = saldoInicial;
    }

    public void Depositar(double valor)
    {
        saldo += valor;
    }

    public void Sacar(double valor)
    {
        if (valor <= saldo)
        {
            saldo -= valor;
        }
        else
        {
            Console.WriteLine("Saldo insuficiente.");
        }
    }
}
```
- No exemplo da classe `ContaBancaria`, o saldo é declarado como um campo privado e somente pode ser acessado por meio da propriedade pública `Saldo`. Dessa forma, o saldo é encapsulado e pode ser modificado apenas através dos métodos públicos `Depositar` e `Sacar`, garantindo assim que o saldo da conta seja sempre manipulado corretamente.

### Herança
Mecanismo que permite criar uma nova classe a partir de uma existente. A classe derivada herda os membros da classe base, podendo reutilizá-los e estendê-los.
```csharp
public class Animal
{
    public void EmitirSom()
    {
        Console.WriteLine("Algum som genérico de animal.");
    }
}

public class Cachorro : Animal
{
    public void Latir()
    {
        Console.WriteLine("Au au!");
    }
}

public class Gato : Animal 
{
    public void Miado() 
    {
        Console.WriteLine("Miau!"); 
    }
}
```
- No exemplo com as classes `Animal`, `Cachorro` e `Gato`, a classe `Cachorro` e a classe `Gato` são derivadas da classe `Animal`. Como resultado, elas herdam o método `EmitirSom` da classe `Animal`, mas cada uma delas também tem seu próprio comportamento especializado através da sobrescrita do método `EmitirSom`.

**Upcasting** é o processo de **conversão de um objeto de uma classe derivada (subclasse) para um objeto de sua classe base (superclasse).** Em outras palavras, você está **"subindo" na hierarquia de herança**.
```csharp
class Animal {
    public void EmitirSom() {
        Console.WriteLine("Algum som genérico");
    }
}

class Cachorro : Animal {
    public void Latir() {
        Console.WriteLine("Latindo...");
    }
}

Animal animal = new Cachorro(); // Upcasting
animal.EmitirSom(); // Método da classe base
```

**Downcasting** é o processo de **conversão de um objeto da classe base para um objeto de uma classe derivada**. Isso é uma operação mais complexa e pode envolver riscos, pois nem sempre é seguro. Para realizar o downcasting, é necessário fazer uma **conversão explícita e verificar se a conversão é válida.**
```csharp
Animal animal = new Cachorro();
Cachorro cachorro = (Cachorro)animal; // Downcasting
cachorro.EmitirSom(); // Método da classe base
cachorro.Latir();    // Método da classe derivada
```
- Você pode verificar a validade do downcasting usando o operador `is` e o operador de conversão segura `as` em C#. O operador `is` verifica se o downcasting é seguro, enquanto o operador `as` tenta realizar o downcasting, retornando `null` se não for possível.

### Polimorfismo
Permite que uma referência de tipo de uma classe base seja usada para referenciar objetos de suas classes derivadas.

Uma variável ou parâmetro de tipo de uma classe base pode se comportar de forma polimórfica.
```csharp
public class Animal
{
    public virtual void EmitirSom()
    {
        Console.WriteLine("Algum som genérico de animal.");
    }
}

public class Cachorro : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine("Au au!");
    }
}

public class Gato : Animal
{
    public override void EmitirSom()
    {
        Console.WriteLine("Miau!");
    }
}
```
- Objetos das classes derivadas `Cachorro` e `Gato`. Quando chamamos o método `EmitirSom`, ele se comporta de forma polimórfica, usando o método correto (da classe `Cachorro` ou `Gato`) dependendo do tipo real do objeto a que animal está apontando.

### Sobreposição (Override)
Permite que uma classe derivada forneça uma implementação específica para um método definido em sua classe base.

Usa as palavras-chave que são `virtual`, `override` e `base`.

**`virtual`:**
- É usado na declaração de um método na classe base para indicar que ele pode ser sobreposto em classes derivadas.
- Isso permite que as classes derivadas substituam o método com sua própria implementação.
```csharp
class Animal {
    public virtual void EmitirSom() {
        Console.WriteLine("Som genérico de animal.");
    }
}
```

**`override`:**
- É usado na declaração do método na classe derivada para indicar que ele está substituindo um método virtual ou abstrato da classe base.
```csharp
class Animal {
    public virtual void EmitirSom() {
        Console.WriteLine("Som genérico de animal.");
    }
}


class Cachorro : Animal {
    public override void EmitirSom() {
        Console.WriteLine("Latindo...");
    }
}
```

**`base`:**
- É usado para chamar o método da classe base dentro da classe derivada.
- Isso é útil quando você deseja estender a funcionalidade da implementação da classe base.
```csharp
class Animal {
    public virtual void EmitirSom() {
        Console.WriteLine("Som genérico de animal.");
    }
}

class Gato : Animal {
    public override void EmitirSom() {
        base.EmitirSom(); // Chama o método da classe base
        Console.WriteLine("Miando...");
    }
}
```
- Aqui, `base.EmitirSom()` chama a implementação do método `EmitirSom` da classe base (`Animal`).

**Exemplo Completo:**
```csharp
class Animal {
    public virtual void EmitirSom() {
        Console.WriteLine("Som genérico de animal.");
    }
}

class Cachorro : Animal {
    public override void EmitirSom() {
        Console.WriteLine("Latindo...");
    }
}

class Gato : Animal {
    public override void EmitirSom() {
        base.EmitirSom(); // Chama o método da classe base
        Console.WriteLine("Miando...");
    }
}

class Program {
    static void Main() {
        Animal animal = new Animal();
        animal.EmitirSom(); // Saída: Som genérico de animal.
        Cachorro cachorro = new Cachorro();
        cachorro.EmitirSom(); // Saída: Latindo.
        Gato gato = new Gato();
        gato.EmitirSom(); // Saída: Som genérico de animal. Miando.
    }
}
```

### Instanciação (Objetos)
Processo de criação de um objeto a partir de uma classe. Utiliza a palavra-chave `new`, seguida do construtor da classe, se existir.
```csharp
public class Pessoa
{
    public string Nome;
    public int Idade;

    // Construtor com parâmetros
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

// Instanciando a classe Pessoa com o construtor
Pessoa pessoa2 = new Pessoa("Bob", 25);
```

### Classes e Métodos Selados
Em C#, as palavras-chave `sealed` podem ser aplicadas a classes e métodos para restringir a herança ou sobreposição. 

#### Classes Seladas (sealed class):
- Quando uma classe é marcada como sealed, ela não pode ser herdada. Ou seja, **você não pode criar subclasses dessa classe.**
```csharp
sealed class ClasseSelada {
    // Conteúdo da classe
}
// A tentativa de herdar de ClasseSelada resultará em erro de compilação.
```

**Uso comum:**
- Classes seladas são úteis quando não faz sentido ter subclasses, ou por razões de segurança ou implementação específica.

#### Métodos Selados (sealed override):
- Quando um método em uma classe base é marcado como `virtual` e um método na classe derivada é marcado como `sealed override`, isso indica que a classe derivada está selando a implementação do método na classe base.
```csharp
class Animal {
    public virtual void EmitirSom() {
        Console.WriteLine("Som genérico de animal.");
    }
}
class Cachorro : Animal {
    public sealed override void EmitirSom() {
        Console.WriteLine("Latindo...");
    }
}
class GoldenRetriever : Cachorro {
    // Não é permitido sobrepor o método EmitirSom aqui, pois está selado em Cachorro.
}
```

**Uso comum:**
- Isso é útil quando você deseja permitir que uma classe base forneça uma implementação padrão, mas quer evitar que classes derivadas modifiquem essa implementação.

### Classes Abstratas
Classes Abstratas em C# são **classes que não podem ser instanciadas diretamente.** Elas são **usadas como modelos para outras classes.** A principal característica que as torna abstratas é a presença de **pelo menos um método abstrato.**
```csharp
abstract class Animal {
    public abstract void EmitirSom();
}
```

**Características Principais:**

- **Métodos abstratos** são declarados na classe abstrata, mas não têm implementação.
```csharp
abstract class Animal {
    public abstract void EmitirSom();
}
```

- **Herança** - classes abstratas podem ser herdadas por outras classes.
```csharp
class Cachorro : Animal {
    public override void EmitirSom() {
        Console.WriteLine("Latindo...");
    }
}
```
- **Classes derivadas** devem fornecer implementações para todos os métodos abstratos da classe base.
```csharp
class Gato : Animal {
    public override void EmitirSom() {
        Console.WriteLine("Miando...");
    }
}
```

- Você **não pode criar uma instância direta de uma classe abstrata.**
```csharp
// Isso resultaria em um erro de compilação
Animal animal = new Animal();
```

Em vez disso, **você cria instâncias de classes derivadas.**
```csharp
Animal cachorro = new Cachorro();
```

**Uso Comum:**
- As classes abstratas são frequentemente usadas quando você tem uma ideia geral de uma classe, mas não pode fornecer uma implementação completa para ela.
- Elas são úteis quando você deseja garantir que as classes derivadas forneçam uma implementação específica para determinados métodos, mas também podem conter implementações padrão que são compartilhadas entre as classes derivadas.

Exemplo Completo:
```csharp
using System;
abstract class Animal {
    public abstract void EmitirSom();
}

class Cachorro : Animal {
    public override void EmitirSom() {
        Console.WriteLine("Latindo...");
    }
}

class Gato : Animal {
    public override void EmitirSom() {
        Console.WriteLine("Miando...");
    }
}

class Program {
    static void Main() {
        Animal cachorro = new Cachorro();
        Animal gato = new Gato();
        cachorro.EmitirSom(); // Saída: Latindo...
        gato.EmitirSom();     // Saída: Miando...
    }
}
```
- Neste exemplo, **Animal é uma classe abstrata com um método abstrato EmitirSom.** As classes Cachorro e Gato **herdam de Animal e fornecem implementações específicas para o método abstrato.**

### Palavra `This`
A palavra-chave this em C# é **usada para referenciar o objeto atual em que o código está sendo executado.**

Ela **representa uma referência para a instância da classe à qual o método pertence ou na qual o campo ou propriedade está sendo usado.**
```csharp
public class MinhaClasse
{
    private int x;
    public MinhaClasse(int x)
    {
        this.x = x; // O 'this' é usado para referenciar o campo 'x' da classe
    }
    public void SetX(int x)
    {
        this.x = x; // O 'this' é usado para referenciar o campo 'x' da classe
    }
}
```