using MobileStoreApplication.Models;
using MobileStoreApplication.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStoreApplication.Controllers
{
    public class HomeController : Controller
    {
        //DBModels ctx = new DBModels();

        

        public DBModels ctx = new DBModels();
        public ActionResult Index(string search)
        {
            SearchViewModel model = new SearchViewModel();

           
            
                return View(model.CreateModel(search));
            
            
            //return View(from item in db.Images.Take(10) select item);

        }

        

        public ActionResult About ()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

        
    }
}