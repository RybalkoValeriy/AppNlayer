using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Owin;
using App.BLL.Services;
using App.BLL.Interfaces;

[assembly: OwinStartup(typeof(App.WEB.Startup))]
namespace App.WEB
{
    public class Startup
    {
        IServiceCreator servCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IServices>(CreateServ);
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Registration/RegisterUser")
            });
        }
        private IServices CreateServ()
        {
            return servCreator.BuildServices("conmssql2");
        }
    }
}