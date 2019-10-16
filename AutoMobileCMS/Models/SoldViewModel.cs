using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Models
{
    public class SoldViewModel
    {
        public int SoldID { get; set; }
        public string ImagePath { get; set; }
        public string CustomerName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> ModalID { get; set; }
    }
}