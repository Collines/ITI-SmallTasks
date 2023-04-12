using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day09;
using Day09_remake.Models;
using Day09.Interfaces;
using Day09.Models;

namespace Day09_remake.Controllers
{
    public class TraineeCourseController : Controller
    {
        public IRepository<TraineeCourse> TCR { get; }
        public IRepository<Course> C { get; }
        public IRepository<Trainee> T { get; }

        public TraineeCourseController(IRepository<TraineeCourse> TCR, IRepository<Course> C, IRepository<Trainee> T)
        {
            this.TCR = TCR;
            this.C = C;
            this.T = T;
        }

        // GET: TraineeCourse
        public ActionResult Index()
        {
           
            return View(TCR.GetAll());
        }

        // GET: TraineeCourse/Details/5
        public ActionResult Details(TCID id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traineeCourse = TCR.GetDetails(id);
            if (traineeCourse == null)
            {
                return NotFound();
            }

            return View(traineeCourse);
        }

        // GET: TraineeCourse/Create
        public ActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(C.GetAll(), "ID", "Topic");
            ViewData["TraineeID"] = new SelectList(T.GetAll(), "ID", "Name");
            return View();
        }

        // POST: TraineeCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CourseID,TraineeID,Grade")] TraineeCourse traineeCourse)
        {
            if (ModelState.IsValid)
            {
                TCR.Insert(traineeCourse);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(C.GetAll(), "ID", "Topic");
            ViewData["TraineeID"] = new SelectList(T.GetAll(), "ID", "Name");
            return View(traineeCourse);
        }

        // GET: TraineeCourse/Edit/5
        public ActionResult Edit(TCID id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TraineeCourse traineeCourse = TCR.GetDetails(id);
            if (traineeCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(C.GetAll(), "ID", "Topic");
            ViewData["TraineeID"] = new SelectList(T.GetAll(), "ID", "Name");
            return View(traineeCourse);
        }

        // POST: TraineeCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TCID id, [Bind("CourseID,TraineeID,Grade")] TraineeCourse traineeCourse)
        {
            if (id.TraineeID != traineeCourse.TraineeID || id.CourseID != traineeCourse.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TCR.Update(id,traineeCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeCourseExists(new TCID {TraineeID= traineeCourse.TraineeID, CourseID= traineeCourse.CourseID }))
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
            ViewData["CourseID"] = new SelectList(C.GetAll(), "ID", "Topic");
            ViewData["TraineeID"] = new SelectList(T.GetAll(), "ID", "Email");
            return View(traineeCourse);
        }

        // GET: TraineeCourse/Delete/5
        public ActionResult Delete(TCID id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TraineeCourse traineeCourse = TCR.GetDetails(id);
            if (traineeCourse == null)
            {
                return NotFound();
            }

            return View(traineeCourse);
        }

        // POST: TraineeCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TCID id)
        {
            TCR.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeCourseExists(TCID id)
        {
            return TCR.isExist(id);
        }
    }
}
