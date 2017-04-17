using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace polarisWebsite.WebUI.Models
{
    public class ArticleViewModel
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime RevisedTime { get; set; }
        public string FileType { get; set; }
        public string Content { get; set; }
    }
}