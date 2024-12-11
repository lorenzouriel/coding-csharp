//using System;
//using System.Collections.Generic;
//using Azure;
//using Azure.Communication.Email;

//// This code retrieves your connection string from an environment variable.
//string connectionString = "endpoint=https://comapny-comm-service.unitedstates.communication.azure.com/;accesskey=???";
//var emailClient = new EmailClient(connectionString);


//EmailSendOperation emailSendOperation = emailClient.Send(
//    WaitUntil.Completed,
//    senderAddress: "DoNotReply@f4198eb2-08d6-4387-8417-98df00869395.azurecomm.net",
//    recipientAddress: "lorenzouriel394@gmail.com",
//    subject: "Test Email",
//    htmlContent: "<html><h1>Hello world via email.</h1l></html>",
//    plainTextContent: "Hello world via email.");
