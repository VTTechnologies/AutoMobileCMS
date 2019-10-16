using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMobileCMS.Helpers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        IUserService _userService;
        UserViewModel userDetail;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            _userService = DependencyResolver.Current.GetService<IUserService>();
            this.allowedroles = roles;
            userDetail = new UserViewModel();
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            userDetail = httpContext.Session["UserDetails"] as UserViewModel;
            foreach (var role in allowedroles)
            {
                if (userDetail != null)
                {
                    if (_userService.Get(w => w.UserName == userDetail.UserName && w.Password == userDetail.Password && w.UserInRoles.Where(r => r.TblRole.RoleName == role).Any() && w.Status == true, null, string.Empty).Any())
                    {
                        authorize = true;
                    }
                }

            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var urlHelper = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "NotAuthorized",
                        LogOnUrl = urlHelper.Action("Login", "User")
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                //userDetail
                if (filterContext.HttpContext.Session["UserDetails"] == null)
                {
                    var UserId = "";
                    HttpCookie objRequestRead = HttpContext.Current.Request.Cookies["UserId"];
                    if (objRequestRead != null)
                    {
                        UserId = objRequestRead.Value;
                    }
                    var um = _userService.Get().Where(u => u.UserID == Convert.ToInt32(UserId)).FirstOrDefault();
                   // UpdateIsLoggeIn(um);
                    filterContext.Result = new RedirectResult("~/User/Login");
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedAccess");
                }
            }
        }
        //public void UpdateIsLoggeIn(TblUser user)
        //{
        //    user.IsLoggedIn = false;
        //    _userService.Update(user);
        //    _userService.SaveChanges();
        //}
    }
}