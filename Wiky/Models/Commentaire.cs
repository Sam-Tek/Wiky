using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiky.Models
{
    public class Commentaire
    {
        public int Id { get; set; }

        [DisplayName("Auteur")]
        [Required(ErrorMessage = "Vous devez saisir un Auteur")]
        [StringLength(30, ErrorMessage = "30 caractères maximum")]
        public string Auteur { get; set; }

        [DisplayName("Date de Création")]
        public DateTime DateCreation { get; set; }

        [DisplayName("Contenu")]
        public string Contenu { get; set; }

        [DisplayName("Article")]
        [Required(ErrorMessage = "Vous devez sélectionner un Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}