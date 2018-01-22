using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Data_Transfer_Objects
{
    public class TopicViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }
        public bool TopicResolution { get; set; }
        public DateTime? DateResulution { get; set; }
        public int? ArticleCount { get; set; }
    }
}
