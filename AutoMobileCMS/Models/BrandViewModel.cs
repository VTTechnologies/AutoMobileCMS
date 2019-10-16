using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMobileCMS.DAL.DBModel;


namespace AutoMobileCMS.Modelss
{
    public class BrandViewModel
    {
       
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}