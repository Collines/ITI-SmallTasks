using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Day02.Models
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult All()
        {
            ViewBag.Cars = CarList.Cars;
            return View();
        }

        //public ActionResult Car(int id)
        //{
        //    return View();
        //}

        public ActionResult Create() // create view
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Color, string Model, string Manfacture) // create
        {
            Car newCar = new Car() {Num= CarList.Cars.Count + 1, Color=Color,Model=Model,Manfacture=Manfacture };
            CarList.Cars.Add(newCar);
            return RedirectToAction("All");
        }

        public ActionResult Edit(int id)  // edit view
        {
            var Car = CarList.Cars.ElementAtOrDefault(id - 1);
            if (Car != null)
                ViewBag.Car = Car;
            return View();
        }

        [HttpPost] //update
        public ActionResult Edit(int num,string color, string model, string manfacture) 
        {
            Car CurrCar = CarList.Cars.ElementAtOrDefault(num-1);
            CurrCar.Color = color;
            CurrCar.Model = model;
            CurrCar.Manfacture = manfacture;
            return RedirectToAction("All");
        }
        public ActionResult Delete(int id)
        {
            Car deletedCar = CarList.Cars.ElementAtOrDefault(id - 1);
            if (deletedCar != null)
                CarList.Cars.Remove(deletedCar);
            return RedirectToAction("All");
        }
    }
}