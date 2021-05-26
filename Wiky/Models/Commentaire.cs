using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiky.Models
{
    public class Commentaire
    {
        public int Id { get; set; }
        public string Auteur { get; set; }
        public DateTime DateCreation { get; set; }
        public string Contenu { get; set; }
        public virtual Article Article { get; set; }
    }
}