using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wiky.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Thème")]
        [Required(ErrorMessage = "Vous devez saisir un Thème")]
        [Remote("ThemeUnique", "Article", ErrorMessage = "Le thème doit être unique.", AdditionalFields = "Id")]
        public string Theme { get; set; }

        [DisplayName("Auteur")]
        [Required(ErrorMessage = "Vous devez saisir un Auteur")]
        public string Auteur { get; set; }

        [DisplayName("Date de Création")]
        public DateTime DateCreation { get; set; }

        [DisplayName("Contenu")]
        public string Contenu { get; set; }

        [DisplayName("Commentaires")]
        public virtual List<Commentaire> Commentaires { get; set; }
    }
}