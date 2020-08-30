using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository: IEmployeeRepository
    {
        public List<Employee> SelectAllEmployees()
        {
            return EmployeeList.GetEmployeeList();
        }

        public Employee GetEmployeeById(int id)
        {
            return EmployeeList.GetEmployeeList().Find(x => x.EmployeeID == id);
        }

        public Employee AddEmployee(Employee emp)
        {
            return EmployeeList.AddToList(emp);
        }

        public Employee EditEmployee(int id, Employee emp)
        {
            return EmployeeList.EditInList(id, emp);
        }

        public void DeleteEmployee(int id)
        {
            EmployeeList.DeleteInList(id);
        }
    }
}
