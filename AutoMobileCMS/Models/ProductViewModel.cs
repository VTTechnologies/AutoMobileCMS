using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;



namespace AutoMobileCMS.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductOverview { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<System.DateTime> DateofPurchase { get; set; }
        public string KMDriven { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsSold { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual TblBrand TblBrand { get; set; }
        public virtual TblProductImage TblProductImages { get; set; }
        public virtual TblUser TblUser { get; set; }

        public virtual UserViewModel Users { get; set; }

        public string BrandName { get; set; }

        public string UserName { get; set; }

        public string ImagePath1 { get; set; }

        public virtual ProductImagesViewModel productimages { get; set; }

        
    }
}