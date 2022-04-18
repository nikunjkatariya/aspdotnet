using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            SqlConnection sqlcon = new SqlConnection(@"Data Source = EFICYIT-LT12;Initial Catalog=chatdb;Integrated Security = True");
                        DataTable dt = new DataTable();
                        sqlcon.Open();
                        string sqlqry = "";
                        SqlDataAdapter adapter = new SqlDataAdapter(sqlqry, sqlcon);*/
            try
            {
                bool status = true;
                string servermessage = "";
                string clientmessage = "";
                TcpListener tcpListener = new TcpListener(8100);
                tcpListener.Start();
                Console.WriteLine("Server Started");
                Socket socketForClient = tcpListener.AcceptSocket();
                Console.WriteLine("Client Connected");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                StreamWriter streamwriter = new StreamWriter(networkStream);
                StreamReader streamreader = new StreamReader(networkStream);
                while (status)
                {
                    if (socketForClient.Connected)
                    {
                        servermessage = streamreader.ReadLine();
                        Console.WriteLine("Client:" + servermessage);
                        if ((servermessage == "bye"))
                        {
                            status = false;
                            streamreader.Close();
                            networkStream.Close();
                            streamwriter.Close();
                            return;
                        }
                        Console.Write("Server:");
                        clientmessage = Console.ReadLine();
                        streamwriter.WriteLine(clientmessage);
                        streamwriter.Flush();
                    }
                }
                streamreader.Close();
                networkStream.Close();
                streamwriter.Close();
                socketForClient.Close();
                Console.WriteLine("Exiting");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
