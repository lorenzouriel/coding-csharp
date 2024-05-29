# Conversão Implícita e Casting
### Conversão Implícita (Implicit Conversion):
- Ocorre automaticamente pelo compilador quando não há risco de perda de dados ou precisão.
- Permite atribuir um valor de um tipo para uma variável de outro tipo sem sintaxe especial.

**Exemplo:**
```csharp
int inteiro = 10;

double flutuante = inteiro; // Conversão implícita de int para double
```

### Casting:
- Usado para converter explicitamente um valor de um tipo para outro, mesmo que haja risco de perda de dados ou precisão.
- Sintaxe: `(tipoDesejado) valorASerConvertido.`

**Exemplo:** 
```csharp
double flutuante = 10.5;
int inteiro = (int)flutuante; // Casting explícito de double para int
```