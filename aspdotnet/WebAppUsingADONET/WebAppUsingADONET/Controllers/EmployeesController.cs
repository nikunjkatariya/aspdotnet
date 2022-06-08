using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAppUsingADONET.Models;

namespace WebAppUsingADONET.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter _adapter;
        private DataTable dataTable = new DataTable();
        public EmployeesController()
        {
            string sqlcon = "Server=EFICYIT-LT12;Database=employeeadodotnet;Trusted_Connection=True;MultipleActiveResultSets=true";
            _con = new SqlConnection(sqlcon);
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            _adapter = new SqlDataAdapter("SELECT * FROM employees", _con);
            _adapter.Fill(dataTable);
            foreach (DataRow emp in dataTable.Rows)
            {
                employees.Add(new Employee
                {
                    Id = Convert.ToInt32(emp["id"]),
                    FirstName = Convert.ToString(emp["firstName"]),
                    LastName = Convert.ToString(emp["lastName"]),
                    City = Convert.ToString(emp["city"])
                });
            }
            _con.Close();
            return employees;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View(GetEmployees());
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View(GetEmployees().Find(Emp => Emp.Id == id));
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            Employee emp = new Employee();
            return View(emp);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,City")] Employee employee)
        {
            if(ModelState.IsValid)
            {
                _adapter = new SqlDataAdapter($"INSERT INTO employees(firstName,lastName,city) VALUES ('{employee.FirstName}','{employee.LastName}','{employee.City}')", _con);
                _adapter.Fill(dataTable);
                _con.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetEmployees().Find(Emp=>Emp.Id==id));
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,City")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _adapter = new SqlDataAdapter($"UPDATE employees SET firstName='{employee.FirstName}',lastName='{employee.LastName}',city='{employee.City}' WHERE id={employee.Id}", _con);
                _adapter.Fill(dataTable);
                _con.Close();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(GetEmployees().Find(Emp => Emp.Id == id));
        }

        // POST: EmployeesController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _adapter = new SqlDataAdapter($"DELETE FROM employees WHERE id={id}", _con);
            _adapter.Fill(dataTable);
            _con.Close();
            return RedirectToAction(nameof(Index));
        }
    }
}
