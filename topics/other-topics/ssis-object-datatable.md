# Explanation of Objects and Data Tables on SSIS

## Object Variable
An **object variable** is a variable that holds a reference to an object rather than a primitive value. In this context:
- `Dts.Variables["User::objects"].Value` is an object variable that contains some data structure (likely a recordset or dataset)
- Object variables can hold complex data types that can't be stored in simple string or numeric variables
- They're useful in SSIS for passing complex data between components

## COM Types
**COM (Component Object Model) types** are legacy data types used in Windows for interoperability between components:
- In SSIS, some data sources return COM objects (like ADO recordsets)
- These need to be converted to .NET types for use in C# code
- The code handles this conversion using OleDbDataAdapter

## Why Use OleDbDataAdapter?
The code uses `OleDbDataAdapter` to convert the input data (likely a COM recordset) to a DataTable because:
1. SSIS often passes data between components as COM objects (ADO recordsets)
2. OleDbDataAdapter can work with these legacy COM types
3. It provides a simple way to convert to a .NET DataTable which is easier to work with in C#
4. The `Fill()` method automatically creates the DataTable structure and populates it with data

## DataTable
A **DataTable** is a .NET class that represents an in-memory table of data:
- It has rows (DataRow) and columns (DataColumn)
- Provides methods to query and manipulate tabular data
- In this code, it serves as an intermediate format between the COM object and the JSON payload

## Code Walkthrough

### 1. Getting Input Data
```csharp
var apiUrl = Dts.Variables["User::api"].Value.ToString();
var accessToken = Dts.Variables["User::accessToken"].Value.ToString();
var data = Dts.Variables["User::objects"].Value;
```
- Retrieves SSIS variables containing API URL, auth token, and the data to process

### 2. Data Conversion
```csharp
var dt = new DataTable();
new OleDbDataAdapter().Fill(dt, data);
```
- Creates empty DataTable
- Uses OleDbDataAdapter to fill it with data from the COM object

### 3. Preparing Payload
```csharp
var payload = new {
    positionPeople = new List<object>()
};

foreach (DataRow row in dt.Rows)
{
    payload.positionPeople.Add(new {
        name = row["name"].ToString(),
        people = Convert.ToInt32(row["people"]),
        date = Convert.ToDateTime(row["date"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
    });
}
```
- Creates an anonymous object with a list of position people
- Iterates through DataTable rows, converting each to an object with proper data types
- Formats the date to ISO 8601 format

### 4. Sending to API
```csharp
var response = SendToApi(apiUrl, accessToken, payload);
```
- Calls helper method to send the payload to the API

### SendToApi Method
```csharp
private HttpResponseMessage SendToApi(string apiUrl, string accessToken, object payload)
{
    using (var client = new HttpClient())
    {
        var endpoint = $"{apiUrl.TrimEnd('/')}/peoplePositions";
        var content = new StringContent(
            JsonConvert.SerializeObject(payload),
            Encoding.UTF8,
            "application/json"
        );

        client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        return client.PostAsync(endpoint, content).Result;
    }
}
```
- Creates HTTP client
- Builds endpoint URL
- Serializes payload to JSON
- Adds authorization header
- Sends POST request and returns response

### Error Handling
- Wrapped in try-catch to handle any exceptions
- Reports errors back to SSIS if they occur

This script essentially takes vehicle position data from an SSIS variable, converts it to a proper format, and sends it to a REST API endpoint.