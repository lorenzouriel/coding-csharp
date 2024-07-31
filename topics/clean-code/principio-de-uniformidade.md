# Princípio da Uniformidade na Conexão 
Elementos de código relacionados **devem ser agrupados para melhorar a compreensão e a legibilidade.** No C#, isso é exemplificado pelo uso de chaves que agrupam linhas de código relacionadas, como declarações de retorno.

**Exemplos:**
- **Chaves (Curly Braces):** São usadas para agrupar blocos de código, como em funções, loops e condições. Esse agrupamento visual ajuda a identificar quais linhas de código pertencem a um determinado bloco de controle, tornando o código mais organizado e fácil de entender.

- **Regiões (Regions):** Permitem que você agrupe e colapse seções do código dentro de uma classe ou arquivo. Isso pode ser útil para organizar código relacionado, como propriedades e métodos, facilitando a navegação em classes grandes. No entanto, é importante usar regiões com moderação para evitar a criação de um "cheiro de código" (code smell) e manter a clareza do código.
```csharp
#region AquiEuPrintoHelloWorld

Console.WriteLine("Hello World");

#endregion
```

- **Outlining e Comentários:** Técnicas como o uso de regiões e comentários também ajudam a agrupar e destacar partes do código, tornando mais fácil a gestão e leitura, especialmente em arquivos de código extensos.
