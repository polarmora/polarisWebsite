using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polarisWebsite.Domain.Abstract;
using polarisWebsite.Domain.Entities;

namespace polarisWebsite.Domain.Concrete
{
    public class EFArticleRepository :IArticleRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Article> Articles
        {
            get { return context.Articles; }
        }

        public void SaveArticle(Article article)
        {
            if(article.ArticleID == 0)
            {
                article.CreatedTime = article.RevisedTime = DateTime.Now;
                context.Articles.Add(article);
            }
            else
            {
                Article dbEntry = context.Articles.Find(article.ArticleID);
                if(dbEntry != null)
                {
                    dbEntry.Title = article.Title;
                    dbEntry.Author = article.Author;
                    dbEntry.RevisedTime = DateTime.Now;
                    dbEntry.FileType = article.FileType;
                    //dbEntry.CreatedTime = article.CreatedTime;
                }
            }
            context.SaveChanges();
        }

        public Article DeleteArticle(int articleID)
        {
            Article dbEntry = context.Articles.Find(articleID);
            if (dbEntry != null)
            {
                context.Articles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
