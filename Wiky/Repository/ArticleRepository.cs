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
            return Context.Article.ToList();
        }

        public Article FindOneArticleById(int id)
        {
            return Context.Article.FirstOrDefault(a => id == a.Id);
        }

        public List<Article> FindArticleByTheme(string theme)
        {
            return Context.Article.Where(a => a.Theme.ToUpper() == theme.ToUpper()).ToList();
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

        public Article DelOneArticle(int id)
        {
            Article article = FindOneArticleById(id);
            
            if (article != null)
                article = DelOneArticle(article);

            return article;
        }

        public Article AmendArticle(Article article)
        {
            Article articleBDD = FindOneArticleById(article.Id);

            if (articleBDD == null)
                return articleBDD;

            articleBDD.Auteur = article.Auteur;
            articleBDD.Theme = article.Theme;
            articleBDD.Contenu = article.Contenu;
            Context.SaveChanges();

            return articleBDD;
        }

        public Article FindLastArticle()
        {
            return Context.Article.OrderByDescending(a => a.DateCreation).FirstOrDefault();
        }

        public List<Article> FindArticle(string search)
        {
            List<Article> articles = Context.Article.Where(a => a.Auteur.Contains(search) || a.Theme.Contains(search) || a.Contenu.Contains(search)).ToList();
            return articles;
        }
    }
}