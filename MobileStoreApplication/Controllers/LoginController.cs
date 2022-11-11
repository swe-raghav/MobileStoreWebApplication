using MobileStoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStoreApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MobileStoreApplication.Models.Tbl_LoginAndRegister loginAndRegister)
        {
            using (DBModels db = new DBModels())
            {
                var userDetails = db.Tbl_LoginAndRegister.Where(x => x.EmailId == loginAndRegister.EmailId && x.Password == loginAndRegister.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    ViewBag.LoginAndErrorMessage = "Wrong Email or Password";
                    //return View("Index", loginAndRegister);
                    return View("Index");
                }

                else
                {
                    Session["EmailId"] = loginAndRegister.EmailId;
                    return RedirectToAction("OrderTableUpdation", "ShoppingCart");
                }
            }

        }
    }
}