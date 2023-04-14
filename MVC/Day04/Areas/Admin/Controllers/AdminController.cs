using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day04.Areas.Admin.Controllers
{
    [HandleError(View ="AdminError")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Test()
        {
            string x = "AASDASD";
            int y = Convert.ToInt32(x);
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}