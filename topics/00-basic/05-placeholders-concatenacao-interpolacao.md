# Placeholders, Concatenação e Interpolação

### Placeholders (Marcadores de Posição):
- Indicam onde os valores serão inseridos posteriormente em uma string.
- Usados com o método `String.Format()`.

**Exemplo:**
```csharp
string nome = "Alice";

int idade = 25;

string mensagem = String.Format("Olá, meu nome é {0} e tenho {1} anos.", nome, idade);

Console.WriteLine(mensagem);
```

### Concatenação de Strings:
- Combina várias strings em uma única usando o operador `+`.

**Exemplo:**
```csharp
string saudacao = "Olá, ";
string nome = "Bob";

string mensagem = saudacao + nome;

Console.WriteLine(mensagem);
```

### Interpolação de Strings:
- Técnica introduzida no C# 6.
- Facilita a construção de strings interpolando valores diretamente.
- Delimitada por cifrões e chaves ${}.

**Exemplo:**
```csharp
string nome = "Carol";
int idade = 30;

string mensagem = $"Olá, meu nome é {nome} e tenho {idade} anos.";

Console.WriteLine(mensagem);
```