using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class usersController : Controller
    {
        //
        // GET: /users/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login(string username, string possword)
        {
            if (username == "admin" && possword == "123")
            {
                return Content("ok");
            }
            else
            {
                return Content("err");
            }
        }

    }
}
