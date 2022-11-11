//using MobileStoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileStoreApplication.Models.Home
{
    public class SearchViewModel
    {
        //public static DBModels context = new DBModels();
       // public static GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public static DBModels context = new DBModels();
        public List<Tbl_DisplayImage> ListOfProducts { get; set; }
        public List<Tbl_Order> ListOfProducts1 { get; set; }

        //public List<Tbl_DisplayImage> DropdownListOfProducts { get; set; }
        public SearchViewModel CreateModel(string search)
        {
            // public static DBModels context = new DBModels();
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            List<Tbl_DisplayImage> data = context.Database.SqlQuery<Tbl_DisplayImage>("GetBySearch @search", param).ToList();
            return new SearchViewModel
            {
                ListOfProducts = data
            };
        }


     
       
   }
}