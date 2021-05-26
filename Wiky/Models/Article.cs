using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Wiky.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Thème")]
        public string Theme { get; set; }

        [DisplayName("Auteur")]
        public string Auteur { get; set; }

        [DisplayName("Date de Création")]
        public DateTime DateCreation { get; set; }

        [DisplayName("Contenu")]
        public string Contenu { get; set; }

        [DisplayName("Commentaires")]
        public virtual List<Commentaire> Commentaires { get; set; }
    }
}