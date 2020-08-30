using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        [StringLength(20, MinimumLength =3, ErrorMessage ="The length of the field should be between 6 and 20")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of the field should be between 6 and 20")]
        public string Surname { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 15, ErrorMessage = "The length of the field should be between 15 and 100")]
        public string Address { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public long ContactNumber { get; set; }
        public int DepartmentID { get; set; }
        public Department department { get; set; }
    }
}
