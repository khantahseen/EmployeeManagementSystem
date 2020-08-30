using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class DepartmentList
    {
        static SqlConnection con;
        public static List<Department> departmentList = null;
        static DepartmentList()
        {
            string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            departmentList = new List<Department>()
            {
                 new Department(){DepartmentID= 0, DepartmentName= "IT"}
            };
            con = new SqlConnection(connectionstring);
        }

        public static List<Department> GetDepartmentList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.Department", con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Department dep = new Department();
                dep.DepartmentID = Convert.ToInt32(reader[0]);
                dep.DepartmentName = reader[1].ToString();
                departmentList.Add(dep);
            }
            con.Close();
            return departmentList;
        }

        public static Department AddToDepartmentList(Department dep)
        {
            con.Open();
            string qry = "INSERT INTO dbo.Department(DepartmentName) VALUES(@DeptName)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@DeptName", dep.DepartmentName);
            cmd.ExecuteNonQuery();
            con.Close();
            return dep;
        }

        public static Department EditInDepartmentList(int id,Department dep)
        {
            departmentList.Clear();
            con.Open();
            string qry = "UPDATE dbo.Department SET DepartmentName=" + dep.DepartmentName + "WHERE DpartmetID= " + id;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return dep;
        }

        public static void DeleteInDepartmentList(int id)
        {
            departmentList.Clear();
            con.Open();
            string qry = "DELETE FROM dbo.Department WHERE DepartmentID=" + id;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }


    /*public class DepartmentList
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
    }*/
}
