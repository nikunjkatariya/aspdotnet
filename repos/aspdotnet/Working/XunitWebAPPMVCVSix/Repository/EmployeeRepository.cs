using XunitWebAPPMVCVSix.Contracts;
using XunitWebAPPMVCVSix.Models;

namespace XunitWebAPPMVCVSix.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public IEnumerable<Models.Employee> GetAll() => _context.Employee.ToList();

        public Models.Employee GetEmployee(Guid id) => _context.Employee.SingleOrDefault(e=>e.Id.Equals(id));

        public void CreateEmployee(Models.Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
    }
}
