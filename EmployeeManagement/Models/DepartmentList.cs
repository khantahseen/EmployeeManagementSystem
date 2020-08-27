using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class DepartmentList
    {
        static List<Department> departmentList = null;
        static DepartmentList()
        {
            departmentList = new List<Department>()
            {
            new Department(){DepartmentID= 1, DepartmentName= "IT"}
            
           };
        }

        public static List<Department> GetDepartmentList()
        {
            return departmentList;
        }

        public static void AddToDepartmentList(Department dep)
        {
            dep.DepartmentID = departmentList.Max(m => m.DepartmentID);
            dep.DepartmentID += 1;
            departmentList.Add(dep);
        }

        public static void EditInDepartmentList(Department dep)
        {
            Department editDepartment = departmentList.Find(x => x.DepartmentID == dep.DepartmentID);
            editDepartment.DepartmentID = dep.DepartmentID;
            editDepartment.DepartmentName = dep.DepartmentName;
        }

        public static void DeleteInDepartmentList(int id)
        {
            Department deleteDepartment = departmentList.Find(x => x.DepartmentID == id);
            departmentList.Remove(deleteDepartment);
        }
    }
}
