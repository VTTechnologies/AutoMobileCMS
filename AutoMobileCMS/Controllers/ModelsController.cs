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
        // GET: Models
        public ActionResult Index()
        {
            return View("_ModelsList");
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ModelsViewModel modelsviewmodel)
        {
            return View();
        }
    }
}