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
        void AddEmployee(Employee emp);
        void EditEmployee(Employee emp);
        void DeleteEmployee(int id);
    }
}
