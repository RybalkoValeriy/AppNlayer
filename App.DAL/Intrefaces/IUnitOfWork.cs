using App.DAL.EF;
using App.DAL.Entities;
using App.DAL.Identity.Manager;
using App.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Intrefaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDataContext Data { get; }
        ApplicationUserManager UsersManagers { get; }
        ApplicationRoleManager RolesManagers { get; }
        IRepository<Topic> Topics { get; }
        IRepository<Article> Articles { get; }
        IRepository<Comments> Comments { get; }
        Task SaveAsync();
        void Save();
    }
}
