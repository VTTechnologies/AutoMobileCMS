using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Models
{
    public class UserInRoleViewModel
    {
        public int UserRoleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int RoleId { get; set; }


        public virtual RoleViewModel TblRole { get; set; }
        public virtual UserViewModel TblUsers { get; set; }
    }
}