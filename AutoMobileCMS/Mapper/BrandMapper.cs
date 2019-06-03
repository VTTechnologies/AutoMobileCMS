
using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Mapper
{
    public static class BrandMapper
    {
        public static TblBrand Attach(BrandViewModel brandviewmodel)
        {
            TblBrand brand = new TblBrand();
            brand.BrandID = brandviewmodel.BrandID;
            brand.BrandName = brandviewmodel.BrandName;
            brand.Status = brandviewmodel.Status;
            brand.CreatedBy = brandviewmodel.CreatedBy;
            brand.CreatedOn = brandviewmodel.CreatedOn;
            brand.UpdatedBy = brandviewmodel.UpdatedBy;
            brand.UpdatedOn = brandviewmodel.UpdatedOn;
            return brand;
        }

        public static BrandViewModel Detach(TblBrand brand)
        {
            BrandViewModel brandviewmodel = new BrandViewModel();
            brandviewmodel.BrandID = brand.BrandID;
            brandviewmodel.BrandName = brand.BrandName;
            brandviewmodel.Status = brand.Status;
            brandviewmodel.CreatedBy = brand.CreatedBy;
            brandviewmodel.CreatedOn = brand.CreatedOn;
            brandviewmodel.UpdatedBy = brand.UpdatedBy;
            brandviewmodel.UpdatedOn = brand.UpdatedOn;
            return brandviewmodel;
        }
    }
}