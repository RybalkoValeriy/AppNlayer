using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.DAL.Entities.Users;

namespace App.DAL.Entities
{
    ///<summary>Модель с тематиками</summary>
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }
        public bool TopicResolution { get; set; }
        public DateTime? DateResulution { get; set; }
        public virtual ApplicationUsers UserId { get; set; }
        public ICollection<Article> ArticleId { get; set; }

        public Topic()
        {
            TopicResolution = false;
            DateAdd = DateTime.UtcNow;
            ArticleId = new List<Article>();
        }

    }
}