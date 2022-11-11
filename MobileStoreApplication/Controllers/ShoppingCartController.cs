using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStoreApplication.Models;
using MobileStoreApplication.Controllers;
using MobileStoreApplication.Models.Home;
using Microsoft.Ajax.Utilities;
using System.Web.Razor.Text;
using System.Security.Cryptography.X509Certificates;
using System.Data.Entity;
using System.Data;

namespace MobileStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DBModels db = new DBModels();
        //public int OrderNumber;
        public int isExisting(int SNo)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].DisplayImage1.SNo == SNo)
                    return i;

            }
            return -1;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int SNo)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Tbl_DisplayImage.Find(SNo), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(SNo);
                if (index == -1)
                { cart.Add(new Item(db.Tbl_DisplayImage.Find(SNo), 1)); }
                else { cart[index].Quantity++; }
                Session["cart"] = cart;
            }
            return View("AddToCart");
        }


        public ActionResult Delete(int SNo, int Quantity)
        {
            int index = isExisting(SNo);
            List<Item> cart = (List<Item>)Session["cart"];
            if (Quantity == 1)
                cart.RemoveAt(index);
            else
            {
                cart[index].Quantity--;
            }
            Session["cart"] = cart;
            return View("AddToCart");
        }


        public ActionResult Payment(int orderNumber)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            
                ViewBag.OrderNumber = orderNumber;
            return View();
        }

       
        public ActionResult SessionEmpty()
        {
            
            Session.Remove("cart");
            
          return RedirectToAction("Index", "Home");

            

            
        }

        public ActionResult OrderCancel()
        {
            return View();
        }
        public ActionResult OrderTableUpdation()
        {
            Random r = new Random();
            Item.orderNumber = r.Next();
            ViewBag.OrderNumber = Item.orderNumber;
            Tbl_Order tbl_Order = new Tbl_Order();
            foreach (Item i in (List<Item>)Session["cart"])
            {
                tbl_Order.EmailId = Session["EmailId"].ToString();
                tbl_Order.OrderNumber = "MW_" + Item.orderNumber;
                tbl_Order.BrandName = i.DisplayImage1.BrandName;
                tbl_Order.ProductName = i.DisplayImage1.ProductName;
                tbl_Order.RAMName = i.DisplayImage1.RAMName;
                tbl_Order.ROMName = i.DisplayImage1.ROMName;
                tbl_Order.Quantity = i.Quantity;
                tbl_Order.Price = i.DisplayImage1.Price;
                db.Tbl_Order.Add(tbl_Order);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult HomeOrderCancel()
        {


           
            //var ono = ("TI" + ordernumber);
            //var query = "delete from [Tbl_Orders] where OrderNumber = {0}";
            //db.Database.ExecuteSqlCommand(query, ono);
            return View();
            //return RedirectToAction("OrderCancel",orderNumber);

        }
        [HttpPost]

        public ActionResult Result(string orderNumber)
        {
            using (DBModels db = new DBModels())
            {
             
           
            ViewBag.orderNumber = orderNumber;
            var ono = orderNumber;
 var userDetails = db.Tbl_Order.Where(x => x.OrderNumber == orderNumber).FirstOrDefault();

                if(userDetails == null)
                {

                    ViewBag.ErrorMessage = "This Order Number Does Not Exist";
                    return View("HomeOrderCancel");
                    

                }
            
                else
                {
                    var query = "delete from [Tbl_Order] where OrderNumber = {0}";
                    db.Database.ExecuteSqlCommand(query, ono);
                    return View();

                }
                //}
            }

            //return View();
        }
    }
}