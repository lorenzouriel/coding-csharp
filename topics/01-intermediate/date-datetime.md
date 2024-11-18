# Lidando com Datas (`DateTime`, `Date`, `TimeSpan`, `DateTimeKind`, `Padrão ISO 8601`)

## `DateTime`
- https://msdn.microsoft.com/en-us/library/system.datetime(v=vs.110).aspx

`DateTime` é uma estrutura (struct) em C# que faz parte do namespace `System` e é usada para representar datas e horas. Ela oferece métodos e propriedades para manipular e trabalhar com informações de data e hora de maneira eficiente.

Aqui estão algumas das principais funcionalidades do `DateTime`:
- **Ticks:** Um objeto `DateTime` internamente armazena  número de "ticks" (100 nanosegundos) desde a meia noite do dia 1 de janeiro do ano 1 da era comum.
```csharp
DateTime d1 = DateTime.Now;
Console.WriteLine(d1); // 18/11/2024 14:23:45
Console.WriteLine(d1.Ticks); // 638357509255385837 - Imprime o número de ticks desde 12:00 da meia-noite de 1º de janeiro do ano 0001 (Era Comum).
```

- **Criando instâncias de `DateTime`:** Você pode criar uma instância de DateTime para representar uma data e hora específica.
```csharp
DateTime dataHoraAtual = DateTime.Now; // Data e hora atual
DateTime dataEspecifica = new DateTime(2023, 7, 15, 14, 30, 0); // 15 de julho de 2023 às 14:30:00
```

- **Propriedades e Métodos:** O DateTime possui várias propriedades e métodos úteis para manipulação de datas e horas.
```csharp
DateTime dataHora = DateTime.Now;
int ano = dataHora.Year; // Obtém o ano
int mes = dataHora.Month; // Obtém o mês
int dia = dataHora.Day; // Obtém o dia
int hora = dataHora.Hour; // Obtém a hora
int minuto = dataHora.Minute; // Obtém os minutos
int segundo = dataHora.Second; // Obtém os segundos
DateTime amanha = dataHora.AddDays(1); // Obtém a data de amanhã
```

- **Manipulação de Durações:** Você pode realizar operações com durações (intervalos de tempo) usando métodos como Add, Subtract, etc.
```csharp
DateTime dataAtual = DateTime.Now;
DateTime daquiUmaHora = dataAtual.AddHours(1); // Uma hora após a data atual
TimeSpan diferenca = daquiUmaHora - dataAtual; // Diferença entre as datas
```

- **Formatação de Saída:** Você pode formatar a representação de `DateTime` em strings usando o método `ToString`.
```csharp
string dataFormatada = dataHoraAtual.ToString("dd/MM/yyyy HH:mm:ss"); // Formato customizado


DateTime d1 = DateTime.ParseExact("2000-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture);
DateTime d2 = DateTime.ParseExact("15/08/2000 13:05:58", "dd/MM/yyyy HH:mm:ss",
CultureInfo.InvariantCulture);
Console.WriteLine(d1);
Console.WriteLine(d2);
```

Lembre-se de que `DateTime` representa uma combinação de data e hora e não contém informações sobre o fuso horário. Se você precisa lidar com informações de fuso horário, pode considerar o uso de tipos como `DateTimeOffset`.

- **Propriedades com `DateTime`** Pode realizar diversas operações com as propriedades que o `DateTime` suporta.

```csharp
Date (DateTime)
• Day (int)
• DayOfWeek (DayOfWeek)
• DayOfYear (int)
• Hour (int)
• Kind (DateTimeKind)
• Millisecond (int)
• Minute (int)
• Month (int)
• Second (int)
• Ticks (long)
• TimeOfDay (TimeSpan)
• Year (int)


DateTime d = new DateTime(2001, 8, 15, 13, 45, 58, 275);
Console.WriteLine(d);
Console.WriteLine("1) Date: " + d.Date);
Console.WriteLine("2) Day: " + d.Day);
Console.WriteLine("3) DayOfWeek: " + d.DayOfWeek);
Console.WriteLine("4) DayOfYear: " + d.DayOfYear);
Console.WriteLine("5) Hour: " + d.Hour);
Console.WriteLine("6) Kind: " + d.Kind);
Console.WriteLine("7) Millisecond: " + d.Millisecond);
Console.WriteLine("8) Minute: " + d.Minute);
Console.WriteLine("9) Month: " + d.Month);
Console.WriteLine("10) Second: " + d.Second);
Console.WriteLine("11) Ticks: " + d.Ticks);
Console.WriteLine("12) TimeOfDay: " + d.TimeOfDay);
Console.WriteLine("13) Year: " + d.Year);
```

