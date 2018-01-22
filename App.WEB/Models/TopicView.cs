using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.WEB.Models
{
    public class TopicView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdd { get; set; }
        public bool TopicResolution { get; set; }
        public DateTime? DateResulution { get; set; }
    }
}