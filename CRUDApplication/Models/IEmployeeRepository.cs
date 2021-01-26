using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public interface IEmployeeRepository
    {
        public Employee Add(Employee employee);

        public Employee Delete(int Id);

        public Employee Update(Employee employee);

        public Employee GetEmployee(int Id);

        public IEnumerable<Employee> GetAllEmployee();
    }
}
