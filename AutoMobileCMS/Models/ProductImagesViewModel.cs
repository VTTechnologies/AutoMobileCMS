using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Models
{
    public class ProductImagesViewModel
    {
        public int ProductImagesID { get; set; }
        public int ProductID { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }
        public string ImagePath5 { get; set; }
        public string ImagePath6 { get; set; }
        public string ImagePath7 { get; set; }
        public string ImagePath8 { get; set; }
        public string ImagePath9 { get; set; }
        public string ProductOverview { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<System.DateTime> DateofPurchase { get; set; }
        public string KMDriven { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
        public virtual ICollection<TblBrand> TblBrand { get; set; }


        public virtual ProductViewModel products { get; set; }
    }
}