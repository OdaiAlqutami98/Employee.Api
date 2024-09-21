using Employee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DataModel
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> option):base(option)
        {
            
        }
        //Add-Migration initialize -project "Employee.DataModel" 
        //update-database  -project "Employee.DataModel" 
         public DbSet<Employees> Employees { get; set; }   
    }
}
