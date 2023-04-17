using Day03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day03.Controllers
{
    public class EmployeeController : Controller
    {
        EMPLOYEESEntities DB = new EMPLOYEESEntities();
        // GET: Employee
        [HttpPost]
        public ActionResult Index(int deptID)
        {
            ViewBag.Employees = DB.Employees.Where(E => E.dID == deptID).ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Departments = DB.Departments.ToList();
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee E = DB.Employees.FirstOrDefault(e => e.EmpID == id);
            return View(E);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            SelectList Departments = new SelectList(DB.Departments.ToList(), "DeptID", "DeptName");
            ViewBag.Departments = Departments;
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection FC)
        {
            try
            {
                Employee E = new Employee()
                {
                    EmpFname = FC["EmpFname"],
                    EmpLname = FC["EmpLname"],
                    EmpSalary = double.Parse(FC["EmpSalary"]),
                    EmpHDate = Convert.ToDateTime(FC["EmpHDate"]),
                    dID = int.Parse(FC["dID"]),
                    CtyID = int.Parse(FC["CtyID"])
                };
                DB.Employees.Add(E);
                DB.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee E = DB.Employees.FirstOrDefault(e => e.EmpID == id);
            SelectList Departments = new SelectList(DB.Departments.ToList(), "DeptID", "DeptName");
            ViewBag.Departments = Departments;
            return View(E);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection FC)
        {
            Employee E = DB.Employees.FirstOrDefault(e => e.EmpID == id);
            try
            {
                E.EmpFname = FC["EmpFname"];
                E.EmpLname = FC["EmpLname"];
                E.EmpSalary = double.Parse(FC["EmpSalary"]);
                E.EmpHDate = Convert.ToDateTime(FC["EmpHDate"]);
                E.dID = int.Parse(FC["dID"]);
                E.CtyID = int.Parse(FC["CtyID"]);
                DB.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Employee E = DB.Employees.FirstOrDefault(e => e.EmpID == id);
            DB.Employees.Remove(E);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
