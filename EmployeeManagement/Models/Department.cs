using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Department
    {
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(20, MinimumLength =2, ErrorMessage ="The length of Department should be between 2 and 20")]
        public string DepartmentName { get; set; }
    }
}
