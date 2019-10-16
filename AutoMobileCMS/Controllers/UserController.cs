using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.Helpers;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMobileCMS.Controllers
{
    public class UserController : Controller
    {
        IUserService _userservice;
        IRoleService _roleservice;
        ITemplateService _templateservice;
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        public UserController(IUserService userserve, IRoleService roleservice, ITemplateService templateservice)
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            _userservice = userserve;
            _roleservice = roleservice;
            _templateservice = templateservice;
        }
        // GET: User
        [HttpGet]
        //[CustomAuthorize(Common.Admin)]
        public ActionResult Index()
        {
            
            var users = _dbContext.TblUsers.Where(s => s.Status == true);
            var usersviewmodel = users.Select(s => new UserViewModel
            {
                UserID = s.UserID,
                UserName = s.UserName,
                Email = s.Email,
                ContactNo = s.ContactNo,
            }).ToList();
            return View(usersviewmodel);
        }
        public ActionResult Create()
        {
            var roles = _roleservice.Get(r => r.IsActive == true);
            var templates = _templateservice.Get(r => r.isactive == true);
            UserViewModel um = new UserViewModel();
            um.Status = true;
            um.TblRole = roles.Select(s => new SelectListItem { Text = s.RoleName, Value = s.RoleId.ToString() }).ToList();
            um.templates = templates.Select(s => new SelectListItem { Text = s.template_name, Value = s.template_id.ToString() }).ToList();
            return View(um);
        }
        [HttpPost]
        [CustomAuthorize(Common.Admin)]
        public ActionResult Create(UserViewModel userVM)
        {
            if (!ModelState.IsValid==true)
            {
                 var roles = _roleservice.Get(r => r.IsActive == true);
                UserViewModel um = new UserViewModel();
                um.TblRole= roles.Select(s => new SelectListItem { Text = s.RoleName, Value = s.RoleId.ToString() }).ToList();
                um.Status = true;
                return View(um);
            }
            if (Session["UserDetails"] != null)
            {
                var admindata = Session["UserDetails"] as UserViewModel;
            }
            else
            {
                RedirectToAction("Login");
            }

            userVM.Status = true;
            userVM.CreatedBy = "Mohammed";
            userVM.CreatedOn = DateTime.Now;
            userVM.UserInRoles = new List<UserInRoleViewModel>();
            userVM.UserInRoles.Add(new UserInRoleViewModel() { RoleId = userVM.RoleId });
            var userData = Mapper.UserMapper.Attach(userVM);
            _userservice.Add(userData);
            _userservice.SaveChanges();
            TempData["Message"] = "Record Saved Succesfully";
            TempData.Keep();
            return RedirectToAction("Create");
        }
        public ActionResult Login()
        {
            return View();
        }
        public bool checkIsLogedIn(TblUser user)
        {
            bool flag = false;
           // flag = user.IsLoggedIn.Value;
            return flag;
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "UserName,Password")]UserViewModel user)
        {
            if (ModelState.IsValidField("UserName") && ModelState.IsValidField("Password"))
            {
                var userData = _userservice.GetPassword(user.UserName);
                UserViewModel uservm = new UserViewModel();


                //HttpCookie objCookie = new HttpCookie("UserId");
                //objCookie.Value = userData.UserId.ToString();
                //objCookie.Expires = DateTime.Now.AddDays(1);

                //Response.Cookies.Add(objCookie);

                if (user.RememberMe)
                {
                    Response.Cookies["userName"].Value = userData.UserName;
                    Response.Cookies["Password"].Value = userData.UserName;

                    string User_Name = string.Empty;
                    string pass = string.Empty;
                    string id = string.Empty;
                    User_Name = Request.Cookies["userName"].Value;
                    pass = Request.Cookies["Password"].Value;
                    id = Request.Cookies["UserId"].Value;
                }
                HttpCookie objRequestRead = Request.Cookies["UserId"];
                if (objRequestRead != null)
                {
                    string User_Name = objRequestRead.Value;
                }

                if (userData != null)
                {
                    if (checkIsLogedIn(userData))
                    {
                        ModelState.AddModelError("Error", "This user is already logged in from another device");
                        return View();
                    }
                    else
                    {
                        //UpdateIsLoggeIn(userData); //commented for testing purpose
                    }
                    uservm = Mapper.UserMapper.Detach(userData);

                    Session["UserDetails"] = uservm;
                   // var password = userData.Password.Decrypt();
                    var password = userData.Password;
                    if (user.Password.Equals(password))
                    {
                     //   Session["CompID"] = userData.CompanyID;
                        //if (userData.IsReset != true)
                        //{
                        //    return RedirectToAction("ResetPassword", "User");
                        //}
                        //else
                        //{
                        if (uservm.UserInRoles.FirstOrDefault().RoleId == Convert.ToInt32(Common.Roles.Admin))
                        {
                            return RedirectToAction("Index", "User");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Product");
                        }
                       
                       // }
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "The password provided is incorrect.");
                        Session["UserDetails"] = null;
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "The username or password provided is incorrect.");
                    Session["UserDetails"] = null;
                    return View();
                }
            }
            else
            {
                Session["UserDetails"] = null;
                return View();
            }
        }
       [HttpGet]
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}