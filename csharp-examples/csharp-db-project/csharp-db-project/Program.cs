using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace csharp_db_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool dbstatus = new Server(@"EFICYIT-LT12").Databases.Contains("productdb");

            SqlConnection sqlcon = new SqlConnection(@"Data Source = EFICYIT-LT12; Integrated Security = True");
            SqlDataAdapter adapter;
            DataTable dt;
            sqlcon.Open();

            string sqlqry = "";
            
            if(!dbstatus)
            {
                sqlqry = "CREATE DATABASE productdb";
                adapter = new SqlDataAdapter(sqlqry, sqlcon);
                dt = new DataTable();
                adapter.Fill(dt);
                sqlcon = new SqlConnection(@"Data Source = EFICYIT-LT12;Initial Catalog=productdb;Integrated Security = True");
                sqlqry = "CREATE TABLE product(Id INT IDENTITY PRIMARY KEY, Name VARCHAR(20) NOT NULL, Qty INT NOT NULL, Price MONEY NOT NULL, Date VARCHAR(30) DEFAULT '', Sales INT NOT NULL DEFAULT 0)";
                adapter = new SqlDataAdapter(sqlqry, sqlcon);
                dt = new DataTable();
                adapter.Fill(dt);
            }

            dbstatus = new Server(@"EFICYIT-LT12").Databases.Contains("productdb");
            if (dbstatus)
            {
                sqlcon = new SqlConnection(@"Data Source = EFICYIT-LT12;Initial Catalog=productdb;Integrated Security = True");
                string recordinst = "Y";
                while (recordinst == "Y" || recordinst == "y")
                {
                    Console.WriteLine("\n*************************\n1.Insert Product\n2.Show Product\n3.Sell Product\n4.Weekly AVG\nProvide Your Input");
                    int funcall = Convert.ToInt32(Console.ReadLine());

                    switch (funcall)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Provide Name of The Product:");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Provide Quantity: ");
                            int Qty = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Provide Price: ");
                            int Price = Convert.ToInt32(Console.ReadLine());
                            sqlqry = $"INSERT INTO product(Name,Qty,Price) VALUES('{Name}',{Qty},{Price})";
                            adapter = new SqlDataAdapter(sqlqry, sqlcon);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            Console.Clear();
                            Console.WriteLine("Product Record Inserted Successfully!");
                            break;
                        case 2:
                            Console.Clear();
                            sqlqry = "SELECT * FROM product";
                            adapter = new SqlDataAdapter(sqlqry, sqlcon);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            Console.WriteLine("#\tNAME\tQTY\tPRICE\t\tSALES\t\tDATE");
                            foreach (DataRow dr in dt.Rows)
                                Console.WriteLine(dr["Id"]+"\t "+dr["Name"]+"\t "+dr["Qty"]+"\t "+dr["Price"]+"\t "+dr["Sales"]+"\t "+dr["Date"]);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            //Printing Records
                            sqlqry = "SELECT * FROM product";
                            adapter = new SqlDataAdapter(sqlqry, sqlcon);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            Console.WriteLine("Listed Products:\n#\tNAME\tQTY");
                            foreach (DataRow dr in dt.Rows)
                                Console.WriteLine(dr["Id"] + "\t " + dr["Name"]+"\t "+dr["Qty"]);
                            //Getting Quantities
                            Console.WriteLine("\nProvide Index of The Product:");
                            int Pid = Convert.ToInt32(Console.ReadLine());
                            sqlqry = $"SELECT * FROM product WHERE Id={Pid}";
                            adapter = new SqlDataAdapter(sqlqry, sqlcon);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            int recqty=0,recsales=0;
//                            Console.WriteLine(Convert.ToString(dt.Rows["Id"]));
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (Convert.ToInt32(dr["Id"]) == Pid)
                                {
                                    recqty = Convert.ToInt32(dr["Qty"]);
                                    recsales = Convert.ToInt32(dr["Sales"]);
                                }
                            }
                            Console.WriteLine("Provide Number of Quantities Sale: ");
                            int Sales = Convert.ToInt32(Console.ReadLine());
                            recqty -= Sales;
                            recsales += Sales;
                            string date = Convert.ToString(DateTime.Now.ToShortDateString());
                            //int qty=dt.Rows["Qty"];
                            sqlqry = $"UPDATE product SET Qty={recqty},Sales={recsales}, Date='{date}' WHERE Id={Pid}";
                            adapter = new SqlDataAdapter(sqlqry, sqlcon);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            Console.Clear();
                            Console.WriteLine("Record Updated Successfully!");
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Last Weeks Average Sales:");
                            
                            sqlqry = "SELECT * FROM product";
                            adapter = new SqlDataAdapter(sqlqry, sqlcon);
                            dt = new DataTable();
                            adapter.Fill(dt);
                            var pdct=new List<Product>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                pdct.Add(new Product() {Id=Convert.ToInt32(dr["Id"]),Name= Convert.ToString(dr["Name"]), Qty=Convert.ToInt32(dr["Qty"]),Price= Convert.ToInt32(dr["Price"]),Sales= Convert.ToInt32(dr["Sales"]),Date= Convert.ToString(dr["Date"]) });
                            }
                            DateTime today = DateTime.Now;
                            int c = 0,sum = 0,weeksale=0;
                            foreach (Product p in pdct)
                            {
                                DateTime dtd = DateTime.Parse(p.Date);
                                TimeSpan datediff = today - dtd;
                                if(datediff.Days >= 0 && datediff.Days<7)
                                {
                                    c++;
                                    sum+=p.Sales;
                                }
                            }
                            weeksale = Convert.ToInt32(sum / c);
                            Console.WriteLine("Weekly Sale: "+weeksale);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Database Connectivity is Not Working!");
            }
            sqlcon.Close();
        }
        
        class Product {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Qty { get; set; }
            public int Price { get; set; }
            public string Date { get; set; }
            public int Sales { get; set; }
        }
    }
}
