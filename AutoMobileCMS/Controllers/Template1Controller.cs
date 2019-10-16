using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMobileCMS.Controllers
{
    public class Template1Controller : Controller
    {
        IBrandService _brandservice;
        IProductService _productservice;
        IProductImagesService _productimagesservice;
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand cmd;
        public Template1Controller(IBrandService brandserve, IProductService productservice, IProductImagesService productimagesservice)
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            _brandservice = brandserve;
            _productservice = productservice;
            _productimagesservice = productimagesservice;
        }

        // GET: Template1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public DataTable getallproducts()
        {
            var user = Session["UserDetails"] as UserViewModel;
            con.Open();
            cmd = new SqlCommand("sp_Getallproducts", con);
            cmd.Parameters.AddWithValue("@userid", user.UserID);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public ActionResult Shop()
        {
            var user = Session["UserDetails"] as UserViewModel;
            DataTable dt = new DataTable();
            dt = getallproducts();
            List<ProductViewModel> prodList = new List<ProductViewModel>();
            prodList = (from DataRow dr in dt.Rows
                        select new ProductViewModel
                        {
                            ProductID = Convert.ToInt32(dr["ProductID"]),
                            ProductName = dr["ProductName"].ToString(),
                            ProductOverview = dr["ProductOverview"].ToString(),
                            Price = Convert.ToDecimal(dr["Price"].ToString()),
                            DateofPurchase = Convert.ToDateTime(dr["DateofPurchase"].ToString()),
                            KMDriven = dr["KMDriven"].ToString(),
                            BrandName = dr["BrandName"].ToString(),
                            ImagePath1 = dr["ImagePath1"].ToString()
                        }).ToList();
            

            return View("Shop", prodList);
        }

        public ActionResult SoldList()
        {
            var user = Session["UserDetails"] as UserViewModel;
            var solds = _dbContext.TblSolds.Where(s => s.Status == true && s.UserID == user.UserID);
            var soldviewmodel = solds.Select(s => new SoldViewModel
            {
                CustomerName = s.CustomerName,
                ImagePath = s.ImagePath
            }).ToList();

            return View("SoldList", soldviewmodel);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
       

        [HttpGet]
        public ActionResult Details(int id)
        {

            var pbyid = _productimagesservice.Get(s => s.ProductID == id, o => o.OrderByDescending(ob => ob.ProductID), "TblProduct").FirstOrDefault();
            ProductImagesViewModel productimgviewmodel = new ProductImagesViewModel();
            
            productimgviewmodel.ImagePath1 = pbyid.ImagePath1;
            productimgviewmodel.ImagePath2 = pbyid.ImagePath2;
            productimgviewmodel.ImagePath3 = pbyid.ImagePath3;
            productimgviewmodel.ImagePath4 = pbyid.ImagePath4;
            productimgviewmodel.ImagePath5 = pbyid.ImagePath5;
            productimgviewmodel.ImagePath6 = pbyid.ImagePath6;
            productimgviewmodel.ImagePath7 = pbyid.ImagePath7;
            productimgviewmodel.ImagePath8 = pbyid.ImagePath8;
            productimgviewmodel.ImagePath9 = pbyid.ImagePath9;

            productimgviewmodel.ProductID = pbyid.ProductID;
            productimgviewmodel.ProductName = pbyid.TblProduct.ProductName;
            productimgviewmodel.ProductOverview = pbyid.TblProduct.ProductOverview;
            productimgviewmodel.Price = pbyid.TblProduct.Price;
            productimgviewmodel.DateofPurchase = pbyid.TblProduct.DateofPurchase;
            productimgviewmodel.KMDriven = pbyid.TblProduct.KMDriven;
            productimgviewmodel.BrandName = pbyid.TblProduct.TblBrand.BrandName;
            //productimgviewmodel.ImagePath9 = pbyid.ImagePath9;
            //productimgviewmodel.ImagePath9 = pbyid.ImagePath9;
            //productimgviewmodel.ImagePath9 = pbyid.ImagePath9;
            //productimgviewmodel.ImagePath9 = pbyid.ImagePath9;

           // productimgviewmodel.products = pbyid.TblProduct

           // var pvm = Mapper.ProductImagesMapper.Detach(pbyid);
            return View(productimgviewmodel);
        }

    }
}