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
            return View();
        }
    }
}