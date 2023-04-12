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
    public class TrackController : Controller
    {
        public IRepository<Track> TrackR { get; }
        public IRepository<Trainee> TraineeR { get; }

        public TrackController(IRepository<Track> TrackR, IRepository<Trainee> TraineeR)
        {
            this.TrackR = TrackR;
            this.TraineeR = TraineeR;
        }

        // GET: Track
        public ActionResult Index()
        {
            return View(TrackR.GetAll());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track track = TrackR.GetDetails(id ?? -1);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Track/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Track/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Name,Description")] Track track)
        {
            if (ModelState.IsValid)
            {
                TrackR.Insert(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track track = TrackR.GetDetails(id ?? -1);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: Track/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ID,Name,Description")] Track track)
        {
            if (id != track.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TrackR.Update(id,track);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.ID))
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
            return View(track);
        }

        // GET: Track/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Track track = TrackR.GetDetails(id ?? -1);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackR.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
            return TrackR.isExist(id);
        }
    }
}
