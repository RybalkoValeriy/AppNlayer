using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using App.DAL.Entities.Users;
using App.DAL.EF;

namespace App.DAL.Identity.Manager
{
    public class ApplicationUserManager : UserManager<ApplicationUsers>
    {
        public ApplicationUserManager(IUserStore<ApplicationUsers> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var db = context.Get<ApplicationDataContext>();
            var manager = new ApplicationUserManager(new UserStore<ApplicationUsers>(db))
            {
                UserTokenProvider =
                new DataProtectorTokenProvider<ApplicationUsers>(
                    new DpapiDataProtectionProvider("ASPmvc").Create("ASP.NET Identity")),

                //EmailService = new EmailSendTask();

            };

            return manager;
        }
    }
}