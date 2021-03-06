//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoMobileCMS.DAL.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblProduct
    {
        public TblProduct()
        {
            this.TblProductImages = new HashSet<TblProductImage>();
        }
    
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
        public virtual ICollection<TblProductImage> TblProductImages { get; set; }
        public virtual TblUser TblUser { get; set; }
    }
}
