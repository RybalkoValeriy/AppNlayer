using System;
using System.Threading.Tasks;
using App.DAL.EF;
using App.DAL.Identity.Manager;
using App.DAL.Entities.Users;
using App.DAL.Entities;
using App.Repository.Interfaces;

namespace App.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
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

        public ApplicationDataContext Data => DataContext;

        public ApplicationUserManager UsersManagers => UserManager;

        public ApplicationRoleManager RolesManagers => RoleManager;

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
