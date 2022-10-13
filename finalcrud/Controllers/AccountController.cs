using finalcrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace finalcrud.Controllers
{
    public class AccountController : Controller
    {
        EmployeeDB DB = new EmployeeDB();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ViewModel.Membership membership)
        {
            bool isValid = DB.Users.Any(m => m.Username == membership.Username && m.Password == membership.Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(membership.Username, false);
                return RedirectToAction("Crud", "Employee");
            }
            return View();
        }

        public ActionResult Singup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Singup(User user)
        {
            DB.Users.Add(user);
            DB.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}