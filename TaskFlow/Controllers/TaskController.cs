using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskFlow.Business_Layer;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            var user = new User()
            {
                UserId = 1,
                TaskList = new List<Task>()
            };
            //if (user == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            GetUserTasksFromDB(user);

            //user.TaskList = new List<Task>()
            //{
            //    new Task()
            //    {
            //        TaskDesc = "Go To Sleep"
            //    },
            //    new Task()
            //    {
            //        TaskDesc = "Read a Book"
            //    },
            //    new Task()
            //    {
            //        TaskDesc = "Recharge Mobile"
            //    }
            //};
            return View(user);
        }

        private void GetUserTasksFromDB(User user)
        {
            Database.GetUserTasks(user);
        }
    }
}