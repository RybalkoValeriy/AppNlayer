using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.DAL.Entities.Users
{
    public class ApplicationRole: IdentityRole
    {
        public string DescriptionRole { get; set; }
    }
}