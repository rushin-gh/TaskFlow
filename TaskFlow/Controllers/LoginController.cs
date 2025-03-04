using System.Web.Mvc;
using Business_Layer;
using Contract;
using Model;

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
            // Move code of getting user to Business Layer
            if (ModelState.IsValid)
            {
                int userId = Database.GetUserId(user);
                if (userId > 0)
                {
                    user.UserId = userId;
                    Session["User"] = user;
                    return RedirectToAction("Index", "Task");
                }
            }
            ModelState.Clear();
            return View("Index");
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
    }
}

/* Login System is Very Basic Needs improvement */