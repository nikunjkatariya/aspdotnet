// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace ServiceBusReciever
{
    class Receiver
    {
        static SqlConnection connection = new SqlConnection("Server=EFICYIT-LT12;Database=eModal_MajorProject;Trusted_Connection=True;MultipleActiveResultSets=true");
        static SqlDataAdapter dataAdapter;
        static DataTable dataTable = new DataTable();

        //Connection String
        static string ConnectionString = "Endpoint=sb://trngahmedabd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kkNMAoMhIPaQouXaiB570uBPdiXSba1lHxOHebdJ5go=";
        //Topic Name
        //static string TopicName = "tranx-nikunj";
        static string TopicName = "payment-topic";
        //Subscription Name
        //static string subscriptionName = "P1-nikunj";
        static string subscriptionName = "paymentSubscriber";

        //Creating Client
        static ServiceBusClient ServiceBusClient;
        static ServiceBusProcessor processor;

        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string MessageBody = args.Message.Body.ToString();
            var paymentData = JsonConvert.DeserializeObject<Payment>(MessageBody);
            dataAdapter = new SqlDataAdapter("SELECT Count(*) As Records from payment_details", connection);
            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();
            paymentData.TransactionId = "TRANS0000" + Convert.ToString(Convert.ToInt32(dataTable.Rows[0]["Records"]) + 1);
            string queryString = $"INSERT INTO payment_details(transactionId, userId, containerId, amount) VALUES('{paymentData.TransactionId}', '{paymentData.UserId}', '{paymentData.ContainerId}', '{paymentData.Amount}')";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(paymentData.TransactionId+" "+paymentData.ContainerId+" "+paymentData.UserId+" "+paymentData.Amount);
            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        static async Task Main()
        {
            ServiceBusClient = new ServiceBusClient(ConnectionString);
            processor = ServiceBusClient.CreateProcessor(TopicName, subscriptionName, new ServiceBusProcessorOptions());

            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StartProcessingAsync();

                Console.WriteLine("Waiting...");
                while (true) { }

                //Stop
                Console.WriteLine("Stopping the Reception!");
                await processor.StopProcessingAsync();
            }
            finally
            {
                await processor.DisposeAsync();
                await ServiceBusClient.DisposeAsync();
            }
        }
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
    }
}