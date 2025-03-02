using System.Web.Mvc;
using Business_Layer;
using Contract;
using Model;

namespace TaskFlow.Controllers
{
    public class LoginController : Controller
    {
        public IDatabase dbObject;
        public LoginController()
        {
            dbObject = new Database();
        }

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
                int userId = dbObject.GetUserId(user);
                if (userId > 0)
                {
                    user.UserId = userId;
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