# Princípio da Proximidade em Programação 
Esse princípio sugere que elementos de código que estão relacionados **entre si devem ser agrupados e posicionados próximos uns dos outros. Isso se aplica a variáveis, métodos, propriedades e outros elementos de código.** A ideia é facilitar a compreensão e a manutenção do código, minimizando a necessidade de rolar e buscar por informações que estão distantes.

**Explicação**
- **Agrupamento Semântico:** Em vez de seguir uma ordem rígida para declarar variáveis e métodos (como declarar todas as variáveis no início de um método e depois escrever o código), é mais eficiente declarar variáveis e métodos próximos aos locais onde são utilizados. Isso torna o código mais legível e reduz a carga mental necessária para entender o código.

**Benefícios:**
- **Reduz a Carga Mental:** Quando variáveis e métodos relacionados estão próximos, fica mais fácil para o desenvolvedor entender como eles interagem.
- **Facilita a Manutenção:** Agrupar código relacionado torna mais simples modificar ou expandir funcionalidades sem precisar se preocupar em encontrar e ajustar partes distantes do código.
- **Melhor Legibilidade:** O código se torna mais limpo e intuitivo, pois as partes que estão logicamente conectadas estão visualmente próximas.

**Exemplo:** Se você tem um método que utiliza uma variável específica, declare a variável perto do código onde ela é usada, em vez de declará-la no início do método. Isso evita que você tenha que rolar para cima e para baixo para entender o propósito da variável.
