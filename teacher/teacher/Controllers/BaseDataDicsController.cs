using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class BaseDataDicsController : Controller
    {
        //
        // GET: /BaseDataDics/
        Models.TeachDBEntities9 tdb = new Models.TeachDBEntities9();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Indexs()
        {
            return View();
        }
        public ActionResult GetDatabase()
        {
            try
            {

                var da = (from d in tdb.BaseDataDics
                          select new { id = d.ID, name = d.Name,typeNO=d.TypeNo,Status=d.Status });
                return Json(da, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Content("error");
            }
        }
        public ActionResult AddDatabase(Models.BaseDataDics b)
        {
            try
            {
                tdb.BaseDataDics.Add(b);
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
        public ActionResult EditDatabase(int ID, string Name, int TypeNo,int Status)
        {
            try
            {
                var b = tdb.BaseDataDics.First(t => t.ID == ID);
                   b.ID=ID;
                   b.Name = Name;
                   b.TypeNo = TypeNo;
                   b.Status = Status;
                
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
            Models.BaseDataDics de = tdb.BaseDataDics.First(t=>t.ID==id);
            return View(de);
        }
        public ActionResult DeleteDatabase(int id)
        {
            try
            {
                var no = tdb.BaseDataDics.First(t => t.ID == id);
                tdb.BaseDataDics.Remove(no);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch
            {
                return Content("error");
            }
        }
        
        public ActionResult GettypeID(int typeno )
        {
            var classes = from c in tdb.BaseDataDics
                        
                          
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                              Index = c.IndexNo,
                              typeno = c.TypeNo,
                              Status = c.Status
                          };
            if (typeno != -1)
            {
                classes = classes.Where(t => t.typeno == typeno);
            }

                return Json(classes, JsonRequestBehavior.AllowGet);
            }
          
        

    }
}
