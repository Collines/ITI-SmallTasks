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
    public class TraineeController : Controller
    {
        public IRepository<Trainee> TraineeR { get; }
        public IRepository<Course> CR { get; }
        public IRepository<Track> TrackR { get; }

        public TraineeController(IRepository<Trainee> TraineeR, IRepository<Course> CR, IRepository<Track> TrackR)
        {
            this.TraineeR = TraineeR;
            this.CR = CR;
            this.TrackR = TrackR;
        }

        // GET: Trainee
        public ActionResult Index()
        {
            return View(TraineeR.GetAll());
        }

        // GET: Trainee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainee trainee = TraineeR.GetDetails(id ?? -1);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainee/Create
        public ActionResult Create()
        {
            ViewData["Tracks"] = new SelectList(TrackR.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Name,Gender,Email,Phone,Birthdate")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                TraineeR.Insert(trainee);
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainee trainee = TraineeR.GetDetails(id??-1);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ID,Name,Gender,Email,Phone,Birthdate")] Trainee trainee)
        {
            if (id != trainee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TraineeR.Update(id, trainee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.ID))
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
            return View(trainee);
        }

        // GET: Trainee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trainee trainee = TraineeR.GetDetails(id ?? -1);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeR.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return TraineeR.isExist(id);
        }
    }
}
