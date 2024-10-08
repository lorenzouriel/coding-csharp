# Arquivos
- ***Todas as classes abaixo são do namespace System.IO.***

## `File`, `FileInfo`, `IOException`
Em C#, `File`, `FileInfo`, e `IOException` são classes relacionadas ao trabalho com arquivos.

`File`:
- `File` é uma classe estática em C# que fornece métodos estáticos para a criação, cópia, exclusão e movimentação de arquivos, entre outras operações relacionadas a arquivos.
```csharp
using System;
using System.IO;

class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Arquivo.txt";

        // Verifica se o arquivo existe
        if (File.Exists(caminho)) {

            // Lê todo o conteúdo do arquivo
            string conteudo = File.ReadAllText(caminho);
            Console.WriteLine(conteudo);
        }

        // Escreve no arquivo
        File.WriteAllText(caminho, "Novo conteúdo");

        // Adiciona linhas ao arquivo
        File.AppendAllLines(caminho, new string[] { "Nova linha 1", "Nova linha 2" });
    }
}
```

`FileInfo`:
- `FileInfo` é uma classe que fornece instâncias de informações sobre um arquivo, como seu tamanho, última modificação, caminho completo, etc. Ela é mais orientada a objetos do que a classe `File` e pode ser usada para obter informações detalhadas sobre um arquivo específico.
```csharp
using System;
using System.IO;

class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Arquivo.txt";
        FileInfo fileInfo = new FileInfo(caminho);

        // Obtém o tamanho do arquivo
        long tamanho = fileInfo.Length;
        Console.WriteLine($"Tamanho do arquivo: {tamanho} bytes");

        // Obtém a data da última modificação
        DateTime ultimaModificacao = fileInfo.LastWriteTime;
        Console.WriteLine($"Última modificação: {ultimaModificacao}");
    }
}
```

`IOException`:
- `IOException` é uma exceção que pode ser lançada durante operações de leitura e gravação de arquivos. Ela é uma subclasse de `SystemException`. Quando você está realizando operações de E/S (entrada e saída), é uma boa prática capturar `IOException` para lidar com possíveis problemas durante a manipulação de arquivos.
```csharp
using System;
using System.IO;

class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Arquivo.txt";

        try {
            string conteudo = File.ReadAllText(caminho);
            Console.WriteLine(conteudo);
        }
        catch (IOException ex) {
            Console.WriteLine($"Erro de E/S: {ex.Message}");
        }
    }
}
```

## `FileStream` e `StreamReader`
`FileStream` e `StreamReader` são classes em C# que permitem a leitura de dados de um arquivo. Vamos dar uma olhada em cada uma delas:

`FileStream` é usado para ler e gravar bytes em um arquivo. Ele fornece uma implementação genérica de um fluxo de bytes, permitindo operações mais detalhadas em comparação com as operações de alto nível fornecidas pela classe File.
```csharp
using System;
using System.IO;

class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Arquivo.txt";

        // Abre o arquivo no modo de leitura
        using (FileStream fileStream = new FileStream(caminho, FileMode.Open, FileAccess.Read)) {
            byte[] buffer = new byte[1024];
            int bytesRead;

            // Lê os bytes do arquivo e os coloca no buffer
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0) {

                // Processa os bytes conforme necessário (nesse exemplo, apenas exibe como texto)
                Console.WriteLine(System.Text.Encoding.Default.GetString(buffer, 0, bytesRead));
            }
        }
    }
}
```

`StreamReader` é uma classe de nível mais alto que simplifica a leitura de texto de fluxos de bytes, como aqueles fornecidos por `FileStream`. Ele lida automaticamente com a conversão de bytes para caracteres.
```csharp
using System;
using System.IO;
class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Arquivo.txt";

        // Abre o arquivo e cria um StreamReader para facilitar a leitura de texto
        using (StreamReader streamReader = new StreamReader(caminho)) {

            // Lê o conteúdo do arquivo e exibe na tela
            string conteudo = streamReader.ReadToEnd();
            Console.WriteLine(conteudo);
        }
    }
}
```

Ambas as classes (`FileStream` e `StreamReader`) são normalmente usadas dentro de uma instrução using para garantir que os recursos do sistema sejam liberados corretamente após o uso.
- Esse bloco ajuda a evitar vazamentos de recursos e a melhorar o gerenciamento de memória em situações onde é necessário liberar explicitamente recursos não gerenciados.

A escolha entre `FileStream` e `StreamReader` depende do que você precisa fazer. Se estiver trabalhando com dados binários ou se precisar de operações mais detalhadas em nível de byte, use `FileStream`. Se estiver trabalhando com texto, especialmente em arquivos grandes, `StreamReader` é uma escolha mais conveniente.

## `StreamWriter`
`StreamWriter` é uma classe em C# que permite a escrita de caracteres em um fluxo de bytes, geralmente utilizado para escrever em arquivos de texto. Ele fornece métodos para escrever strings, caracteres e outras representações de dados em um arquivo.
```csharp
using System;
using System.IO;
class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Arquivo.txt";

        // Usando StreamWriter dentro de um bloco using
        using (StreamWriter streamWriter = new StreamWriter(caminho)) {

            // Escreve uma linha no arquivo
            streamWriter.WriteLine("Olá, mundo!");
            
            // Escreve outra linha no arquivo
            streamWriter.WriteLine("Esta é outra linha.");

            // Escreve uma string
            streamWriter.Write("Texto sem nova linha.");

            // Nota: StreamWriter faz o flush automaticamente, mas você também pode chamar streamWriter.Flush() manualmente se necessário.
        } // Aqui, o método Dispose do StreamWriter é chamado automaticamente
    }
}
```

