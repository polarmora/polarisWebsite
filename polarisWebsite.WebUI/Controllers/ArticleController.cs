using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Web.Script.Serialization;
using polarisWebsite.Domain.Abstract;
using polarisWebsite.Domain.Entities;
using polarisWebsite.WebUI.Models;

namespace polarisWebsite.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleRepository repository;

        public ArticleController(IArticleRepository articleRepository)
        {
            this.repository = articleRepository;
        }

        public ViewResult List()
        {
            return View(repository.Articles);
        }
        // GET: Article
        /*public ActionResult Index()
        {
            return View();
        }
        */
        public ViewResult Show(int articleID)
        {

            Article article = repository.Articles.FirstOrDefault(p => p.ArticleID == articleID);
            string rootArticle = "~/UpLoad/Articles";
            string phicyPath = null, fileName = null;
            phicyPath = HostingEnvironment.MapPath(rootArticle + '/' + article.ArticleID.ToString() + '/');
            fileName = article.ArticleID.ToString() + '.' + article.FileType;
            string filePath = phicyPath + fileName;

            ArticleViewModel articleVM = new ArticleViewModel();
            articleVM.ArticleID = article.ArticleID;
            articleVM.Title = article.Title;
            articleVM.Author = article.Author;
            articleVM.CreatedTime = article.CreatedTime;
            articleVM.RevisedTime = article.RevisedTime;
            articleVM.FileType = article.FileType;

            StringBuilder stringBuilder = new StringBuilder();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            jsSerializer.Serialize(System.IO.File.ReadAllText(filePath), stringBuilder);
            articleVM.Content = stringBuilder.ToString();
            /*
             * articleVM.Content = null;
            String[] lines= System.IO.File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                articleVM.Content += line + "\\n";
            }
            */
            return View(articleVM);
            /*
            
            return this.JavaScript("document.getElementById('display').innerHTML=markdown.toHTML(" + filePath + ")");
    */
            //return View();
           // return this.JavaScript(@"alert('hhh')");
           }
    }
}