# Escopo e Inicialização
## Escopo
Refere-se à parte do programa onde uma variável é válida e acessível.

**Escopo Local:** Variáveis declaradas dentro de um bloco de código, visíveis apenas dentro desse bloco.
```csharp
void MeuMetodo()
{
    int x = 10; // Variável local
    Console.WriteLine(x); // Acesso válido dentro do escopo do método
}
```

**Escopo Global:** Variáveis declaradas fora de qualquer bloco de código, visíveis em todo o program
```csharp
int x = 10; // Variável global
void MeuMetodo()
{
    Console.WriteLine(x); // Acesso válido em qualquer parte do programa
}
```

## Inicialização
Processo de atribuir um valor inicial a uma variável.

**Inicialização Explícita:** Atribuição de um valor no momento da declaração.
```csharp
int x = 10; // Inicialização explícita
```

**Inicialização por Padrão:** Variáveis são automaticamente inicializadas com um valor padrão se não forem explicitamente inicializadas.
```csharp
int x; // Inicialização por padrão: x terá o valor 0
bool flag; // Inicialização por padrão: flag terá o valor false
string texto; // Inicialização por padrão: texto terá o valor null
```

É recomendável **limitar o escopo de uma variável ao mínimo necessário para evitar colisões de nomes e inicializar explicitamente as variáveis antes de usá-las para garantir que tenham um valor válido.**
