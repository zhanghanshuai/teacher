//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace teacher.Controllers
//{
////    public class BookTypesController : Controller
//    {
//        //
//        // GET: /BookTypes/
//        Models.TeachDBEntities6 tdb = new Models.TeachDBEntities6();
////        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult getbooktype()
//        {
//            var dep = from bt in tdb.BookTypes select new { 
//           ID=bt.ID ,
//           Name=bt.Name ,
//           Status=bt.Status 

//            };
//            return Json(dep,JsonRequestBehavior.AllowGet );
//        }

//        public ActionResult addbooktype(Models.BookTypes bts)
//        {
//            tdb.BookTypes.Add(bts);
//            tdb.SaveChanges();
//            return Content("ok"); ;
//        }
//        public ActionResult add()
//        {
//            return View();
//        }
//        public ActionResult editbooktype(int ID, string Name, int Status)
//        {
//            var dep = tdb.BookTypes.First(t=>t.ID==ID);
//            dep.Name = Name;
//            dep.Status = Status;
//            tdb.SaveChanges();
//            return Content("ok");
            
//        }
//        public ActionResult edit(int id)
//        {
//            Models.BookTypes dep = tdb.BookTypes.First(t=>t.ID==id);
//            return View(dep);
//        }
//        public ActionResult delete(int id)
//        {
//            var dep = tdb.BookTypes.First(t=>t.ID==id );
//            tdb.BookTypes.Remove(dep);
//            tdb.SaveChanges();
//            return Content("ok");
//        }
        
//    }
//}
