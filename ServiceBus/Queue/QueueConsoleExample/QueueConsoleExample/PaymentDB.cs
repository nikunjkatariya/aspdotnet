using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueConsoleExample
{
    internal class PaymentDB
    {
        static SqlConnection connection;
        static SqlDataAdapter dataAdapter;

        public PaymentDB()
        {
            connection = new SqlConnection("Server=EFICYIT-LT12;Database=eModal_MajorProject;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public bool MakePayment(Payment payment)
        {
//            payment.TransactionId = GenerateTransactionId();
            string queryString = $"INSERT INTO payment_details(transactionId, userId, containerId, amount,paymentdate) VALUES('{payment.TransactionId}', '{payment.UserId}', '{payment.ContainerId}', '{payment.Amount}','{payment.PaymentDate}')";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }

        public string GenerateTransactionId()
        {
            DataTable dataTable = new DataTable();
            dataAdapter = new SqlDataAdapter("SELECT Count(*) As Records from payment_details", connection);
            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();

            return "TRANS0000" + Convert.ToString(Convert.ToInt32(dataTable.Rows[0]["Records"]) + 1);
        }
    }
}
