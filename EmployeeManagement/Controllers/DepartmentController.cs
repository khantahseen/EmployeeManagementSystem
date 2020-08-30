using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepository d = new DepartmentRepository();
        // GET: DepartmentController
        public ActionResult Index()
        {
            IEnumerable<Department> obj = d.SelectDepartment();
            return View(obj);
          
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            Department obj = d.GetDepartmentById(id);
            return View(obj); 
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dep)
        {
            try
            {
                d.AddDepartment(dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            Department obj = d.GetDepartmentById(id);
            return View(obj);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department dep)
        {
            try
            {
                d.EditDepartment(id, (Department)dep);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            Department obj = d.GetDepartmentById(id);
            return View(obj);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                d.DeleteDepartment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
