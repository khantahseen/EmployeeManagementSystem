using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeList
    {
        static SqlConnection con;
        static List<Employee> employeeList = null;
        static EmployeeList()
        {
            string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            employeeList = new List<Employee>();
            Department department = new Department();
            con = new SqlConnection(connectionstring);
        }

        public static List<Employee> GetEmployeeList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.Employee inner join dbo.Department on Employee.DepartmentID=Department.DepartmentID", con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Employee emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader[0]);
                emp.Name = reader[1].ToString();
                emp.Surname = reader[2].ToString();
                emp.Address = reader[3].ToString();
                emp.Qualification = reader[4].ToString();
                emp.ContactNumber = long.Parse(Convert.ToString(reader[5]));
                emp.DepartmentID = Convert.ToInt32(reader[6]);
                emp.department = new Department();
                emp.department.DepartmentID = Convert.ToInt32(reader[7]);
                emp.department.DepartmentName = reader[8].ToString();
                employeeList.Add(emp);
            }
            con.Close();    
            return employeeList;
        }

        public static Employee AddToList(Employee emp)
        {
            con.Open();
            string qry = "INSERT INTO dbo.Employee(Name, Surname, Address, Qualification, ContactNumber, DepartmentID) VALUES(@Name, @Surname, @Address, @Qualification, @Cnumber, @DepartmentID)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Surname", emp.Surname);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.Parameters.AddWithValue("@Qualification", emp.Qualification);
            cmd.Parameters.AddWithValue("@Cnumber", emp.ContactNumber);
            cmd.Parameters.AddWithValue("@DepartmentID", emp.DepartmentID);
            cmd.ExecuteNonQuery();
            con.Close();
            return emp;
        }

        public static Employee EditInList(int id,Employee emp)
        {
            employeeList.Clear();
            con.Open();
            string qry = "UPDATE dbo.Employee SET Name=" + emp.Name + ",Surname=" + emp.Surname + ",Address=" + emp.Address + "" +
                ",Qualification=" + emp.Qualification + ",ContactNumber=" + emp.ContactNumber + ",DepartmentID=" + emp.DepartmentID + 
                " WHERE EmployeeID=" + id;

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return emp;
        }

        public static void DeleteInList(int id)
        {
            employeeList.Clear();
            con.Open();
            string qry = "DELETE FROM dbo.Employee WHERE EmployeeID=" + id;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }






    }
    /*public class EmployeeList
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
    }*/
}
