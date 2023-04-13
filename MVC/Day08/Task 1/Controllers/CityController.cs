using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day08;
using Day08.Models;

namespace Day08.Controllers
{
    public class CityController : Controller
    {
        private readonly EMPLOYEESContext _context=new();


        // GET: City
        public  ActionResult Index()
        {
            var eMPLOYEESContext = _context.City.Include(c => c.c).Include(c => c.cNavigation);
            return View( eMPLOYEESContext.ToList());
        }

        // GET: City/Details/5
        public  ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  _context.City
                .Include(c => c.c)
                .Include(c => c.cNavigation)
                .FirstOrDefault(m => m.cityID == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            ViewData["cID"] = new SelectList(_context.Employee, "EmpID", "EmpFname");
            ViewData["cID"] = new SelectList(_context.Country, "countryID", "CountryName");
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind("cityID,CityName,cID")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cID"] = new SelectList(_context.Employee, "EmpID", "EmpFname", city.cID);
            ViewData["cID"] = new SelectList(_context.Country, "countryID", "CountryName", city.cID);
            return View(city);
        }

        // GET: City/Edit/5
        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  _context.City.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["cID"] = new SelectList(_context.Employee, "EmpID", "EmpFname", city.cID);
            ViewData["cID"] = new SelectList(_context.Country, "countryID", "CountryName", city.cID);
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit(int id, [Bind("cityID,CityName,cID")] City city)
        {
            if (id != city.cityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.cityID))
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
            ViewData["cID"] = new SelectList(_context.Employee, "EmpID", "EmpFname", city.cID);
            ViewData["cID"] = new SelectList(_context.Country, "countryID", "CountryName", city.cID);
            return View(city);
        }

        // GET: City/Delete/5
        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city =  _context.City
                .Include(c => c.c)
                .Include(c => c.cNavigation)
                .FirstOrDefault(m => m.cityID == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult DeleteConfirmed(int id)
        {
            var city =  _context.City.Find(id);
            _context.City.Remove(city);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.cityID == id);
        }
    }
}
