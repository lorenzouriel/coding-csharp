using System;
using System.Collections.Generic;

using Azure;
using Azure.Communication;
using Azure.Communication.Sms;

// This code retrieves your connection string from an environment variable.
string connectionString = "";

SmsClient smsClient = new SmsClient(connectionString);
smsClient.Send(
from: "+11947788209",
    to: "+11947788209",
    message: """Hello World 👋🏻 via SMS"""
);
