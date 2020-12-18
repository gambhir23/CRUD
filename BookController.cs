using Library.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        Book_Func fun = new Book_Func();
        Book_Prop prop = new Book_Prop();
        // GET: Book
        //public ActionResult Book()
        //{
        //    return View();
        //}
     
      
        // GET: Color
    
        public ActionResult Book()
        {
            //Library.Models.AllStrings.Url = Request.Url.AbsolutePath;
            return View();
        }
        public JsonResult Insert(Book_Prop prop)
        {
         
            var result = fun.Insert_Color(prop);



            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult LoadColor(string Search, string pageindex, string pagesize)
        {
            var result = fun.GetFin(Search, Convert.ToInt32(pageindex), Convert.ToInt32(pagesize));
            var result1 = new { Results = result.Item1, Total = result.Item2 };
            return Json(result1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadDeleted(Book_Prop prop)
        {

            var result = fun.Delete_Color(prop);
           
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadUpdate(Book_Prop prop)
        {
          
            var result = fun.Updated_Color(prop);
           
            return Json(result, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult LoadRetrieve(Book_Prop prop)
        {
            var result = fun.Retrieve_Color(prop);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}