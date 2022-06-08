using CustomerWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CustomerWebApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();
        
        public CustomersController()
        {
            _con = new SqlConnection("Server=EFICYIT-LT12;Database=customerdetails;Trusted_Connection=True;MultipleActiveResultSets=true");
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
                    Id= Convert.ToInt32(row["id"]),
                    FirstName = Convert.ToString(row["firstName"]),
                    LastName = Convert.ToString(row["lastName"]),
                    City = Convert.ToString(row["city"])
                });
            }
            return customers;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View(GetCustomers().Find(c=>c.Id==id));
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,City")] Customer customer)
        {
            if(ModelState.IsValid)
            {
                dataAdapter = new SqlDataAdapter($"INSERT INTO customers(firstName,lastName,city) VALUES('{customer.FirstName}','{customer.LastName}','{customer.City}')",_con);
                dataAdapter.Fill(dataTable);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetCustomers().Find(c=>c.Id==id));
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                dataAdapter = new SqlDataAdapter($"UPDATE customers " +
                    $"SET firstName= '{customer.FirstName}', " +
                    $"lastName='{customer.LastName}', " +
                    $"city='{customer.City}' " +
                    $"WHERE id = {id}", _con);
                dataAdapter.Fill(dataTable);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(GetCustomers().Find(c=>c.Id==id));
        }

        // POST: CustomersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
                dataAdapter = new SqlDataAdapter($"EXEC deletecustomer @Id={id}", _con);
                dataAdapter.Fill(dataTable);
                return RedirectToAction(nameof(Index));
        }
    }
}
