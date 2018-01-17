using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL.Services;
using App.BLL.Interfaces;
using App.BLL.Data_Transfer_Objects;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace App.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IServices Service = null;

        public IServices Services
        {
            get
            {
                if (Service == null)
                    Services = HttpContext.GetOwinContext().GetUserManager<IServices>();
                return Service;
            }
            set
            {
                Service = value;
            }
        }

        public HomeController()
        {
        }

        public ActionResult Topic()
        {
            DbInitilize();
            var model = Services.GetAllTopic();
            //todo: добавить свою модель
            return View("Topic", model);
        }

        public ActionResult Article(int id)
        {

        }

        private Task DbInitilize()
        {
            //todo: not role
            return Services.SetInitilizeDatabaseUsersAndRoles(
                new List<UserDto> {
                    new UserDto
                        {
                            Email = "admin@mail.com",
                            UserName = "admin",
                            Password = "123456",
                            RoleName = "admin"
                        }
                });
        }
    }
}