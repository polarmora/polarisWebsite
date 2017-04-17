using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace polarisWebsite.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }  //将使用ID直接解析文档路径，文档单独存放在服务器上，不存入数据库
        [Required(ErrorMessage = "Please enter a title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author's name")]
        public string Author { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RevisedTime { get; set; }
        public string FileType { get; set; }

        
    }
}
