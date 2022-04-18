using XunitWebAPPMVCVSix.Models;

namespace XunitWebAPPMVCVSix.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetEmployee(Guid id);
        void CreateEmployee(Employee employee);
    }
}
