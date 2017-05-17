using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class classController : Controller
    {
        //
        // GET: /class/
        Models.TeachDBEntities9 tdb = App_Start.Helper.tdb;
         public ActionResult Index()
        {
            return View();
        }
        public ActionResult getclass(int magorId )
        {
            var classes = from c in tdb.View_TeacherClasses
                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                                 magorId=c.MajorID,
                              TeacherName=c.TeacherName,
                              TeacherID=c.TeacherID
                             
                          };
            if (magorId != -1)
            {
                classes = classes.Where(t => t.magorId == magorId);
            }
            
            return Json(classes, JsonRequestBehavior.AllowGet);
                          
                          
        }
        public ActionResult getclasses()
        {


            var classes = from c in tdb.Classes
                          join m in tdb.Majors on c.MajorID equals m.ID

                          select new
                          {
                              ID = c.ID,
                              Name = c.Name,
                              magorId = c.MajorID,
                              majorsName =m.Name,
                            Status = c.Status

                          };
           

            return Json(classes, JsonRequestBehavior.AllowGet);


        }

        public ActionResult addclass(Models.View_TeacherClasses classteacher)
        {

           
         
            try
            {
                tdb.AddClasses(classteacher.MajorID, classteacher.Name, classteacher.TeacherID);
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
                var dep = tdb.Classes.First(t => t.ID == id);
                tdb.Classes.Remove(dep);
                tdb.SaveChanges();
                return Content("ok");
            }
            catch { return Content("err"); }
        
        }
        public ActionResult editclass(Models.View_TeacherClasses tc)
        {
            try
            {
                var c = tdb.Classes.Single(t => t.ID == tc.ID);
                var ttcc = tdb.TeacherClasses.Where(t => t.ClassID == tc.ID);
                if (ttcc.Count() == 0)
                {
                    tdb.TeacherClasses.Add(new Models.TeacherClasses() { TeacherID = tc.TeacherID, ClassID = tc.ID, Status = 0 });
                }
                else
                {
                    var teaclass = ttcc.ToList()[0];
                    teaclass.TeacherID = tc.TeacherID;
                    teaclass.Status = 0;
                    teaclass.ClassID = tc.ID;
                }
                c.Name = tc.Name;

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
            var dep = tdb.View_TeacherClasses.First(t=>t.ID==id);
            return View(dep);
        }
    }
}
