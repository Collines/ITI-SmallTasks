using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day09;
using Day09.Models;
using Day09.Models.Repos;
using Day09.Interfaces;

namespace Day09_remake.Controllers
{
    public class CourseController : Controller
    {
        public IRepository<Course> CR { get; }
        public IRepository<Trainee> TR { get; }

        public CourseController(IRepository<Course> CR, IRepository<Trainee> TR)
        {
            this.CR = CR;
            this.TR = TR;
        }

        // GET: Course
        public ActionResult Index()
        {
            return View(CR.GetAll());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            Course course;
            if (id == null)
            {
                return NotFound();
            } else
            {
                course = CR.GetDetails(id??-1);
            }
                
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Topic,Grade")] Course course)
        {
            if (ModelState.IsValid)
            {
                CR.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = CR.GetDetails(id ?? -1);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ID,Topic,Grade")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CR.Update(id, course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
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
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = CR.GetDetails(id ?? -1);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CR.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return CR.isExist(id);
        }
    }
}
