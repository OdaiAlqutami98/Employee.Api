using Employee.DataModel;
using Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Logic.Manager
{
    public  class EmployeeManager:BaseManager<Employees,EmployeeDbContext>
    {
        public EmployeeManager(EmployeeDbContext context):base (context)
        {
            
        }
    }
}
