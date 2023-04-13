using Day06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Day06.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Client client)
        {
            if(ModelState.IsValid)
            {
                IdentityDBContext DBC = new IdentityDBContext();
                DBC.Clients.Add(client);
                DBC.SaveChanges();
                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("Email", client.Email),
                    new Claim("Password", client.Password),
                    new Claim("Name",client.ClientName)
                },"AppCookie");
                Request.GetOwinContext().Authentication.SignIn(userIdentity);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Client client)
        {

                IdentityDBContext DBC = new IdentityDBContext();
                var curruser = DBC.Clients.FirstOrDefault(C => C.Email == client.Email && C.Password == client.Password);
                if(curruser!=null)
                {
                    var SignInIdentity = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim("Email", client.Email),
                        new Claim("Password", client.Password),
                    }, "AppCookie");
                    Request.GetOwinContext().Authentication.SignIn(SignInIdentity);
                    return RedirectToAction("Index", "Home");
                }
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }
    }
}