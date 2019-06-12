using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;



namespace AutoMobileCMS.Models
{
    public class ModelsViewModel
    {
        public int ModelID { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }
        public string ModelOverview { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ModelName { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<System.DateTime> DateofPurchase { get; set; }
        public string KMDriven { get; set; }
        public Nullable<int> CompanyID { get; set; }

        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual BrandViewModel TblBrand { get; set; }
    }
}