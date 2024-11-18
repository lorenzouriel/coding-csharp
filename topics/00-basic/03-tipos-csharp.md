# Tipos Básicos em C# 
- C# é uma linguagem **estaticamente tipada**
- Tipos valor pré-definidos em C#
- Tipos referência pré-definidos em C#
- Variável não atribuída
- Overflow
- Padrão para float: sufixo "f"
- Padrão para char: 'aspas simples'
- Padrão para String: "aspas duplas"
- Padrão para bool: true, false
- Opção: inferência de tipos com palavra "var" (dentro de métodos)

**Tabelas com tipos:**
- ![tipos_2](/images/tipos_2.png)

**Tabelas com tipos Built-in:**
- ![tipos_3](/images/tipos_3.png)

**Exemplos no código:**
- ![tipos_4](/images/tipos_4.png)

**Tipo Valor x Tipo Referência:**
- ![tipos_5](/images/tipos_5.png)

### Inferência de tipos: palavra `var`
A palavra-chave `var` em C# permite a inferência de tipos de dados durante a compilação, o que simplifica a declaração de variáveis, tornando o código mais conciso e legível. A inferência de tipos significa que o compilador determina automaticamente o tipo de dado da variável com base no valor inicial atribuído a ela.
```csharp
var nomeDaVariavel = valor;

var numero = 42; // O tipo é inferido como int
var texto = "Olá, mundo!"; // O tipo é inferido como string
var pi = 3.14159; // O tipo é inferido como double
```