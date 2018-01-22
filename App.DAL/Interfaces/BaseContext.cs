using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.DAL.Entities;

namespace App.DAL.Interfaces
{
    public interface IBaseContext
    {
        IDbSet<Topic> TopicsDbset { get; set; }
        IDbSet<Article> ArticleDbset { get; set; }
        IDbSet<Comments> CommentsDbset { get; set; }
    }
}
