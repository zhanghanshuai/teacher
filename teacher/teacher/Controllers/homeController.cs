using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Security;
namespace teacher.Controllers
{
    public class homeController : Controller
    {
        //
        // GET: /home/
        Models.TeachDBEntities9 tdb = new Models.TeachDBEntities9();
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Login(string username, string password, string role)
        {

            if (role == "t") //教师
            {
                try
                {
                    var teacher = tdb.Teachers.Single(t => t.TeacherNo == username && t.Password == password);
                    //admin/123
                    if (teacher != null)
                    {
                        //FormsAuthentication.SetAuthCookie(teacher.Departments + ";;" + teacher.DeptID, false);

                        FormsAuthenticationTicket t = new FormsAuthenticationTicket(1, teacher.Name, DateTime.Now, DateTime.Now.AddMinutes(30), false, teacher.DeptID + ";" + teacher.ID);
                        var ticket = FormsAuthentication.Encrypt(t);
                        HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
                        HttpContext.Response.Cookies.Add(c);
                        return Content("ok");
                    }

                    else
                        return Content("err");
                }
                catch
                {
                    return Content("err");
                }
            }
            else if (role == "s") //学生
            {
                //TODO:学生登录未完成
                return Content("err");
            }
            else
                return Content("err"); 
        }
       
        public ActionResult main()
        {

            //string t = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName].Value; //取到的是加密数据  -- ticket
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(t);
            //ViewBag.teacherName = ticket.Name;
            return View();
        }
        public ActionResult getusers()
        {

            //string str = "[{'no':1,'name':'大主宰'},{'no':2,'name':'斗破苍穹'}]";
            //str = str.Replace("'", "\"");
            //return Content(str);
            List<book> bs = new List<book>();
            bs.Add(new book {no=1,name="大主宰" });
            bs.Add(new book { no = 2, name = "斗破苍穹" });
            return Json(bs, JsonRequestBehavior.AllowGet);
        }

    }
    class book
    {
        public int no { get;set;}
        public string name { get; set; }
    }

}
