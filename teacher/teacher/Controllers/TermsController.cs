using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace teacher.Controllers
//{
//    public class TermsController : Controller
//    {
//        //
//        // GET: /Terms/
//        Models.TeachDBEntities6 tdb = new Models.TeachDBEntities6();
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult getterms()
//        {
//            var desps = from dep in tdb select new {ID=dep.ID,  Name = dep.Name, Status = dep.Status };
//            return Json(desps, JsonRequestBehavior.AllowGet);
//        }
//        public ActionResult addterms(Models.Terms terms)
//        {
//            try
//            {
//                tdb.Terms.Add(terms);
//                tdb.SaveChanges();
//                return Content("ok");
//            }
//            catch {
//                return Content("err");
            
//            }

//        }
//        public ActionResult add()
//        {
//            return View();
//        }
//        public ActionResult editterms(int ID, string Name, int Status)
//        {
//            var dep = tdb.Terms.First(t=>t.ID==ID);
//            dep.Name = Name;
//            dep.Status = Status;
//            tdb.SaveChanges();
//            return Content("ok");
//        }
//        public ActionResult edit(int id)
//        {
//            Models.Terms dep = tdb.Terms.First(t=>t.ID==id);
//            return View(dep);
//        }
//        public ActionResult delete(int id)
//        {
//            var dep = tdb.Terms.First(t => t.ID == id);
//            tdb.Terms.Remove(dep);
//            tdb.SaveChanges();
//            return Content("ok");
//        }

//    }
//}
