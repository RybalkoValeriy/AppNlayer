using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.DAL.Entities.Users;

namespace App.DAL.Entities
{
    ///<summary>Модель с комментариями</summary>
    public class Comments
    {
        public int Id { get; set; }
        public DateTime DateComments { get; set; }
        public ApplicationUsers UserId { get; set; }
        public Article ArticleId { get; set; }
        public string Message { get; set; }

        public Comments()
        {
            DateComments = DateTime.UtcNow;
        }
    }
}