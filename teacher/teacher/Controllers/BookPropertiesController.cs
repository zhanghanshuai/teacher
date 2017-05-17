using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class BookPropertiesController : Controller
    {
        //
        //// GET: /BookProperties/
        //Models.TeachDBEntities6 tdb = new Models.TeachDBEntities6();
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public ActionResult getBookProperties()
        //{
        //    var dep = from b in tdb.BookProperties
        //              select new
        //              {
        //                  ID = b.ID,
        //                  name = b.Name,
        //                  Status = b.Status
        //              };
        //    return Json(dep,JsonRequestBehavior.AllowGet);
            
        //}
        //public ActionResult addBookProperties(Models.BookProperties bp)
        //{
        //    tdb.BookProperties.Add(bp);
        //    tdb.SaveChanges();
        //    return Content("ok"); ;
        //}
        //public ActionResult add()
        //{
        //    return View();
        //}
        //public ActionResult editBookProperties(int ID, string Name, int Status)
        //{
        //    var dep = tdb.BookProperties.First(t=>t.ID==ID);
        //    dep.Name = Name;
        //    dep.Status = Status;
        //    tdb.SaveChanges();
        //    return Content("ok");

        //}
        //public ActionResult edit(int id)
        //{
        //    Models.BookProperties dep = tdb.BookProperties.First(t=>t.ID==id);
        //    return View(dep);
            
        //}
        //public ActionResult delete(int id)
        //{
        //    var dep = tdb.BookProperties.First(t=>t.ID==id );
        //    tdb.BookProperties.Remove(dep);
        //    tdb.SaveChanges();
        //    return Content("ok");
        //}

    }
}
