
using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Mapper
{
    public static class UserMapper
    {
        public static TblUser Attach(RegisterViewModel registerviewmodel)
        {
            TblUser user = new TblUser();
            user.UserID = registerviewmodel.UserId;
            user.UserName = registerviewmodel.UserName;
            user.ContactNo = registerviewmodel.contactNo;
            user.Password = registerviewmodel.Password;
            user.Status = registerviewmodel.Status;
            user.CreatedBy = registerviewmodel.CreatedBy;
            user.CreatedOn = registerviewmodel.CreatedOn;
            user.UpdatedBy = registerviewmodel.UpdatedBy;
            user.UpdatedOn = registerviewmodel.UpdatedOn;
            return user;
        }

        public static RegisterViewModel Detach(TblUser user)
        {
            RegisterViewModel registerviewmodel = new RegisterViewModel();
            registerviewmodel.UserId = user.UserID;
            registerviewmodel.UserName = user.UserName;
            registerviewmodel.Status = user.Status;
            registerviewmodel.CreatedBy = user.CreatedBy;
            registerviewmodel.CreatedOn = user.CreatedOn;
            registerviewmodel.UpdatedBy = user.UpdatedBy;
            registerviewmodel.UpdatedOn = user.UpdatedOn;
            return registerviewmodel;
        }
    }
}