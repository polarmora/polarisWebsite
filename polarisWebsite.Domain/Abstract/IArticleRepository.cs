using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using polarisWebsite.Domain.Entities;

namespace polarisWebsite.Domain.Abstract
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Articles { get; }

        void SaveArticle(Article article);

        Article DeleteArticle(int articleID);
    }

}
