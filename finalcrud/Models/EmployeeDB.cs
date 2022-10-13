using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace finalcrud.Models
{
    public class EmployeeDB:DbContext
    {
        public EmployeeDB() : base("EmpInfo")
        {

        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }

   
}