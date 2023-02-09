using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication2Crud.BuisnessLayer.Clasees;
using WebApplication2Crud.BuisnessLayer.Interfaces;
using WebApplication2Crud.BuisnessLayer.Product.Classes;
using WebApplication2Crud.BuisnessLayer.Product.Interfaces;
using WebApplication2Crud.BuisnessLayer.User.Classes;
using WebApplication2Crud.BuisnessLayer.User.Interfaces;
using WebApplication2Crud.StoreProcedures;

namespace WebApplication2Crud
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ICreate, Create>();
            container.RegisterType<IEdit, Edit>();
            container.RegisterType<IPaging, PagingProcedure>();
            container.RegisterType<IDetails, Details>();
            container.RegisterType<IDelete, Delete>();
            container.RegisterType<IShowCategory, ShowCategory>();
            container.RegisterType<IShowCategoryItem, ShowCategoryItem>();
            container.RegisterType<IRegisterUser, RegisterUser>();





            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}