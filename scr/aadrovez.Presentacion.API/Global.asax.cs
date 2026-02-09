using aadrovez.Presentacion.API.App_Start;
using AutoMapper;
using System.Web.Http;

namespace aadrovez.Presentacion.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Register(GlobalConfiguration.Configuration);
           
        }
    }
}