- **Formatação:** `DateTime` -> `string`
```csharp
DateTime d = new DateTime(2001, 8, 15, 13, 45, 58);
string s1 = d.ToLongDateString();
string s2 = d.ToLongTimeString();
string s3 = d.ToShortDateString();
string s4 = d.ToShortTimeString();
string s5 = d.ToString();
string s6 = d.ToString("yyyy-MM-dd HH:mm:ss");
string s7 = d.ToString("yyyy-MM-dd HH:mm:ss.fff");
Console.WriteLine(s1);
Console.WriteLine(s2);
Console.WriteLine(s3);
Console.WriteLine(s4);
Console.WriteLine(s5);
Console.WriteLine(s6);
Console.WriteLine(s7);
```

- **Operações com `Datetime`:** Temos várias possíveis operações.
```csharp
DateTime x = ...
DateTime y = x.Add(timeSpan);
DateTime y = x.AddDays(double);
DateTime y = x.AddHours(double);
DateTime y = x.AddMilliseconds(double);
DateTime y = x.AddMinutes(double);
DateTime y = x.AddMonths(int);
DateTime y = x.AddSeconds(double);
DateTime y = x.AddTicks(long);
DateTime y = x.AddYears(int);
DateTime y = x.Subtract(timeSpan);
TimeSpan t = x.Subtract(dateTime);
```

## `TimeSpan`
- https://msdn.microsoft.com/en-us/library/system.timespan(v=vs.110).aspx

`TimeSpan` é uma estrutura em C# que faz parte do namespace System e é usada para representar um intervalo de tempo, ou seja, a diferença entre dois pontos no tempo. Ele permite representar durações em termos de dias, horas, minutos, segundos e milissegundos.

Aqui estão algumas das principais funcionalidades do `TimeSpan`:

- **Ticks:** Um objeto `TimeSpan` internamente armazena uma duração na forma de ticks (100 nanosegundos)
```csharp
TimeSpan t1 = new TimeSpan(0, 1, 30);
Console.WriteLine(t1);
Console.WriteLine(t1.Ticks);
```

- Criando instâncias de `TimeSpan`: Você pode criar uma instância de `TimeSpan` para representar uma duração específica.
```csharp
TimeSpan duracao = new TimeSpan(1, 2, 30, 0); // 1 dia, 2 horas, 30 minutos, 0 segundos
```

- **Propriedades:** O `TimeSpan` possui várias propriedades para obter partes específicas da duração.
```csharp
TimeSpan duracao = new TimeSpan(1, 2, 30, 0);
int dias = duracao.Days; // Obtém o número de dias
int horas = duracao.Hours; // Obtém o número de horas
int minutos = duracao.Minutes; // Obtém o número de minutos
int segundos = duracao.Seconds; // Obtém o número de segundos
int milissegundos = duracao.Milliseconds; // Obtém o número de milissegundos

// From
TimeSpan t1 = TimeSpan.FromDays(1.5);
TimeSpan t2 = TimeSpan.FromHours(1.5);
TimeSpan t3 = TimeSpan.FromMinutes(1.5);
TimeSpan t4 = TimeSpan.FromSeconds(1.5);
TimeSpan t5 = TimeSpan.FromMilliseconds(1.5);
TimeSpan t6 = TimeSpan.FromTicks(900000000L);
```

