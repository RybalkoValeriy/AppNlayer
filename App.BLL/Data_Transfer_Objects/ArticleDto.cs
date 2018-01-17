using App.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.BLL.Data_Transfer_Objects
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Description { get; set; }
        public bool ArticleResolution { get; set; }
        public AppUserDto UserId { get; set; }
        public TopicViewDto TopicId { get; set; }
    }
}
