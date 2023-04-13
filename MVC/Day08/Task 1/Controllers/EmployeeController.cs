using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day08;
using Day08.Models;
using Microsoft.Extensions.Configuration;

namespace Day08.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EMPLOYEESContext _context = new();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _context.Employee.Include(e => e.d);
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employee
                .Include(e => e.d)
                .FirstOrDefault(m => m.EmpID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewData["dID"] = new SelectList(_context.Department, "DeptID", "DeptName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("EmpID,EmpFname,EmpLname,EmpSalary,EmpHDate,dID,CtyID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["dID"] = new SelectList(_context.Department, "DeptID", "DeptName", employee.dID);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["dID"] = new SelectList(_context.Department, "DeptID", "DeptName", employee.dID);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("EmpID,EmpFname,EmpLname,EmpSalary,EmpHDate,dID,CtyID")] Employee employee)
        {
            if (id != employee.EmpID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmpID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["dID"] = new SelectList(_context.Department, "DeptID", "DeptName", employee.dID);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employee
                .Include(e => e.d)
                .FirstOrDefault(m => m.EmpID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee =  _context.Employee.Find(id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpID == id);
        }
    }
}
