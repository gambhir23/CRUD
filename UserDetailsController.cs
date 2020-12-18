using Library.Models.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class UserDetailsController : Controller
    {
        UserDetails_Func fun = new UserDetails_Func();
        UserDetails_Prop prop = new UserDetails_Prop();
        // GET: UserDetails
        public ActionResult UserDetails()
        {
            return View();
        }
      
        // GET: Book
        //public ActionResult Book()
        //{
        //    return View();
        //}


        // GET: Color

       
        public JsonResult Insert(UserDetails_Prop prop)
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
        public JsonResult LoadDeleted(UserDetails_Prop prop)
        {

            var result = fun.Delete_Color(prop);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadUpdate(UserDetails_Prop prop)
        {

            var result = fun.Updated_Color(prop);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadRetrieve(UserDetails_Prop prop)
        {
            var result = fun.Retrieve_Color(prop);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}