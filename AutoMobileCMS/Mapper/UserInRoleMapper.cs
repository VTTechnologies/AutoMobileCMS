
using AutoMobileCMS.DAL.DBModel;
using AutoMobileCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMobileCMS.Mapper
{
    public static class UserInRoleMapper
    {
        public static UserInRole Attach(UserInRoleViewModel userInRoleViewModeu)
        {
            UserInRole uRole = new UserInRole();
            uRole.UserRoleId = userInRoleViewModeu.UserRoleId;
            uRole.RoleId = userInRoleViewModeu.RoleId;
            uRole.UserId = userInRoleViewModeu.UserId;;
            return uRole;
        }

        public static UserInRoleViewModel Detach(UserInRole uRole)
        {
            UserInRoleViewModel userInRoleViewModeu = new UserInRoleViewModel();
            userInRoleViewModeu.UserRoleId = Convert.ToInt32(uRole.UserRoleId);
            userInRoleViewModeu.UserId = Convert.ToInt32(uRole.UserId);
            userInRoleViewModeu.RoleId = Convert.ToInt32(uRole.RoleId);
            return userInRoleViewModeu;
        }
    }
}