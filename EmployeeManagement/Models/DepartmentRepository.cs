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

        public Department AddDepartment(Models.Department dep)
        {
            return DepartmentList.AddToDepartmentList(dep);
        }

        public Department EditDepartment(int id,Models.Department dep)
        {
            return DepartmentList.EditInDepartmentList(id,dep);
        }

        public void DeleteDepartment(int id)
        {
            DepartmentList.DeleteInDepartmentList(id);
        }
    }
}