- **Operações Aritméticas:** Você pode realizar operações aritméticas com objetos `TimeSpan`.
```csharp
TimeSpan duracao1 = new TimeSpan(1, 0, 0); // 1 hora
TimeSpan duracao2 = new TimeSpan(0, 30, 0); // 30 minutos
TimeSpan soma = duracao1 + duracao2; // 1 hora e 30 minutos
TimeSpan subtracao = duracao1 - duracao2; // 30 minutos
```

- **Métodos Úteis:** O `TimeSpan` possui métodos para adicionar e subtrair durações, calcular o total de dias, horas, etc.
```csharp
TimeSpan duracao = new TimeSpan(1, 2, 30, 0);
TimeSpan maisUmaHora = duracao.Add(TimeSpan.FromHours(1)); // Adiciona uma hora
TimeSpan menosUmaHora = duracao.Subtract(TimeSpan.FromHours(1)); // Subtrai uma hora
double totalHoras = duracao.TotalHours; // Obtém o total de horas como um número decimal
```

- **Formatando Saída:** Você pode formatar a representação de `TimeSpan` em strings.
```csharp
TimeSpan duracao = new TimeSpan(1, 2, 30, 0);
string duracaoFormatada = duracao.ToString(@"d\.hh\:mm\:ss"); // Formato customizado
```

O `TimeSpan` é extremamente útil para representar durações, intervalos e calcular diferenças entre datas e horas. Ele é usado em situações onde você precisa lidar com intervalos de tempo de maneira precisa e flexível.

## `DateTimeKind`
O `DateTimeKind` é uma enumeração em C# que define três valores que representam os diferentes tipos de informações de fuso horário associadas a um objeto DateTime: `Unspecified`, `Utc` e `Local`. Esses valores ajudam a determinar como uma data e hora específica deve ser interpretada em relação ao fuso horário.

- `Unspecified`: Indica que o objeto `DateTime` não possui informações de fuso horário. Isso significa que o valor representa uma data e hora, mas sem a especificação do fuso horário. Quando um `DateTime` é criado a partir de uma `string` ou outro valor sem informações explícitas de fuso horário, ele é definido como `Unspecified` por padrão.

- `Utc`: Indica que o objeto `DateTime` representa uma data e hora no formato UTC (Tempo Universal Coordenado). O valor armazenado é independente do fuso horário local.

- `Local`: Indica que o objeto `DateTime` representa uma data e hora no fuso horário local do sistema onde o programa está sendo executado.

Aqui está um exemplo de como o `DateTimeKind` pode ser usado:
```csharp
DateTime dataUtc = DateTime.UtcNow; // Obtém a data e hora UTC atual
DateTime dataLocal = DateTime.Now; // Obtém a data e hora local atual

Console.WriteLine(dataUtc); // Saída: 7/15/2023 9:30:00 AM
Console.WriteLine(dataUtc.Kind); // Saída: Utc

Console.WriteLine(dataLocal); // Saída: 7/15/2023 2:30:00 AM
Console.WriteLine(dataLocal.Kind); // Saída: Local
```

Para converter um `DateTime` para `Local` ou `Utc`, você deve usar:
```csharp
myDate.ToLocalTime()
myDate.ToUniversalTime()


// Ou
DateTime d1 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Local);
DateTime d2 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Utc);
```

## Padrão ISO 8601
-  https://www.iso.org/iso-8601-date-and-time-format.html 
-  https://en.wikipedia.org/wiki/ISO_8601

O **padrão ISO 8601** é um padrão internacional para representar datas e horas de maneira legível e unificada. Ele define formatos de representação que incluem informações sobre o ano, mês, dia, hora, minuto, segundo e, opcionalmente, o fuso horário.

Um exemplo de representação de data e hora no formato **ISO 8601** seria:
```txt
2023-07-15T09:30:00Z
```

**Onde:**
- 2023 é o ano.
- 07 é o mês.
- 15 é o dia.
- 09 é a hora.
- 30 é o minuto.
- 00 é o segundo.
- Z indica que o tempo está no fuso horário UTC.

A representação ISO 8601 é amplamente utilizada em sistemas de armazenamento de datas e troca de informações entre diferentes sistemas, pois fornece um formato padronizado que evita ambiguidades relacionadas a diferentes convenções de formatação de datas e horas em diferentes regiões do mundo.