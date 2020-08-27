using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    interface IDepartment
    {
        List<Department> SelectDepartment();
        Department GetDepartmentById(int id);
        void AddDepartment(Department dep);
        void EditDepartment(Department dep);
        void DeleteDepartment(int id);
    }
}
