using CRUDApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Models
{
    public class SqlRepository : IEmployeeRepository
    {
        private readonly EmployeesContext _db;
       
        public SqlRepository(EmployeesContext db)
        {
            _db = db;
        }
        public Employee Add(Employee employee)
        {
            _db.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _db.Employees.FirstOrDefault(x => x.Id == Id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _db.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = _db.Employees.FirstOrDefault(x => x.Id == Id);

                return employee;
           
        }

        public Employee Update(Employee employee)
        {
            int Id = employee.Id;
            var emp = _db.Employees.FirstOrDefault(x => x.Id == Id);
            
            emp.Name = employee.Name;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.Department = employee.Department;
            _db.Update(emp);
            _db.SaveChanges();

            return emp;
        }
    }
}
