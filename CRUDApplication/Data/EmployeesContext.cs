using CRUDApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApplication.Data
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
