﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Models
{
    public class RoleViewModel
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> IsActive { get; set; }

        
        public virtual ICollection<UserViewModel> TblUsers { get; set; }
        public virtual ICollection<UserInRoleViewModel> UserInRoles { get; set; }
    }
}