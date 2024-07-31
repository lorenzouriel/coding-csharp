# O que Clean Code diz Sobre Métodos

### Sinais de um Método Ruim
- **Comprimento e Responsabilidade Única do Método:** Métodos limpos devem ser curtos e focados em uma única tarefa. Métodos longos geralmente indicam múltiplas responsabilidades e precisam de refatoração.

- **Níveis de Indentação:** Muitos níveis de indentação dentro de um método são sinais de complexidade e sugerem que o método não está limpo. Métodos devem ser refatorados para reduzir estruturas aninhadas e melhorar a legibilidade.

- **Nomes Descritivos:** Os nomes dos métodos devem descrever claramente sua responsabilidade única. Se o nome do método contiver "e", provavelmente está executando várias tarefas e deve ser dividido em métodos menores.

- **Níveis de Abstração:** Métodos devem operar em um único nível de abstração. Misturar diferentes níveis, como interagir com o sistema de arquivos, banco de dados e interface de usuário em um único método, indica a necessidade de refatoração em métodos separados.

- **Manutenibilidade e Legibilidade:** Refatorar métodos em partes menores e modulares melhora a manutenibilidade e a legibilidade. Evite comprimir código em uma única linha para reduzir o comprimento do método, pois isso sacrifica a clareza.

- **Desafios com Muitos Parâmetros:** Métodos com muitos parâmetros são difíceis de testar e entender. Manter o número de parâmetros baixo é crucial para simplificar a lógica e facilitar a manutenção.

- **Methods with Side Effects:** Efeito colateral é quando um método realiza uma ação adicional que não é indicada pelo seu nome. Exemplo: um método que produz uma saudação também incrementa a propriedade de idade. É recomendável refatorar esses métodos para seguir o princípio da responsabilidade única.

-  **Dica:** Visual Studio possui um recurso de formatação automática, acessível pelo menu Edit ou pelo atalho Ctrl+E, Ctrl+D, que ajuda a manter a formatação consistente.


### Métodos de Ação vs. Resposta
- **Métodos de Ação:** Esses métodos realizam tarefas, como salvar dados em disco, e devem retornar void, utilizando tratamento de exceções para gerenciar erros.

- **Métodos de Resposta:** Esses métodos retornam valores, como booleanos, para indicar o sucesso ou a validade de uma operação, respondendo a perguntas específicas do código chamador.

- **Refatoração para Clareza:** Combinar métodos de ação e de resposta pode tornar o código menos limpo; a melhor prática é refatorar esses métodos em métodos separados para maior clareza e manutenção.


### Named Arguments
É importante entender a diferença entre parâmetros (definições de métodos) e argumentos (valores passados para métodos), o que ajuda a evitar confusão e a usar os termos corretamente.

Ao nomear os argumentos, você reduz a necessidade de consultar a definição do método sempre que for necessário entender uma chamada de método, facilitando a manutenção e o entendimento do código.

Eles são especialmente úteis em métodos com muitos parâmetros ou em chamadas onde a ordem dos parâmetros não é imediatamente clara.

Vamos utilizar o método `contactFriend` em C# com argumentos nomeados para passar informações de contato de maneira clara.

**Diferença Entre Parâmetros e Argumentos:**
- **Parâmetros:** `void contactFriend(Person friend, string communicationMeans, DateTime dateTime)`
- **Argumentos:** `contactFriend(new Person(), "WhatsApp", DateTime.Now)`

**Exemplo de Argumentos Nomeados (Named Arguments):**
- **Código sem Argumentos Nomeados:** `contactFriend(new Person(), "WhatsApp", DateTime.Now);`
- **Código com Argumentos Nomeados:** `contactFriend(friend: new Person(), communicationMeans: "WhatsApp", dateTime:DateTime.Now);`

Sem argumentos nomeados é necessário verificar a ordem dos parâmetros para entender o que cada valor representa.

Com argumentos nomeados fica claro que `friend` é uma instância da classe `Person`, `communicationMeans` é `"WhatsApp"` e `dateTime` é a data e hora atuais, sem necessidade de consultar a definição do método.














