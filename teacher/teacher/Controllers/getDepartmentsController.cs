using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class getDepartmentsController : Controller
    {
        Models.TeachDBEntities9 tdb = new Models.TeachDBEntities9();
        //
        // GET: /getDepartments/

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult getchange( int id)
        {
            Models.Departments dep = tdb.Departments.First(t=>t.ID==id);
            return View(dep);
        }
      
        public ActionResult getteach()
        {
           
            var desps = from dep in tdb.Departments select new { Id = dep.ID, Name = dep.Name,Status=dep.Status };
            return Json(desps, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delete(int id)
        {
            try {
                var dep = tdb.Departments.First(t=>t.ID==id);
             tdb.Departments.Remove(dep);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch {
                return Content("err"); 
            }
        }
        public ActionResult getdepartmentid( int id)
        {
            try
            {
                var desps = from dep in tdb.Departments
                            where dep.ID == id
                            select new { Id = dep.ID, Name = dep.Name, Status = dep.Status };
                return Json(desps, JsonRequestBehavior.AllowGet);
            }
            catch {
                return Content("[]");
            }
        }
        public ActionResult change(int id,string name, int Status)
        {
            try
            {
                var dep = tdb.Departments.First(t => t.ID == id);
                dep.Name = name;
                dep.Status = Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch {
                return Content("err");
            }
        }
        public ActionResult add( string name, int Status)
        {
            try
            {
                var dep = new Models.Departments();

                dep.Name = name;
                dep.Status = Status;
                tdb.Departments.Add(dep);
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
