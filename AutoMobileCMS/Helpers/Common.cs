using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Helpers
{
    public class Common
    {

        public enum Roles
        {
            Admin = 1,
            SiteOwner = 2,
            
        }
        public const string Admin = "Admin";
        public const string Siteowner = "Siteowner";
    }

}