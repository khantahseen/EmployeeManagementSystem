using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    interface IEmployeeRepository
    {
        List<Employee> SelectAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee emp);
        Employee EditEmployee(int id,Employee emp);
        void DeleteEmployee(int id);
    }
}
