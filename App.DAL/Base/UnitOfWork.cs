using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using App.DAL.EF;
using App.DAL.Identity.Manager;
using App.DAL.Entities.Users;
using App.DAL.Interfaces;
using App.DAL.Entities;

namespace App.DAL.Base
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDataContext DataContext;
        ApplicationUserManager UserManager;
        ApplicationRoleManager RoleManager;

        IRepository<Topic> TopicRepository;
        IRepository<Article> ArticleRepository;
        IRepository<Comments> CommentsRepository;


        public UnitOfWork(string connStr)
        {
            DataContext = new ApplicationDataContext(connStr);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUsers>(DataContext));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(DataContext));
        }


        public async Task<ApplicationUsers> CreateUserAndGetUserAsync(ApplicationUsers newUser)
        {
            var result = await UserManager.CreateAsync(newUser);
            if (result.Succeeded)
            {
                return await UserManager.FindByIdAsync(newUser.Id);
            }
            throw new Exception("error create user");
        }

        public async Task AddRoleAndUserToRoleAddAsync(ApplicationUsers user, object roleName)
        {
            if (roleName != null)
            {
                var findRole = await RoleManager.FindByNameAsync(roleName.ToString());
                if (findRole == null)
                {
                    await RoleManager.CreateAsync(new ApplicationRole { Name = roleName.ToString() });
                }
                await UserManager.AddToRoleAsync(user.Id, roleName.ToString());
            }
            throw new ArgumentNullException("roleName is null");
        }

        public ApplicationDataContext Data => DataContext;

        public ApplicationUserManager UsersManager => UserManager;

        public ApplicationRoleManager RolesManager => RoleManager;

        public IRepository<Topic> Topics => TopicRepository ?? new Repository<Topic>(this.DataContext);

        public IRepository<Article> Articles => ArticleRepository ?? new Repository<Article>(this.DataContext);

        public IRepository<Comments> Comments => CommentsRepository ?? new Repository<Comments>(this.DataContext);

        public async Task SaveAsync()
        {
            await DataContext.SaveChangesAsync();
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }

        #region Disposable

        bool stateDisposed;

        public void Dispose()
        {
            IsDisposable(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void IsDisposable(bool isDisp)
        {
            if (!stateDisposed)
            {
                if (isDisp)
                {
                    DataContext.Dispose();
                    RoleManager.Dispose();
                    UserManager.Dispose();
                }
                this.stateDisposed = true;
            }
        }
        #endregion
    }
}
