using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeList
    {
        static List<Employee> employeeList = null;
        static EmployeeList()
        {
            employeeList = new List<Employee>()
            {
            new Employee(){EmployeeID = 1, Name = "Tahseen", Surname = "Khan", Address = "Vadodara,Gujarat", ContactNumber = 11223344, Qualification="Graduate"}
           };
        }

        public static List<Employee> GetEmployeeList()
        {
            return employeeList;
        }

        public static void AddToList(Employee emp)
        {
            emp.EmployeeID = employeeList.Max(m => m.EmployeeID);
            emp.EmployeeID += 1;


            employeeList.Add(emp);
        }

        public static void EditInList(Employee emp)
        {
            Employee editEmployee = employeeList.Find(x => x.EmployeeID == emp.EmployeeID);
            editEmployee.EmployeeID = emp.EmployeeID;
            editEmployee.Name = emp.Name;
            editEmployee.Surname = emp.Surname;
            editEmployee.Address = emp.Address;
            editEmployee.ContactNumber = emp.ContactNumber;
            editEmployee.Qualification = emp.Qualification;
        }
        
        public static void DeleteInList(int id)
        {
            Employee deleteEmployee = employeeList.Find(x => x.EmployeeID == id);
            employeeList.Remove(deleteEmployee);
        }
    }
}
