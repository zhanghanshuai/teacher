using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace teacher.Controllers
{
    public class teacherController : Controller
    {
        //
        // GET: /teacher/
        Models.TeachDBEntities9 tdb = new Models.TeachDBEntities9();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getteacher(int page, int rows)
        {
            int nums = tdb.Teachers.Count();
            var teacher = (from t in tdb.Teachers
                           join d in tdb.Departments on t.DeptID equals d.ID
                           orderby t.ID
                           select new
                           {
                               ID = t.ID,
                               departmentName = d.Name,
                               Name = t.Name,
                               teacherID = t.TeacherNo,
                               IsLogin = t.IsLogin
                           }).Skip((page - 1) * rows).Take(rows);


            var jon = new { total = nums, rows = teacher };
            return Json(jon, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addteacher(Models.Teachers teacher)
        {
            try
            {
                teacher.Password = "123";
                tdb.Teachers.Add(teacher);
                tdb.SaveChanges();
                return Content("ok");

            }
            catch
            {
                return Content("err");
            }


        }
        public ActionResult add()
        {
            return View();
        }
        public ActionResult delete(int id)
        {
            try 
            {
                var dep = tdb.Teachers.First(t => t.ID == id);
                tdb.Teachers.Remove(dep);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }
        }
      
        public ActionResult edit( int id)
        {
            Models.Teachers dep = tdb.Teachers.First(t=>t.ID ==id); 
            return View(dep);
        }
        public ActionResult editteacher(int ID, int DeptID, string Name, string TeacherID,  int IsLogin, int Status)
        {
            try
            {
                var dep = tdb.Teachers.First(t => t.ID == ID);
                dep.DeptID = DeptID;
                dep.Name = Name;
                dep.TeacherNo = TeacherID;
                dep.Password = "123";
                dep.IsLogin = IsLogin;
                dep.Status = Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("err");
            }

        }

        public ActionResult chongzhi(int id) {
            try
            {
                var teacher = tdb.Teachers.Single(t => t.ID == id);
                teacher.Password = "1234";
                tdb.SaveChanges();
                return Content("ok");
            }
            catch {
                return Content("err");
            }

        
        }
        public ActionResult GetTeachersList()
        {
            FormsAuthenticationTicket ti = teacher.App_Start.Helper.GetTicket(HttpContext);
            int deptid = App_Start.Helper.GetDepartmentID(HttpContext);
            var teachers = from t in tdb.Teachers
                           where t.DeptID == deptid
                           select new
                           {
                               ID = t.ID,
                               Name = t.Name
                           };
            ;

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getteachers()
        {

            var teacher = from t in tdb.Teachers
                          join d in tdb.Departments on t.DeptID equals d.ID
                          orderby t.ID
                          select new
                          {
                              ID = t.ID,
                              departmentName = d.Name,
                              Name = t.Name,
                              teacherID = t.TeacherNo,
                              IsLogin = t.IsLogin
                          };


          
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }
      
    }
}
