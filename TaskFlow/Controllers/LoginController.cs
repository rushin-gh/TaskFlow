using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskFlow.Models;
using TaskFlow.Business_Layer;

namespace TaskFlow.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                int userId = Database.GetUserId(user);
                if (userId > 0)
                {
                    TempData["User"] = user;
                    return RedirectToAction("Index", "Task");
                }
            }
            ModelState.Clear();
            return View("Index");
        }
    }
}

/* Login System is Very Basic Needs improvement */