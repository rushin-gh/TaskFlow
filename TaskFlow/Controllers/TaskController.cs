using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            var user = TempData["User"] as User;
            //if (user == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            if (user == null) user = new User();
            user.TaskList = new List<Task>()
            {
                new Task()
                {
                    TaskDesc = "Go To Sleep"
                },
                new Task()
                {
                    TaskDesc = "Read a Book"
                },
                new Task()
                {
                    TaskDesc = "Recharge Mobile"
                }
            };
            return View(user);
        }
    }
}