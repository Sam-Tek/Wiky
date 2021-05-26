using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiky.Models;

namespace Wiky.Repository
{
    public class ArticleRepository : BaseRepository
    {
        public List<Article> FindAllArticle()
        {
            return base.Context.Article.ToList();
        }

        public Article FindOneById(int id)
        {
            return Context.Article.FirstOrDefault(a => id == a.Id);
        }

        public Article AddOneArticle(Article article)
        {
            article = Context.Article.Add(article);
            Context.SaveChanges();
            return article;
        }

        public Article DelOneArticle(Article article)
        {
            article = Context.Article.Remove(article);
            Context.SaveChanges();
            return article;
        }
    }
}