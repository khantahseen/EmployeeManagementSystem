using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class DepartmentRepository : IDepartment
    {
        public List<Models.Department> SelectDepartment()
        {
            return DepartmentList.GetDepartmentList();
        }

        public Models.Department GetDepartmentById(int id)
        {
            return DepartmentList.GetDepartmentList().Find(x => x.DepartmentID == id);
        }

        public void AddDepartment(Models.Department dep)
        {
            DepartmentList.AddToDepartmentList(dep);
        }

        public void EditDepartment(Models.Department dep)
        {
            DepartmentList.EditInDepartmentList(dep);
        }

        public void DeleteDepartment(int id)
        {
            DepartmentList.DeleteInDepartmentList(id);
        }
    }
}
