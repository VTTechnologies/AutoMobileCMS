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
    public class ModelsController : Controller
    {
        IBrandService _brandservice;
        IModelsService _modelsservice;

        public ModelsController(IBrandService brandserve,IModelsService modelsservice)
        {
            _brandservice = brandserve;
            _modelsservice = modelsservice;
        }

        // GET: Models
        public ActionResult Index()
        {
            return View("_ModelsList");
        }
        public ActionResult Create()
        {
            var cities = _brandservice.Get(c => c.Status == true);
            TempData["brands"] = cities.Select(s => new SelectListItem { Text = s.BrandName, Value = s.BrandID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ModelsViewModel modelsviewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HttpPostedFileBase imagepath1 = Request.Files["imgupload1"];
            HttpPostedFileBase imagepath2 = Request.Files["imgupload2"];
            HttpPostedFileBase imagepath3 = Request.Files["imgupload3"];
            HttpPostedFileBase imagepath4 = Request.Files["imgupload4"];

             string img1 = PhotoManager.savePhoto(imagepath1);
             string img2 = PhotoManager.savePhoto(imagepath2);
             string img3 = PhotoManager.savePhoto(imagepath3);
             string img4 = PhotoManager.savePhoto(imagepath4);
             modelsviewmodel.ImagePath1 = img1;
             modelsviewmodel.ImagePath2 = img2;
             modelsviewmodel.ImagePath3 = img3;
             modelsviewmodel.ImagePath4 = img4;
             modelsviewmodel.CreatedBy = "mohammed";
             modelsviewmodel.CreatedOn = DateTime.Now;
             modelsviewmodel.CompanyID = 1;
             modelsviewmodel.Status = true;


             var insertmodels = Mapper.ModelsMapper.Attach(modelsviewmodel);
             _modelsservice.Add(insertmodels);
             _modelsservice.SaveChanges();
             ViewBag.Message = "sussess message";

             return View();
        }
    }
}