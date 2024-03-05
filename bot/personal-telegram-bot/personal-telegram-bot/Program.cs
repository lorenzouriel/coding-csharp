// Importando as bibliotecas necessárias do Telegram.Bot
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

// Criando uma instância do bot Telegram com o token de acesso
var botClient = new TelegramBotClient("6839053469:AAEq66s5kwoUlKLJAUKVrSTuGjSKM8E9vOE");

// Criando um objeto para controle de cancelamento (cancelamento de operações assíncronas)
var cancellationToken = new CancellationTokenSource();

// Iniciando o processo de recebimento de mensagens
botClient.StartReceiving(
    updateHandler: UpdateHandlerASync,  // Função chamada quando uma nova mensagem é recebida
    pollingErrorHandler: PollingHandlerAsync,  // Função chamada em caso de erro durante a recepção
    receiverOptions: new ReceiverOptions
    {
        AllowedUpdates = Array.Empty<UpdateType>()  // Configuração para tipos específicos de atualizações permitidas
    },
    cancellationToken: cancellationToken.Token  // Token de cancelamento para interromper o processo quando necessário
);

// Função chamada em caso de erro durante a recepção de mensagens
Task PollingHandlerAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cts)
{
    Console.WriteLine(exception.Message);  // Imprime a mensagem de erro no console
    return Task.CompletedTask;  // Retorna uma tarefa assíncrona completada
}

// Função chamada quando uma nova mensagem é recebida
async Task UpdateHandlerASync(ITelegramBotClient botClient, Update update, CancellationToken cts)
{
    // Verifica se a mensagem é válida
    if (update.Message is not { } message)
        return;

    // Verifica se a mensagem contém texto
    if (message.Text is not { } messageText)
        return;

    // Obtém o ID do chat (local onde a mensagem foi enviada)
    var chatId = message.Chat.Id;

    // Imprime no console a mensagem recebida
    Console.WriteLine($"Mensagem Recebida: {messageText}");

    // Envia uma mensagem de resposta ao mesmo chat
    var sendMessage = await botClient.SendTextMessageAsync(
        chatId: chatId,
        text: "Obrigado pela mensagem, espero poder te responder futuramente!",
        cancellationToken: cts
    );
}

// Obtém informações sobre o próprio bot

var me = await botClient.GetMeAsync(cancellationToken.Token);

// Imprime no console o nome de usuário do bot
Console.WriteLine($"Escutando {me.Username}");

// Aguarda a entrada do usuário no console antes de encerrar o bot
Console.ReadLine();

// Cancela o token de cancelamento, encerrando o processo de recepção de mensagens
cancellationToken.Cancel();
