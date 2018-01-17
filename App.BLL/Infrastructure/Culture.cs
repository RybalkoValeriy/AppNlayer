using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.BLL.Infrastructure
{
    // Kласс с языками
    public class Culture
    {
        private readonly List<string> langlishList = new List<string>()
        {
            "ru","en","de"
        };

        public bool SerachLang(string lang)
        {
            return langlishList.Contains(lang);
        }
    }
}