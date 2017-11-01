using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Configuration;
using AmountInWords.BusinessContract;
using AmountInWords.BusinessImplementation;
using AmountInWords.WebAPI.Handlers;
using AmountInWords.Utilities;


namespace AmountInWords.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigSettings.ConnectionString = ConfigurationManager.ConnectionStrings["TFNValidatorContext"].ConnectionString;
            IApplication app = new Application();
            app.ResolveDependencies();            
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
        }
    }
}
