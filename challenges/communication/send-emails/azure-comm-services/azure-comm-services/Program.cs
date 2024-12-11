using System;
using System.Net.Mime;
using Azure;
using Azure.Communication.Email;

// This code retrieves your connection string from an environment variable.
string connectionString = "endpoint=https://comapny-comm-service.unitedstates.communication.azure.com/;accesskey=???";
var emailClient = new EmailClient(connectionString);

// Create the email content
var emailContent = new EmailContent("SUA FATURA CHEGOU")
{
    PlainText = "SUA FATURA CHEGOU",
    Html = " "
};

// Create the EmailMessage
var emailMessage = new EmailMessage(
    senderAddress: "DoNotReply@f4198eb2-08d6-4387-8417-98df00869395.azurecomm.net", // The email address of the domain registered with the Communication Services resource
    recipientAddress: "lorenzouriel394@gmail.com",
    content: emailContent);

// Create the EmailAttachment
var filePath = "C:\\7po0E.pdf";
byte[] bytes = File.ReadAllBytes(filePath);
var contentBinaryData = new BinaryData(bytes);
var emailAttachment = new EmailAttachment("7po0E.pdf", MediaTypeNames.Application.Pdf, contentBinaryData);

emailMessage.Attachments.Add(emailAttachment);

try
{
    EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);
    Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
    string operationId = emailSendOperation.Id;
    Console.WriteLine($"Email operation id = {operationId}");
}
catch (RequestFailedException ex)
{
    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
    Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
}