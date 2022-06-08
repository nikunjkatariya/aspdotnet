using DotNetCoreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();

        public UsersController(IConfiguration configuration)
        {
            _con = new SqlConnection(configuration.GetConnectionString("UserDB"));
            _con.Open();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            dataAdapter = new SqlDataAdapter("EXEC SelectAllUsers", _con);
            dataAdapter.Fill(dataTable);
            _con.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(new User
                {
                    UserId = Convert.ToString(row["userId"]),
                    FirstName = Convert.ToString(row["firstName"]),
                    LastName = Convert.ToString(row["lastName"]),
                    Address = Convert.ToString(row["address"]),
                    City = Convert.ToString(row["city"]),
                    State = Convert.ToString(row["state"]),
                    Country = Convert.ToString(row["country"]),
                    Email = Convert.ToString(row["email"]),
                    Contact = Convert.ToString(row["contact"])
                });
            }
            return users;
        }

        // GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                dataAdapter = new SqlDataAdapter($"EXEC AddUser @firstName='{user.FirstName}' ,@lastName='{user.LastName}' ,@address='{user.Address}' ,@city='{user.City}',@state='{user.State}',@country='{user.Country}',@email='{user.Email}' ,@contact='{user.Contact}'", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
            }
            catch(Exception ex)
            {
                using (StreamWriter stream = new FileInfo(@"C:\Users\raytex\source\repos\Product Training Work\Task 1\Logs.txt").AppendText())
                {
                    stream.WriteLine(ex.ToString());
                }
                return BadRequest(ex.ToString());
            }
            return Ok("Inserted Successfully!");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            try
            {
                dataAdapter = new SqlDataAdapter($"EXEC UpdateUser @id='{id}' ,@firstName='{user.FirstName}' ,@lastName='{user.LastName}' ,@address='{user.Address}' ,@city='{user.City}',@state='{user.State}',@country='{user.Country}',@email='{user.Email}' ,@contact='{user.Contact}'", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
            }
            catch (Exception ex)
            {
                using (StreamWriter stream = new FileInfo(@"C:\Users\raytex\source\repos\Product Training Work\Task 1\Logs.txt").AppendText())
                {
                    stream.WriteLine(ex.ToString());
                }
                return BadRequest(ex.ToString());
            }
            return Ok("Record Updated Successfully!");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                dataAdapter = new SqlDataAdapter($"EXEC DeleteUser @id='{id}'", _con);
                dataAdapter.Fill(dataTable);
                _con.Close();
            }
            catch (Exception ex)
            {
                using (StreamWriter stream = new FileInfo(@"C:\Users\raytex\source\repos\Product Training Work\Task 1\Logs.txt").AppendText())
                {
                    stream.WriteLine(ex.ToString());
                }
                return BadRequest(ex.ToString());
            }
            return Ok("Record Deleted Successfully!");
        }
    }
}
