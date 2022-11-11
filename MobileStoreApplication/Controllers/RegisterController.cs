using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStoreApplication.Models;

namespace MobileStoreApplication.Controllers
{
    public class RegisterController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Tbl_LoginAndRegister loginAndRegister = new Tbl_LoginAndRegister();
            //return View(loginAndRegister);
            return View();
        }
        [HttpPost]
        public ActionResult AddOrEdit(Tbl_LoginAndRegister loginAndRegister)
        {
            using (DBModels db = new DBModels())
            {
                if (db.Tbl_LoginAndRegister.Any(x => x.EmailId == loginAndRegister.EmailId))
                {
                    ViewBag.DuplicateMessage = "Email ID already exists";
                    return View("AddOrEdit", loginAndRegister);
                }
                db.Tbl_LoginAndRegister.Add(loginAndRegister);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            
            //return View("PaymentRedirect", new Tbl_LoginAndRegister());
            return View("PaymentRedirect");
        }

        public ActionResult PaymentRedirect()
        {
            return View();
        }
    }
}