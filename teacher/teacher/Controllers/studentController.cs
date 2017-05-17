using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class studentController : Controller
    {
        Models.TeachDBEntities9 tdb = new Models.TeachDBEntities9();
        //
        // GET: /student/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getstudent(int page, int rows)
        {

            int nums = tdb.Students.Count();
            var student = (from s in tdb.Students
                           join c in tdb.Classes on s.ClassID equals c.ID
                           orderby s.ID
                           select new
                           {
                               ID = s.ID,
                               classname = c.Name,
                               Name = s.Name,
                               studentID = s.StudentNo,
                               TelNo = s.TelNum,
                               QQNo = s.QQ,
                               wechatNo = s.WeChat,
                               PTelNo1 = s.PTelNo1,
                               IsLogin = s.IsLogin
                           }).Skip((page - 1) * rows).Take(rows);
            var obj = new { total = nums, rows = student };

            return Json(obj, JsonRequestBehavior.AllowGet);


        }
      
        public ActionResult addstudent(Models.Students student )
        {
            try {
                student.Password = "123";
                tdb.Students.Add(student);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch {
                return Content("err");
            }
        }
        public ActionResult add()
        {
            return View();
        }
        public ActionResult delete(int id)
        {
            try {
                var dep = tdb.Students.First(t=>t.ID==id);
                tdb.Students.Remove(dep);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch {
                return Content("err");
            }
        }
        public ActionResult editstudent(int ID, int ClassID, string Name, string StudentID, string TelNo, string QQNo, string WechatNo, string PTelNo1, int IsLogin, int Status)
        {
            try
            {
                var dep = tdb.Students.First(t => t.ID == ID);
                dep.ClassID = ClassID;
                dep.Name = Name;
                dep.StudentNo = StudentID;
                dep.Password = "1234";
                dep.TelNum = TelNo;
                dep.QQ = QQNo;
                dep.WeChat = WechatNo;
                dep.PTelNo1 = PTelNo1;
                dep.IsLogin = IsLogin;
                dep.Stauts = Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }

        
        
        }
        public ActionResult edit(int id)
        {
            Models.Students dep = tdb.Students.First(t => t.ID == id);
            return View(dep);
        }
        public ActionResult chongzhi(int id)
        {
            try
            {
                var teacher = tdb.Teachers.Single(t => t.ID == id);
                teacher.Password = "1234";
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }


        }
    }
}
