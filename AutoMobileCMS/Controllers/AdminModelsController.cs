using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMobileCMS.Controllers
{
    public class AdminModelsController : Controller
    {
        IUserService _userservice;
        IBrandService _brandservice;
        IProductService _modelsservice;
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand cmd;
        public AdminModelsController(IBrandService brandserve, IProductService modelsservice,IUserService userservice)
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            _brandservice = brandserve;
            _modelsservice = modelsservice;
            _userservice = userservice;
        }

        // GET: AdminModels
        public ActionResult Index()
        {
            var users = _userservice.Get(c => c.Status == true);
            TempData["users"] = users.Select(s => new SelectListItem { Text = s.UserName, Value = s.UserName }).ToList();

            var models = _modelsservice.Get(s => s.Status == true);
            var modelsviewmodel = models.Select(s => new ProductViewModel
                {
                    ProductID = s.ProductID,
                    ProductName = s.ProductName,
                    BrandName = s.TblBrand == null ? "" : s.TblBrand.BrandName,
                    Price = s.Price,
                    DateofPurchase = s.DateofPurchase,
                    KMDriven = s.KMDriven,
                    UserName = s.TblUser == null ? "" : s.TblUser.UserName
                });
            return View(modelsviewmodel);
        }
    }
}