using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using App.DAL.Entities;
using App.DAL.Entities.Users;

namespace App.DAL.EF
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))] //MySql
    public class ApplicationDataContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDataContext(string connStr) : base(connStr)
        {
        }


        //------------------------------------------------------------
        public DbSet<ApplicationRole> RolesDbSet { get; set; }
        public DbSet<Topic> TopicsDbset { get; set; }
        public DbSet<Article> ArticleDbset { get; set; }
        public DbSet<Comments> CommentsDbset { get; set; }
        //-----------------------------------------------------------


        //use Fluent API
        protected override void OnModelCreating(DbModelBuilder modelBilder)
        {
            //Users
            modelBilder.Entity<ApplicationUsers>().Property(x => x.DateReg).IsRequired();
            modelBilder.Entity<ApplicationUsers>().Property(x => x.DateRecovery).HasColumnType("datetime").IsOptional();
            modelBilder.Entity<ApplicationUsers>().Property(x => x.CodeRecovery).IsOptional();
            //user=>many=>them
            modelBilder.Entity<ApplicationUsers>().HasMany(x => x.TopicsId).WithRequired(x => x.UserId);
            //user=>many=>article
            modelBilder.Entity<ApplicationUsers>().HasMany(x => x.ArticleId).WithOptional(x => x.UserId);
            //user=>many=>comments
            modelBilder.Entity<ApplicationUsers>().HasMany(x => x.CommentsId).WithOptional(x => x.UserId);

            //Topic
            modelBilder.Entity<Topic>().Property(x => x.Name).IsRequired();
            modelBilder.Entity<Topic>().Property(x => x.DateAdd).IsRequired();
            modelBilder.Entity<Topic>().Property(x => x.TopicResolution).IsRequired();
            modelBilder.Entity<Topic>().Property(x => x.DateResulution).IsOptional();
            //topic->many->articles
            modelBilder.Entity<Topic>().HasMany(x => x.ArticleId).WithRequired(x => x.TopicId);

            //Article
            modelBilder.Entity<Article>().Property(x => x.DatePosted).IsRequired();
            modelBilder.Entity<Article>().Property(x => x.Heading).IsRequired();
            modelBilder.Entity<Article>().Property(x => x.Description).IsRequired();
            modelBilder.Entity<Article>().Property(t => t.ArticleResolution).IsRequired();
            modelBilder.Entity<Article>().Property(x => x.DateResoulution).IsOptional();
            //article->many->Comments
            modelBilder.Entity<Article>().HasMany(x => x.CommentsId).WithRequired(x => x.ArticleId);

            //Comments
            modelBilder.Entity<Comments>().Property(x => x.DateComments).IsRequired();
            modelBilder.Entity<Comments>().Property(x => x.Message).IsRequired();
            modelBilder.Entity<Comments>().Property(x => x.DateComments).IsRequired();

            base.OnModelCreating(modelBilder);
        }

        public static ApplicationDataContext Create()
        {
            return new ApplicationDataContext("conmssql2");
        }
    }
}