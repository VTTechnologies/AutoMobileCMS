using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.Helpers;
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
    public class ProductController : Controller
    {
        IBrandService _brandservice;
        IProductService _productservice;
        IProductImagesService _productimageservice;
        private readonly AUTOMOBILECMSEntities2 _dbContext;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlCommand cmd;
        public ProductController(IBrandService brandserve, IProductService productservice, IProductImagesService productimageservice)
        {
            _dbContext = new AUTOMOBILECMSEntities2();
            _brandservice = brandserve;
            _productservice = productservice;
            _productimageservice = productimageservice;
        }

        // GET: Models
        public ActionResult Index()
        {
            var user = Session["UserDetails"] as UserViewModel;
            var modeles = _dbContext.TblProducts.Where(s => s.IsSold == false && s.UserID == user.UserID);
           
            var modelsviewmodel = modeles.Select(s => new ProductViewModel
            {
                ProductID = s.ProductID,
                ProductName = s.ProductName,
                Price = s.Price,
                BrandName = s.TblBrand == null ? "" : s.TblBrand.BrandName,
                DateofPurchase = s.DateofPurchase,
                KMDriven = s.KMDriven,
            }).ToList();
            ViewBag.templatename = user.tblTemplate == null ? "" : user.tblTemplate.template_name;

            return View("_ProductList", modelsviewmodel);
        }

        
        public void fillbrands()
        {
            var brands = _brandservice.Get(c => c.Status == true);
            TempData["brands"] = brands.Select(s => new SelectListItem { Text = s.BrandName, Value = s.BrandID.ToString() }).ToList();
        }
      
        public ActionResult Create()
        {
            fillbrands();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel modelsviewmodel)
        {
            var user = Session["UserDetails"] as UserViewModel;
            if (!ModelState.IsValid)
            {
                fillbrands();
                return View();
            }
                modelsviewmodel.UserID = user.UserID;
                modelsviewmodel.CreatedBy = user.UserName;
                modelsviewmodel.CreatedOn = DateTime.Now;
                modelsviewmodel.Status = true;
                modelsviewmodel.IsSold = false;
                var insertmodels = Mapper.ProductsMapper.Attach(modelsviewmodel);
                _productservice.Add(insertmodels);
                _productservice.SaveChanges();
                Session["ProductID"] = insertmodels.ProductID;
                return RedirectToAction("ImagesUploads");
        }
        [HttpGet]
        public ActionResult ImagesUploads()
        {
            return View();
        }
        [HttpPost]
        public ActionResult updatedimages(ProductImagesViewModel productimagesviewmodel)
        {
         
            HttpPostedFileBase imagepath1 = Request.Files["imgupload1"];
            HttpPostedFileBase imagepath2 = Request.Files["imgupload2"];
            HttpPostedFileBase imagepath3 = Request.Files["imgupload3"];
            HttpPostedFileBase imagepath4 = Request.Files["imgupload4"]; 
            HttpPostedFileBase imagepath5 = Request.Files["imgupload5"];
            HttpPostedFileBase imagepath6 = Request.Files["imgupload6"];
            HttpPostedFileBase imagepath7 = Request.Files["imgupload7"];
            HttpPostedFileBase imagepath8 = Request.Files["imgupload8"];
            HttpPostedFileBase imagepath9 = Request.Files["imgupload9"];


            productimagesviewmodel.ImagePath1 = PhotoManager.resizephoto(imagepath1, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath2 = PhotoManager.resizephoto(imagepath2, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath3 = PhotoManager.resizephoto(imagepath3, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath4 = PhotoManager.resizephoto(imagepath4, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath5 = PhotoManager.resizephoto(imagepath5, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath6 = PhotoManager.resizephoto(imagepath6, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath7 = PhotoManager.resizephoto(imagepath7, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath8 = PhotoManager.resizephoto(imagepath8, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ImagePath9 = PhotoManager.resizephoto(imagepath9, Convert.ToInt32(Session["ProductID"]), "new");
            productimagesviewmodel.ProductID = Convert.ToInt32(Session["ProductID"]);

            var productimageinset = Mapper.ProductImagesMapper.Attach(productimagesviewmodel);
            _productimageservice.Add(productimageinset);
            _productimageservice.SaveChanges();
            TempData["Message"] = "Record Saved Succesfully";
            TempData.Keep();
            return RedirectToAction("ImagesUploads");

        }

        public ActionResult Sold()
        {
            var user = Session["UserDetails"] as UserViewModel;
            ViewBag.templatename = user.tblTemplate == null ? "" : user.tblTemplate.template_name;
            return View();
        }
        [HttpPost]
        public ActionResult Sold(SoldViewModel soldviewmodel)
        {
            var user = Session["UserDetails"] as UserViewModel;
            var id = Request.Url.Segments[3];
            HttpPostedFileBase imagepath1 = Request.Files["imgupload1"];
            string img1 = PhotoManager.resizephoto(imagepath1, Convert.ToInt32(id),"sold");
            cmd = new SqlCommand("sp_InsertSoldModels", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productid", id);
            cmd.Parameters.AddWithValue("@customername", soldviewmodel.CustomerName);
            cmd.Parameters.AddWithValue("@description", soldviewmodel.Description);
            cmd.Parameters.AddWithValue("@imgpath", img1);
            cmd.Parameters.AddWithValue("@createby", user.UserName);
            cmd.Parameters.AddWithValue("@userid", user.UserID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            TempData["Message"] = "Sold Succesfully";
            TempData.Keep();
            return RedirectToAction("Sold");
        }

        public ActionResult Edit(int id)
        {
            fillbrands();
            ProductViewModel modelsviewmodel = new ProductViewModel();
            var modelsbyid = _productservice.GetProductById(id);
            var modelsvm = Mapper.ProductsMapper.Detach(modelsbyid);

            return View("EditModels",modelsvm);

        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel modelsviewmodel)
        {
            var user = Session["UserDetails"] as UserViewModel;
            if (!ModelState.IsValid)
            {
                return View();
            }
            modelsviewmodel.UpdatedBy = user.UserName;
            modelsviewmodel.UpdatedOn = DateTime.Now;
            modelsviewmodel.UserID = user.UserID;
            modelsviewmodel.Status = true;
            modelsviewmodel.IsSold = false;

            var updatemodels = Mapper.ProductsMapper.Attach(modelsviewmodel);
            _productservice.Update(updatemodels);
            _productservice.SaveChanges();

            Session["PrdID"] = updatemodels.ProductID;

            //var prodimgID = _dbContext.TblProductImages.Where(s => s.ProductID == updatemodels.ProductID);
            //Session["prodimgID"] = prodimgID.
            TempData["Message"] = "Updated Succesfully";
            TempData.Keep();
            return RedirectToAction("Edit");
        }

        



        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0 || !string.IsNullOrWhiteSpace(id.ToString()))
            {
                _productservice.Delete(id);
                _productservice.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ImagesEdit()
        {
            int id = Convert.ToInt32(Session["PrdID"]);
            var pbyid = _productimageservice.Get(s => s.ProductID == id, o => o.OrderByDescending(ob => ob.ProductID), "TblProduct").FirstOrDefault();
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
            return View(productimgviewmodel);
        }

        [HttpPost]
        public ActionResult ImagesEdit(ProductImagesViewModel prodimgviewmodel)
        {
            HttpPostedFileBase imagepath1 = Request.Files["imgupload1"];
            HttpPostedFileBase imagepath2 = Request.Files["imgupload2"];
            HttpPostedFileBase imagepath3 = Request.Files["imgupload3"];
            HttpPostedFileBase imagepath4 = Request.Files["imgupload4"];
            HttpPostedFileBase imagepath5 = Request.Files["imgupload5"];
            HttpPostedFileBase imagepath6 = Request.Files["imgupload6"];
            HttpPostedFileBase imagepath7 = Request.Files["imgupload7"];
            HttpPostedFileBase imagepath8 = Request.Files["imgupload8"];
            HttpPostedFileBase imagepath9 = Request.Files["imgupload9"];


            prodimgviewmodel.ImagePath1 = PhotoManager.resizephoto(imagepath1, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath2 = PhotoManager.resizephoto(imagepath2, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath3 = PhotoManager.resizephoto(imagepath3, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath4 = PhotoManager.resizephoto(imagepath4, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath5 = PhotoManager.resizephoto(imagepath5, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath6 = PhotoManager.resizephoto(imagepath6, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath7 = PhotoManager.resizephoto(imagepath7, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath8 = PhotoManager.resizephoto(imagepath8, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ImagePath9 = PhotoManager.resizephoto(imagepath9, Convert.ToInt32(Session["PrdID"]), "new");
            prodimgviewmodel.ProductID = Convert.ToInt32(Session["PrdID"]);
            var updateprodimg = Mapper.ProductImagesMapper.Attach(prodimgviewmodel);
            _productimageservice.Update(updateprodimg);
            _productimageservice.SaveChanges();
            TempData["Message"] = "Record Saved Succesfully";
            TempData.Keep();
            return RedirectToAction("ImagesEdit");
        }

    

    }
}