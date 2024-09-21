using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Shared
{
    public class EmployeeModel
    {
        public Guid?  EmployeeId  { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; }
        [Required]
        public string HomeAddress { get; set; }
         public string ImagePath { get; set; }
      // public IFormFile? ImagePath { get; set; }
    }
}
