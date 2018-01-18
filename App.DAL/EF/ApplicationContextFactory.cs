using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace App.DAL.EF
{
    class ApplicationContextFactory : IDbContextFactory<ApplicationDataContext>
    {
        public ApplicationDataContext Create()
        {
            return new ApplicationDataContext("conmssql2");
        }
    }
}
