using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Web1.Models;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersADOController : ControllerBase
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();
        public CustomersADOController()
        {
            _con = new SqlConnection("Server=EFICYIT-LT12;Database=customerdetails;Trusted_Connection=True;MultipleActiveResultSets=true");
//            _con = new SqlConnection("DataSource=EFICYIT-LT12;InitialCatalog=customerdetails;IntegratedSecurity=False;UserId=root;Password=root;MultipleActiveResultSets=True");
            _con.Open();
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            dataAdapter = new SqlDataAdapter("EXEC selectcustomers", _con);
            dataAdapter.Fill(dataTable);
            _con.Close();
            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(new Customer
                {
                    Id = Convert.ToInt32(row["id"]),
                    FirstName = Convert.ToString(row["firstName"]),
                    LastName = Convert.ToString(row["lastName"]),
                    City = Convert.ToString(row["city"])
                });
            }
            return customers;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return GetCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return GetCustomers().Find(c => c.Id == id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dataAdapter = new SqlDataAdapter($"INSERT INTO customers(firstName,lastName,city) VALUES('{customer.FirstName}','{customer.LastName}','{customer.City}')", _con);
                dataAdapter.Fill(dataTable);
                return RedirectToAction(nameof(Index));
            }
            return customer;
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
