using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssmsDataConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=EFICYIT-LT12;Initial Catalog=Customers;Integrated Security=True");
            SqlDataAdapter sqlad = new SqlDataAdapter("Select * from dbo.Customer_Detail",sqlcon);
            DataTable dtbl = new DataTable();
            sqlad.Fill(dtbl);
//            Console.WriteLine(dtbl.Columns);
            foreach (DataRow dr in dtbl.Rows)
            {
                Console.WriteLine(dr["name"] + " " + dr["dbid"]);
            }
            Console.ReadLine();
        }
    }
}
