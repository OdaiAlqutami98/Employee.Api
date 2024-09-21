using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain
{
    public class Employees
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string HomeAddress { get; set; }
        public string? FilePath { get; set; }
   
    }
}
