using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileStoreApplication.Models;

namespace MobileStoreApplication.Models.Home
{
    public class Item
    {
        public Tbl_DisplayImage DisplayImage = new Tbl_DisplayImage();
        public int quantity;

        public static int orderNumber;

        public Item()
        { }

        public Item(Tbl_DisplayImage DisplayImage,int quantity)
        {
            this.DisplayImage1 = DisplayImage;
            this.Quantity = quantity;
        }

        public Tbl_DisplayImage DisplayImage1 { 
            get => DisplayImage; set => DisplayImage = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public  int OrderNumber { get => orderNumber; set => orderNumber = value; }
    }
}