using AutoMobileCMS.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMobileCMS.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Enter UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        public Nullable<decimal> ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public Nullable<bool> Status { get; set; }
        [Required(ErrorMessage = "Please select user role")]
        public int RoleId { get; set; }
        public Nullable<int> template_id { get; set; }
        public string template_name { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public bool RememberMe { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
        public virtual ICollection<UserInRoleViewModel> UserInRoles { get; set; }
        public List<SelectListItem> TblRole { set; get; }

        public List<SelectListItem> templates { set; get; }

        public virtual TemplateViewModel tblTemplate { get; set; }

        
    }
}