using System;
using System.Collections.Generic;  
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace teacher.Controllers
{
    public class bookController : Controller
    {
        //
        // GET: /book/
        Models.TeachDBEntities9 tdb = App_Start.Helper.tdb;
        public ActionResult Index()
        {
            return View();      
        }
        public ActionResult getbook()
        {                                                                                                                                       
            //var book = from b in tdb
            //           select new { 
            //               ID= b.ID,
            //               Name=b.Name,
            //               bookName=b.bookName,
            //               Author=b.Author,
            //               publisher=b.Publisher,
            //               ISBN=b.ISBN,
            //               price=b.Price,
            //               LastTime=b.LastTime,
            //               DisabledTime=b.DisabledTime,
            //               bookpName=b.bookpName                         
            //           };
            return View() ;
        }
    }
}