Neste exemplo:
- `StreamWriter` é usado para escrever em um arquivo especificado pelo caminho.
- O bloco using garante que o método Dispose do `StreamWriter` seja chamado, o que, por sua vez, fecha o fluxo do arquivo.

### Encoding:
Por padrão, `StreamWriter` usa a codificação UTF-8. Se você quiser especificar uma codificação diferente, pode passá-la como um parâmetro no construtor:
```csharp
using (StreamWriter streamWriter = new StreamWriter(caminho, false, Encoding.UTF32)) {
    // Escreve usando a codificação UTF-32
    streamWriter.WriteLine("Texto com codificação UTF-32.");
}
```

`StreamWriter` fornece métodos convenientes para escrever diferentes tipos de dados, como `Write`, `WriteLine`, `WriteAsync`, e outros.
```csharp
using (StreamWriter streamWriter = new StreamWriter(caminho)) {
    streamWriter.WriteLine("Número: {0}", 42);
    streamWriter.Write("Texto: ");
    streamWriter.WriteLine("Exemplo");
}
```

## `Directory` e `DirectoryInfo`
`Directory` e `DirectoryInfo` são classes em C# que fornecem funcionalidades para trabalhar com diretórios (pastas) no sistema de arquivos.

`Directory`é uma classe estática que fornece métodos para a criação, remoção, movimentação e recuperação de informações sobre diretórios. Ela não requer a criação de uma instância da classe.
```csharp
using System;
using System.IO;
class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Diretorio";

        // Verifica se o diretório existe
        if (Directory.Exists(caminho)) {
            Console.WriteLine("O diretório já existe.");
        }
        else {
            // Cria o diretório se não existir
            Directory.CreateDirectory(caminho);
            Console.WriteLine("Diretório criado com sucesso.");
        }

        // Lista todos os arquivos em um diretório
        string[] arquivos = Directory.GetFiles(caminho);
        foreach (var arquivo in arquivos) {
            Console.WriteLine(arquivo);
        }

        // Lista todos os subdiretórios em um diretório
        string[] subdiretorios = Directory.GetDirectories(caminho);
        foreach (var subdiretorio in subdiretorios) {
            Console.WriteLine(subdiretorio);
        }
    }
}
```

`DirectoryInfo` é uma classe que fornece instâncias de informações sobre um diretório específico. Ela é mais orientada a objetos do que a classe `Directory` e permite a manipulação de um diretório por meio de métodos de instância.
```csharp
using System;
using System.IO;
class Program {
    static void Main() {
        string caminho = "C:\\Caminho\\Para\\O\\Diretorio";

        // Cria uma instância de DirectoryInfo
        DirectoryInfo directoryInfo = new DirectoryInfo(caminho);

        // Verifica se o diretório existe
        if (directoryInfo.Exists) {
            Console.WriteLine("O diretório já existe.");
        }
        else {
            // Cria o diretório se não existir
            directoryInfo.Create();
            Console.WriteLine("Diretório criado com sucesso.");
        }

        // Lista todos os arquivos em um diretório
        FileInfo[] arquivos = directoryInfo.GetFiles();
        foreach (var arquivo in arquivos) {
            Console.WriteLine(arquivo.FullName);
        }

        // Lista todos os subdiretórios em um diretório
        DirectoryInfo[] subdiretorios = directoryInfo.GetDirectories();
        foreach (var subdiretorio in subdiretorios) {
            Console.WriteLine(subdiretorio.FullName);
        }
    }
}
```

Ambas as classes fornecem métodos para realizar várias operações em diretórios, como criar, mover, excluir, obter informações e muito mais. A escolha entre `Directory` e `DirectoryInfo` depende da preferência e das necessidades específicas do código que está sendo escrito. `DirectoryInfo` pode ser mais útil quando você planeja realizar várias operações no mesmo diretório e deseja manter o estado do diretório entre as operações.

## `Path`
`Path` é uma classe estática em C# que fornece métodos para manipular strings de caminhos de arquivo e diretório. Ele fornece funcionalidades para combinar caminhos, obter informações sobre caminhos, alterar extensões de arquivos, entre outras operações relacionadas a caminhos.
```csharp
using System;
using System.IO;

class Program {
    static void Main() {
        string caminho1 = "C:\\Caminho\\Para\\O";
        string caminho2 = "Arquivo.txt";

        // Combina dois caminhos para formar um caminho completo
        string caminhoCompleto = Path.Combine(caminho1, caminho2);
        Console.WriteLine(caminhoCompleto);

        // Obtém o diretório pai de um caminho
        string diretorioPai = Path.GetDirectoryName(caminhoCompleto);
        Console.WriteLine(diretorioPai);

        // Obtém a extensão do arquivo
        string extensao = Path.GetExtension(caminhoCompleto);
        Console.WriteLine(extensao);

        // Obtém o nome do arquivo sem a extensão
        string nomeSemExtensao = Path.GetFileNameWithoutExtension(caminhoCompleto);
        Console.WriteLine(nomeSemExtensao);
    }
}
```

Neste Exemplo:
- `Path.Combine` é usado para combinar dois caminhos e formar um caminho completo.
- `Path.GetDirectoryName` é usado para obter o diretório pai de um caminho.
- `Path.GetExtension` é usado para obter a extensão do arquivo.
- `Path.GetFileNameWithoutExtension` é usado para obter o nome do arquivo sem a extensão.

Esses métodos são úteis para manipular caminhos de maneira segura e consistente, independentemente do sistema operacional. Vale ressaltar que a classe Path lida bem com diferenças de barra invertida (\ no Windows) e barra normal (/ em sistemas Unix) nas strings de caminho.