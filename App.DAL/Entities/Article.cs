using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.DAL.Entities.Users;
namespace App.DAL.Entities
{
    ///<summary>Модель с статьями</summary>
    public class Article
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public bool ArticleResolution { get; set; }// валидация для публикации
        public DateTime? DateResoulution { get; set; }
        public ApplicationUsers UserId { get; set; }
        public Topic TopicId { get; set; }
        public ICollection<Comments> CommentsId { get; set; }

        public Article()
        {
            ArticleResolution = false;
            DatePosted = DateTime.UtcNow;
            CommentsId = new List<Comments>();
        }
    }
}