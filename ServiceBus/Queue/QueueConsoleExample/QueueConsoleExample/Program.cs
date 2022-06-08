using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using QueueConsoleExample;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

/*string ConnectionString = "Endpoint=sb://trngahmedabd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kkNMAoMhIPaQouXaiB570uBPdiXSba1lHxOHebdJ5go=";
string QueueName = "order-queue-nikunj";

await using var client = new ServiceBusClient(ConnectionString);
ServiceBusSender sender = client.CreateSender(QueueName);*/

/*ServiceBusMessage message = new ServiceBusMessage("Hello World!");
await sender.SendMessageAsync(message);
*/
/*ServiceBusReceiver receiver = client.CreateReceiver(QueueName);
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
await receiver.CompleteMessageAsync(receivedMessage);
string body = receivedMessage.Body.ToString();
Console.WriteLine(body);*/

/*await using var client = new ServiceBusClient("Endpoint=sb://trngahmedabd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kkNMAoMhIPaQouXaiB570uBPdiXSba1lHxOHebdJ5go=");
ServiceBusReceiver receiver = client.CreateReceiver("makepayment-nikunj");
ServiceBusReceivedMessage receivedMessage;

SqlConnection connection = new SqlConnection("Server=EFICYIT-LT12;Database=eModal_MajorProject;Trusted_Connection=True;MultipleActiveResultSets=true");
SqlDataAdapter dataAdapter;
DataTable dataTable = new DataTable();

while (true)
{
    receivedMessage = await receiver.ReceiveMessageAsync();
    string MessageBody = receivedMessage.Body.ToString();
    var payment = JsonConvert.DeserializeObject<Payment>(MessageBody);

    connection.Open();
    dataAdapter = new SqlDataAdapter("SELECT Count(*) As Records from payment_details", connection);
    dataAdapter.Fill(dataTable);
    connection.Close();

    payment.TransactionNumber = "TRANS0000" + Convert.ToString(Convert.ToInt32(dataTable.Rows[0]["Records"])+1);
    dataTable.Clear();

    connection.Open();
    dataAdapter = new SqlDataAdapter($"INSERT INTO payment_details(transactionId,userId,containerId,amount) VALUES ('{payment.TransactionNumber}','{payment.UserId}','{payment.ContainerId}','{payment.Amount}')", connection);
    dataAdapter.Fill(dataTable);
    connection.Close();
    await receiver.CompleteMessageAsync(receivedMessage);
}
class Payment
{
    [JsonProperty(PropertyName = "transactionId")]
    public string TransactionNumber { get; set; } = "";
    [JsonProperty(PropertyName = "userId")]
    [Required]
    public string UserId { get; set; }
    [JsonProperty(PropertyName = "containerId")]
    [Required]
    public string ContainerId { get; set; }
    [JsonProperty(PropertyName = "amount")]
    [Required]
    public string Amount { get; set; }
}*/

/*SqlConnection _con ;
_con = new SqlConnection("Server=EFICYIT-LT12;Database=eModal_MajorProject;Trusted_Connection=True;MultipleActiveResultSets=true");
SqlDataAdapter dataAdapter;
DataTable dataTable = new DataTable();
dataAdapter = new SqlDataAdapter($"SELECT * FROM payment_details WHERE containerId='TCNU7233062'", _con);
dataAdapter.Fill(dataTable);
_con.Close();
if (dataTable.Rows.Count != 0)
{
    dataTable.Clear();
    Console.WriteLine("Record Found");
    
}
dataTable.Clear();
Console.WriteLine("Record Found");*/

//Connection String
string ConnectionString = "Endpoint=sb://trngahmedabd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kkNMAoMhIPaQouXaiB570uBPdiXSba1lHxOHebdJ5go=";
//Topic Name
string TopicName = "payment-topic";
//Subscription Name
string subscriptionName = "paymentSubscriber";

//Creating Client
ServiceBusClient ServiceBusClient;
ServiceBusProcessor processor;

static async Task MessageHandler(ProcessMessageEventArgs args)
{
    string MessageBody = args.Message.Body.ToString();
    var paymentData = JsonConvert.DeserializeObject<Payment>(MessageBody);
    Console.WriteLine(MessageBody);
    PaymentDB payment = new PaymentDB();
    paymentData.TransactionId = payment.GenerateTransactionId();
    Console.WriteLine(paymentData.TransactionId+" "+paymentData.UserId);
    //payment.MakePayment(paymentData);
    await args.CompleteMessageAsync(args.Message);
}

static Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}


    ServiceBusClient = new ServiceBusClient(ConnectionString);
    processor = ServiceBusClient.CreateProcessor(TopicName, subscriptionName, new ServiceBusProcessorOptions());
    try
    {
        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;
        await processor.StartProcessingAsync();

        while (true) { }

        await processor.StopProcessingAsync();
    }
    finally
    {
        await processor.DisposeAsync();
        await ServiceBusClient.DisposeAsync();
    }


class Payment
{
    [JsonProperty(PropertyName = "transactionId")]
    [Required]
    public string TransactionId { get; set; }
    [JsonProperty(PropertyName = "userId")]
    [Required]
    public string UserId { get; set; }
    [JsonProperty(PropertyName = "containerId")]
    [Required]
    public string ContainerId { get; set; }
    [JsonProperty(PropertyName = "amount")]
    [Required]
    public string Amount { get; set; }
    [JsonProperty(PropertyName = "paymentdate")]
    public string PaymentDate { get; set; } = DateTime.Now.ToString();
}