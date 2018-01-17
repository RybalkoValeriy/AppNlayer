using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.DAL.Entities.Users
{
    public class ApplicationUsers: IdentityUser
    {
        public byte[] Photo { get; set; }// photo
        public DateTime DateReg { get; set; }// дата регистрации
        public string CodeRecovery { get; set; }// код для восстановления
        public DateTime? DateRecovery { get; set; }// дата когда был послан на почту пароль для восстановления
        public DateTime? DateLastVisited { get; set; }// последний визит
        public virtual ICollection<Topic> TopicsId { get; set; }// темы
        public virtual ICollection<Article> ArticleId { get; set; }// статьи
        public virtual ICollection<Comments> CommentsId { get; set; }// коментарии

        public ApplicationUsers() : base()
        {
            DateReg = DateTime.UtcNow;
            TopicsId = new List<Topic>();
            ArticleId = new List<Article>();
            CommentsId = new List<Comments>();
        }

    }
}