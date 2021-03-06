using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source = EFICYIT-LT12;Initial Catalog=chatdb;Integrated Security = True");
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapter;
            bool status = true;
            sqlcon.Open();
            while(status)
            {
                string sqlqry = "Select * from chats where usertype='server' and status=1";
                adapter = new SqlDataAdapter(sqlqry, sqlcon);
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine("Server : " + dr["message"]);
                    sqlqry = $"Update chats set status = 0 where id={dr["id"]}";
                    adapter = new SqlDataAdapter(sqlqry, sqlcon);
                    adapter.Fill(dt1);
                    if(dr["message"]== "bye")
                    {
                        status = false;
                        continue;
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    Console.Write("Client: ");
                    string message=Console.ReadLine();
                    sqlqry = $"INSERT INTO chats(usertype, message, status) VALUES('client','{message}',1)";
                    adapter = new SqlDataAdapter(sqlqry, sqlcon);
                    adapter.Fill(dt1);
                    if (message == "bye")
                    {
                        status= false;
                        continue;
                    }
                    message = "";
                }
                dt.Clear();
            }
        }
    }
}
