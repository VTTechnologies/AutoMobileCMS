using AutoMobileCMS.DAL.IService;
using AutoMobileCMS.DAL.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AutoMobileCMS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserInRoleService, UserInRoleService>();
            container.RegisterType<ITemplateService, TemplateService>();
            container.RegisterType<IProductImagesService, ProductImagesService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}