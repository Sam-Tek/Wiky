using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiky.Models;

namespace Wiky.Repository
{
    public class CommentaireRepository : BaseRepository
    {
        public List<Commentaire> FindAllCommentaire()
        {
            return Context.Commentaire.ToList();
        }

        public Commentaire FindOneCommentaireById(int id)
        {
            return Context.Commentaire.FirstOrDefault(a => id == a.Id);
        }

        public Commentaire AddOneCommentaire(Commentaire commentaire)
        {
            commentaire = Context.Commentaire.Add(commentaire);
            Context.SaveChanges();
            return commentaire;
        }

        public Commentaire DelOneCommentaire(Commentaire commentaire)
        {
            commentaire = Context.Commentaire.Remove(commentaire);
            Context.SaveChanges();
            return commentaire;
        }

        public Commentaire DelOneCommentaire(int id)
        {
            Commentaire commentaire = FindOneCommentaireById(id);
            
            if (commentaire != null)
                commentaire = DelOneCommentaire(commentaire);

            return commentaire;
        }

        public Commentaire AmendCommentaire(Commentaire commentaire)
        {
            Commentaire commentaireBDD = FindOneCommentaireById(commentaire.Id);

            if (commentaireBDD == null)
                return commentaireBDD;

            commentaireBDD.Auteur = commentaire.Auteur;
            commentaireBDD.Contenu = commentaire.Contenu;
            Context.SaveChanges();

            return commentaireBDD;
        }
    }
}