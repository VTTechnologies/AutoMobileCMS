using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMobileCMS.DAL.DBModel;


namespace AutoMobileCMS.Mapper
{
    public static class ProductsMapper
    {
        public static TblProduct Attach(ProductViewModel productsviewmodel)  
        {
            TblProduct products = new TblProduct();
            products.ProductID = productsviewmodel.ProductID;
            products.ProductName = productsviewmodel.ProductName;
            products.ProductOverview = productsviewmodel.ProductOverview;
            products.Price = productsviewmodel.Price;
            products.KMDriven = productsviewmodel.KMDriven;
            products.BrandID = productsviewmodel.BrandID;
            products.Status = productsviewmodel.Status;
            products.DateofPurchase = productsviewmodel.DateofPurchase;
            products.CreatedBy = productsviewmodel.CreatedBy;
            products.CreatedOn = productsviewmodel.CreatedOn;
            products.UpdatedBy = productsviewmodel.UpdatedBy;
            products.UpdatedOn = productsviewmodel.UpdatedOn;
            products.IsSold = productsviewmodel.IsSold;
            products.UserID = productsviewmodel.UserID;

            return products;

        }
        public static ProductViewModel Detach(TblProduct products)
        {
            ProductViewModel productsviewmodel = new ProductViewModel();
            productsviewmodel.ProductID = products.ProductID;
            productsviewmodel.ProductName = products.ProductName;
            productsviewmodel.ProductOverview = products.ProductOverview;
            productsviewmodel.Price = products.Price;
            productsviewmodel.KMDriven = products.KMDriven;
            productsviewmodel.BrandID = products.BrandID;
            productsviewmodel.Status = products.Status;
            productsviewmodel.DateofPurchase = products.DateofPurchase;
            productsviewmodel.CreatedBy = products.CreatedBy;
            productsviewmodel.CreatedOn = products.CreatedOn;
            productsviewmodel.UpdatedBy = products.UpdatedBy;
            productsviewmodel.UpdatedOn = products.UpdatedOn;
            productsviewmodel.UserID = products.UserID;
            productsviewmodel.IsSold = products.IsSold;
            productsviewmodel.productimages = products.TblProductImages == null ? null : new ProductImagesViewModel()
            {
                
            };

            return productsviewmodel;
        }
    }
}