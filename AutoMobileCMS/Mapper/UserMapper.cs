
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
        public static TblUser Attach(UserViewModel userviewmodel)
        {
            TblUser user = new TblUser();
            user.UserID = userviewmodel.UserID;
            user.UserName = userviewmodel.UserName;
            user.Email = userviewmodel.Email;
            user.ContactNo = userviewmodel.ContactNo;
            user.Password = userviewmodel.Password;
            user.Status = userviewmodel.Status;
            user.CreatedBy = userviewmodel.CreatedBy;
            user.CreatedOn = userviewmodel.CreatedOn;
            user.UpdatedBy = userviewmodel.UpdatedBy;
            user.UpdatedOn = userviewmodel.UpdatedOn;
            user.template_id = userviewmodel.template_id;

            user.UserInRoles = userviewmodel.UserInRoles == null ? null : userviewmodel.UserInRoles.Select(s => new UserInRole { UserRoleId = s.UserRoleId, RoleId = s.RoleId, UserId = s.UserId }).ToList();
            return user;
        }

        public static UserViewModel Detach(TblUser userMaster)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.UserID = userMaster.UserID;
            userViewModel.UserName = userMaster.UserName;
            userViewModel.Status = userMaster.Status;
            userViewModel.CreatedBy = userMaster.CreatedBy;
            userViewModel.CreatedOn = userMaster.CreatedOn;
            userViewModel.UpdatedBy = userMaster.UpdatedBy;
            userViewModel.UpdatedOn = userMaster.UpdatedOn;
            userViewModel.ContactNo = userMaster.ContactNo;
            userViewModel.Password = userMaster.Password;
            userViewModel.Email = userMaster.Email;
            userViewModel.template_id = userMaster.template_id;
            userViewModel.tblTemplate = userMaster.tblTemplate == null ? null : new TemplateViewModel()
            {
                template_id = userMaster.tblTemplate.template_id,
                template_name = userMaster.tblTemplate.template_name,
                isactive = userMaster.tblTemplate.isactive,

            };
                
            userViewModel.RoleName = userMaster.UserInRoles.FirstOrDefault().TblRole.RoleName;
            userViewModel.UserInRoles = userMaster.UserInRoles.Select(s => new UserInRoleViewModel { UserRoleId = s.UserRoleId, RoleId = s.RoleId.Value, UserId = s.UserId }).ToList();
            return userViewModel;
        }
    }
}