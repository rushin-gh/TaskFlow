using System.Web.Mvc;
using System.Collections.Generic;
using Model;
using Contract;
using Business_Layer;

namespace TaskFlow.Controllers
{
    public class TaskController : Controller
    {
        public IDatabase dbObject;

        public TaskController()
        {
            dbObject = new Database();
        }


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
            dbObject.GetUserTasks(user);
        }
    }
}