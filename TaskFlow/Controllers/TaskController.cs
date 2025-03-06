using System.Web.Mvc;
using System.Collections.Generic;
using Model;
using Contract;
using Business_Layer;
using Newtonsoft.Json;

namespace TaskFlow.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            var orgUser = Session["User"] as User;
            var copyUser = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(orgUser)); 
            Database.GetUserTasks(copyUser);
            return View(copyUser);
        }

        public ActionResult AddTask(string task)
        {

            return RedirectToAction("Index");
        }
    }
}