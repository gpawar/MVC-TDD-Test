using LightInject;
using MVC_TDD_Test.Database;
using MVC_TDD_Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MVC_TDD_Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new ServiceContainer();
            container.RegisterControllers();        

            //container.Register<IAccountService, AccountService>(new PerScopeLifetime());
            container.Register<ICategoryRepository, CategoryRepository>(new PerScopeLifetime());
            //container.Register<IPasswordRepository, PasswordRepository>(new PerScopeLifetime());
            //container.Register<IUserPasswordRepository, UserPasswordRepository>(new PerScopeLifetime());

            //container.Register<IViewModelValidatorService, ViewModelValidatorService>(new PerScopeLifetime());
            //container.Register<IPermissionService, PermissionService>(new PerScopeLifetime());
            //container.Register<IViewModelService, ViewModelService>(new PerScopeLifetime());

            container.Register<ApplicationDbContext, ApplicationDbContext>(new PerScopeLifetime());
            container.Register<ApplicationUserManager, ApplicationUserManager>(new PerScopeLifetime());

            container.EnableMvc();
        }
    }
}
