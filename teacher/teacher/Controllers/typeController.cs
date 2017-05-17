using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class typeController : Controller
    {
        //
        // GET: /type/
        Models.TeachDBEntities9 tdb = new Models.TeachDBEntities9();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult gettype()
        {
            try
            {

                var da = (from d in tdb.type
                        
                          select new { id = d.ID, name = d.Name, typid=d.typeid,Status=d.Status});
                return Json(da, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult AddType(Models.type t)
        {
            try
            {
                tdb.type.Add(t);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }


        public ActionResult add()
        {
            return View();
        }
        public ActionResult EditType(int id, string name, int typeid, int Status)
        {
            try
            {
                var type = tdb.type.First(t => t.ID == id);
                type.Name = name;
                type.typeid = typeid;
                Status = type.Status;
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult edit(int id)
        {
            Models.type dep = tdb.type.First(t=>t.ID==id);
            return View(dep);
        }
        public ActionResult DeleteType(int id)
        {
            try
            {
                var type = tdb.type.First(t => t.ID == id);
                tdb.type.Remove(type);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }



    }
}
