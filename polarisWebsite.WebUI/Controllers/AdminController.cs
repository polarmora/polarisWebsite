using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;
using System.IO;
using polarisWebsite.Domain.Abstract;
using polarisWebsite.Domain.Entities;

namespace polarisWebsite.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IArticleRepository articleRepository;

        public AdminController(IArticleRepository repo)
        {
            articleRepository = repo;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ArticleIndex()
        {
            return View(articleRepository.Articles);
        }

        public ViewResult ArticleEdit(int articleId)
        {
            Article article = articleRepository.Articles.FirstOrDefault(p => p.ArticleID == articleId);
            return View(article);
        }

        [HttpPost]
        public ActionResult ArticleEdit(Article article, HttpPostedFileBase file = null, IEnumerable<HttpPostedFileBase> images = null)
        {
            string rootArticle = "~/UpLoad/Articles";
            //string phicyPath = null, fileName = null;
            if (ModelState.IsValid)
            {
                articleRepository.SaveArticle(article);
                TempData["message_attr"] = string.Format("Attributes of {0} has been saved.", article.Title);

                Article newArticle = articleRepository.Articles.FirstOrDefault(p => p.ArticleID == article.ArticleID);
                string phicyPath = HostingEnvironment.MapPath(rootArticle + '/' + newArticle.ArticleID.ToString() + '/');
                Directory.CreateDirectory(phicyPath);

                if (file != null)
                {
                    string fileName = newArticle.ArticleID.ToString() + '.' + newArticle.FileType;
                    file.SaveAs(phicyPath + fileName);
                    TempData["message_file"] = string.Format("{0} has been saved to {1}.", newArticle.Title, phicyPath + fileName);
                }
                if (images.FirstOrDefault() != null)
                {
                    foreach (var image in images)
                    {
                        string imageName = image.FileName;
                        image.SaveAs(phicyPath + imageName);
                        TempData["message_images"] = string.Format("Attached images of {0} has been saved to {1}.", newArticle.Title, phicyPath + imageName);
                    }
                }

                return RedirectToAction("ArticleIndex");
            }
            else
            {
                return View(article);
            }
        }

        public ViewResult ArticleCreate()
        {
            return View("ArticleEdit", new Article());
        }

        [HttpPost]
        public ActionResult Delete(int articleID)
        {
            Article deletedProduct = articleRepository.DeleteArticle(articleID);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Title);
            }
            return RedirectToAction("ArticleIndex");
        }
        }
}