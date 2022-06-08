// See https://aka.ms/new-console-template for more information
using System;
using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;

namespace TopicSender
{
    class Program
    {
        //Connection String
        static string ConnectionString = "Endpoint=sb://trngahmedabd.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=kkNMAoMhIPaQouXaiB570uBPdiXSba1lHxOHebdJ5go=";
        //Topic Name
        static string TopicName = "tranx-nikunj";

        //Creating Client
        static ServiceBusClient client;
        static ServiceBusSender sender;

        //Number of Messages to be sent to the Topic
        private const int NumofMessages = 1;
    
        public static async Task Main()
        {
            client = new ServiceBusClient(ConnectionString);
            sender = client.CreateSender(TopicName);
            
            //Creating Batch => Message is passing in Batch
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            for(int i = 1; i <= NumofMessages; i++)
            {
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    throw new Exception($"The message {i} is too large");
                }
            }

            try
            {
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"A batch {NumofMessages} has been Published!");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
            Console.WriteLine("Press a Button!");
            Console.ReadKey();
        }
    }
}


