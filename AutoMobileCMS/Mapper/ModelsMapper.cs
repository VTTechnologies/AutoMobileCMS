using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMobileCMS.DAL.DBModel;


namespace AutoMobileCMS.Mapper
{
    public static class ModelsMapper
    {
        public static TblModel Attach(ModelsViewModel modelsviewmodel)  
        {
            TblModel models = new TblModel();
            models.ModelID = modelsviewmodel.ModelID;
            models.ImagePath1 = modelsviewmodel.ImagePath1;
            models.ImagePath2 = modelsviewmodel.ImagePath2;
            models.ImagePath3 = modelsviewmodel.ImagePath3;
            models.ImagePath4 = modelsviewmodel.ImagePath4;
            models.ModelName = modelsviewmodel.ModelName;
            models.ModelOverview = modelsviewmodel.ModelOverview;
            models.Price = modelsviewmodel.Price;
            models.KMDriven = modelsviewmodel.KMDriven;
            models.CompanyID = modelsviewmodel.CompanyID;
            models.BrandID = modelsviewmodel.BrandID;
            models.Status = modelsviewmodel.Status;
            models.DateofPurchase = modelsviewmodel.DateofPurchase;
            models.CreatedBy = modelsviewmodel.CreatedBy;
            models.CreatedOn = modelsviewmodel.CreatedOn;
            models.UpdatedBy = modelsviewmodel.UpdatedBy;
            models.UpdatedOn = modelsviewmodel.UpdatedOn;
            return models;


        }
        public static ModelsViewModel Detach(TblModel models)
        {
            ModelsViewModel modelsviewmodel = new ModelsViewModel();
            modelsviewmodel.ModelID = models.ModelID;
            modelsviewmodel.ImagePath1 = models.ImagePath1;
            modelsviewmodel.ImagePath2 = models.ImagePath2;
            modelsviewmodel.ImagePath3 = models.ImagePath3;
            modelsviewmodel.ImagePath4 = models.ImagePath4;
            modelsviewmodel.ModelName = models.ModelName;
            modelsviewmodel.ModelOverview = models.ModelOverview;
            modelsviewmodel.Price = models.Price;
            modelsviewmodel.KMDriven = models.KMDriven;
            modelsviewmodel.CompanyID = models.CompanyID;
            modelsviewmodel.BrandID = models.BrandID;
            modelsviewmodel.Status = models.Status;
            modelsviewmodel.DateofPurchase = models.DateofPurchase;
            modelsviewmodel.CreatedBy = models.CreatedBy;
            modelsviewmodel.CreatedOn = models.CreatedOn;
            modelsviewmodel.UpdatedBy = models.UpdatedBy;
            modelsviewmodel.UpdatedOn = models.UpdatedOn;
            return modelsviewmodel;


        }
    }
}