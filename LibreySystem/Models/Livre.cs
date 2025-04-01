using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Livre
    {
        #region  Proprietes
        public int Id {get; set;}
        public string? Titre { get; set; }
        public string? Auteur { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        #endregion

        #region Contructeur
        public Livre() { }
        public Livre(int id, string titre, string auteur, double prix, int quantite)
        {
            this.Id = id;
            this.Titre = titre;
            this.Auteur = auteur;
            this.Prix = prix;
            this.Quantite = quantite;
        }
        #endregion
    }
}