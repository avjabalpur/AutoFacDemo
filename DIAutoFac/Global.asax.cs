using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DIAutoFac
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            //Register dependency in controller
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Register dependency in filter attribute
            builder.RegisterFilterProvider();

            //Register dependency in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            //Register Data dependency
            builder.RegisterModule(new DataModule("DIAutoFacContext"));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
