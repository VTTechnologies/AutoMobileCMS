
using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Mapper
{
    public static class CompanyMapper
    {
        public static TblCompany Attach(RegisterViewModel registerviewmodel)
        {
            TblCompany company = new TblCompany();
            company.CompanyID = registerviewmodel.CompanyId;
            company.UserID = registerviewmodel.UserId;
            company.CompanyName = registerviewmodel.CompanyName;
            company.Address = registerviewmodel.Adress;
            company.Status = registerviewmodel.Status;
            company.CreatedBy = registerviewmodel.CreatedBy;
            company.CreatedOn = registerviewmodel.CreatedOn;
            company.UpdatedBy = registerviewmodel.UpdatedBy;
            company.UpdatedOn = registerviewmodel.UpdatedOn;
            return company;
        }

        public static RegisterViewModel Detach(TblCompany company)
        {
            RegisterViewModel registerviewmodel = new RegisterViewModel();
            registerviewmodel.CompanyId = company.CompanyID;
            registerviewmodel.UserId = Convert.ToInt32(company.UserID);
            registerviewmodel.CompanyName = company.CompanyName;
            registerviewmodel.Adress = company.Address;
            registerviewmodel.Status = company.Status;
            registerviewmodel.CreatedBy = company.CreatedBy;
            registerviewmodel.CreatedOn = company.CreatedOn;
            registerviewmodel.UpdatedBy = company.UpdatedBy;
            registerviewmodel.UpdatedOn = company.UpdatedOn;
            return registerviewmodel;
        }
    }
}