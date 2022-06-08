using DotNetWebApplication.Models;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DotNetWebApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {

        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();

        public UsersController()
        {
            _con = new SqlConnection("Server=EFICYIT-LT12;Database=user_details_db;Trusted_Connection=True;MultipleActiveResultSets=true");
            _con.Open();
        }

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            dataAdapter = new SqlDataAdapter("SELECT userId,firstName,lastName,address,city,state,country,email,contact FROM user_details", _con);
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

        // GET: api/Users/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Users
        public string Post([System.Web.Http.FromBody]User user)
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

        // PUT: api/Users/5
        public string Put(string id, [System.Web.Http.FromBody] User user)
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

        // DELETE: api/Users/5
        public string Delete(string id)
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
