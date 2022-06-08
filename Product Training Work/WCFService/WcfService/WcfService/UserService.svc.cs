using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Http.Cors;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    //[EnableCors(origins: "*", headers: " * ", methods: "*")]
    public class UserService : IUserService
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();

        public UserService()
        {
            _con = new SqlConnection("Server=EFICYIT-LT12;Database=user_details_db;Trusted_Connection=True;MultipleActiveResultSets=true");
            _con.Open();
        }

        public IEnumerable<User> GetUser()
        {
            List<User> users = new List<User>();
            dataAdapter = new SqlDataAdapter("SELECT * FROM user_details", _con);
            dataAdapter.Fill(dataTable);
            _con.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(new User
                {
                    userId = Convert.ToString(row["userId"]),
                    firstName = Convert.ToString(row["firstName"]),
                    lastName = Convert.ToString(row["lastName"]),
                    address = Convert.ToString(row["address"]),
                    city = Convert.ToString(row["city"]),
                    state = Convert.ToString(row["state"]),
                    country = Convert.ToString(row["country"]),
                    email = Convert.ToString(row["email"]),
                    contact = Convert.ToString(row["contact"])
                });
            }
            return users;
        }

        public string PostUser(User user)
        {
            try
            {
                dataAdapter = new SqlDataAdapter($"INSERT INTO dbo.user_details(firstName,lastName,address,city,state,country,email,contact) VALUES('{user.firstName}','{user.lastName}','{user.address}','{user.city}','{user.state}','{user.country}','{user.email}','{user.contact}')", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "Inserted Successfully!";
        }

        public string PutUser(string id, User user)
        {
            try
            {
                dataAdapter = new SqlDataAdapter($"UPDATE dbo.user_details SET firstName='{user.firstName}',lastName='{user.lastName}',address='{user.address}',city='{user.city}',state='{user.state}',country='{user.country}',email='{user.email}',contact='{user.contact}' WHERE userId='{id}'", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "Record Updated Successfully!";
        }
        public string DeleteUser(string id)
        {
            try
            {
                dataAdapter = new SqlDataAdapter($"DELETE FROM user_details WHERE userId='{id}'", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "Record Deleted Successfully!";
        }

    }
}
