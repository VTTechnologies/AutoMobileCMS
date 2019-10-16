using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Models
{
    public class TemplateViewModel
    {
        public int template_id { get; set; }
        public string template_name { get; set; }
        public Nullable<bool> isactive { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}