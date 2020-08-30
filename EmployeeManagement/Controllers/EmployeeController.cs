using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository e = new EmployeeRepository();
        DepartmentRepository dep = new DepartmentRepository();
        // GET: EmployeeController
        public ActionResult Index()
        {
            IEnumerable<Employee> obj = e.SelectAllEmployees();
            return View(obj);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            Employee obj = e.GetEmployeeById(id);
            return View(obj);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            //ViewBag.DepName = dep.SelectDepartment();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                e.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DepName = dep.SelectDepartment();
            Employee obj = e.GetEmployeeById(id);
            return View(obj);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                e.EditEmployee(id,(Employee)emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee obj = e.GetEmployeeById(id);
            return View(obj);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                e.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
