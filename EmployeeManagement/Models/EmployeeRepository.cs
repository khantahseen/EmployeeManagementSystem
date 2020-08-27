using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public List<Models.Employee> SelectAllEmployees()
        {
            return EmployeeList.GetEmployeeList();
        }

        public Models.Employee GetEmployeeById(int id)
        {
            return EmployeeList.GetEmployeeList().Find(x => x.EmployeeID == id);
        }

        public void AddEmployee(Models.Employee emp)
        {
            EmployeeList.AddToList(emp);
        }

        public void EditEmployee(Models.Employee emp)
        {
            EmployeeList.EditInList(emp);
        }

        public void DeleteEmployee(int id)
        {
            EmployeeList.DeleteInList(id);
        }
    }
}
