using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStoreApplication.Models;

namespace MobileStoreApplication.Controllers
{
    public class Tbl_DisplayImageController : Controller
    {
        // GET: Tbl_DisplayImage
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Tbl_DisplayImage tbl_DisplayImage)
        {
            string fileName = Path.GetFileNameWithoutExtension(tbl_DisplayImage.ImageFile.FileName);
            string extension = Path.GetExtension(tbl_DisplayImage.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            tbl_DisplayImage.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            tbl_DisplayImage.ImageFile.SaveAs(fileName);
            using (DBModels db = new DBModels())
            {
                db.Tbl_DisplayImage.Add(tbl_DisplayImage);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Tbl_DisplayImage tbl_DisplayImage = new Tbl_DisplayImage();
            using (DBModels db = new DBModels())
            {
                tbl_DisplayImage = db.Tbl_DisplayImage.Where(x => x.SNo == id).FirstOrDefault();
            }
            return View(tbl_DisplayImage);
        }

    }
}