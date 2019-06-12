using AutoMobileCMS.DAL.IService;
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

        public ModelsController(IBrandService brandserve)
        {
            _brandservice = brandserve;
        }

        // GET: Models
        public ActionResult Index()
        {
            return View("_ModelsList");
        }
        public ActionResult Create()
        {
            //var cities = _brandservice.Get(c => c.Status == true);
            //TempData["brands"] = cities.Select(s => new SelectListItem { Text = s.BrandName, Value = s.BrandID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ModelsViewModel modelsviewmodel)
        {
            return PartialView("UploadImage");
        }
    }
}