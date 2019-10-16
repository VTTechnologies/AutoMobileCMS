using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Mapper
{
    public static class ProductImagesMapper
    {
        public static TblProductImage Attach(ProductImagesViewModel productimagesviewmodel)
        {
            TblProductImage productimages = new TblProductImage();
            productimages.ProductImagesID = productimagesviewmodel.ProductImagesID;
            productimages.ProductID = productimagesviewmodel.ProductID;
            productimages.ImagePath1 = productimagesviewmodel.ImagePath1;
            productimages.ImagePath2 = productimagesviewmodel.ImagePath2;
            productimages.ImagePath3 = productimagesviewmodel.ImagePath3;
            productimages.ImagePath4 = productimagesviewmodel.ImagePath4;
            productimages.ImagePath5 = productimagesviewmodel.ImagePath5;
            productimages.ImagePath6 = productimagesviewmodel.ImagePath6;
            productimages.ImagePath7 = productimagesviewmodel.ImagePath7;
            productimages.ImagePath8 = productimagesviewmodel.ImagePath8;
            productimages.ImagePath9 = productimagesviewmodel.ImagePath9;
            return productimages;
        }

        public static ProductImagesViewModel Detach(TblProductImage productimages)
        { 
            ProductImagesViewModel productimagesviewmodel = new ProductImagesViewModel();
            productimagesviewmodel.ProductImagesID = productimages.ProductImagesID;
            productimagesviewmodel.ProductID = productimages.ProductID;
            productimagesviewmodel.ImagePath1 = productimages.ImagePath1;
            productimagesviewmodel.ImagePath2 = productimages.ImagePath2;
            productimagesviewmodel.ImagePath3 = productimages.ImagePath3;
            productimagesviewmodel.ImagePath4 = productimages.ImagePath4;
            productimagesviewmodel.ImagePath5 = productimages.ImagePath5;
            productimagesviewmodel.ImagePath6 = productimages.ImagePath6;
            productimagesviewmodel.ImagePath7 = productimages.ImagePath7;
            productimagesviewmodel.ImagePath8 = productimages.ImagePath8;
            productimagesviewmodel.ImagePath9 = productimages.ImagePath9;

            productimagesviewmodel.products = productimages.TblProduct == null ? null : new ProductViewModel()
            {
                ProductID = productimages.TblProduct.ProductID,
                ProductName = productimages.TblProduct.ProductName,
                ProductOverview = productimages.TblProduct.ProductOverview,
                Price = productimages.TblProduct.Price,
                DateofPurchase = productimages.TblProduct.DateofPurchase,
                KMDriven = productimages.TblProduct.KMDriven,
                BrandName = productimages.TblProduct.TblBrand.BrandName
            };
            return productimagesviewmodel;
        }


    }
}