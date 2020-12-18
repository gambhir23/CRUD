using Library.Models.Login_Func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
   
    public class LoginController : Controller
    {
        Login_Func fun = new Login_Func();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult Login_Verification1(string Username ,string Password)
        {
           
        //    LoginProp prop = new LoginProp();
            var result = fun.login(Username, Password);
            return Json(result, JsonRequestBehavior.AllowGet);
           
        }
    }
}