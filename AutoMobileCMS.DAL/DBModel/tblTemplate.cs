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
    
    public partial class tblTemplate
    {
        public tblTemplate()
        {
            this.TblUsers = new HashSet<TblUser>();
        }
    
        public int template_id { get; set; }
        public string template_name { get; set; }
        public Nullable<bool> isactive { get; set; }
    
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
