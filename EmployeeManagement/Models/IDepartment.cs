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
        Department AddDepartment(Department dep);
        Department EditDepartment(int id,Department dep);
        void DeleteDepartment(int id);
    }
}
