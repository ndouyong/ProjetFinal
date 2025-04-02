using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    /// <summary>
    /// Classe représentant un livre dans le système de bibliothèque
    /// </summary>
    public class Livre
    {
        #region Proprietes
        
        /// Identifiant unique du livre
        public int Id {get; set;}
        public string? Titre { get; set; }
        public string? Auteur { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        #endregion

        #region Contructeur
        public Livre() { }

        /// <summary>
        /// Constructeur avec paramètres pour initialiser un nouveau livre
        /// </summary>
        /// <param name="id">Identifiant unique du livre</param>
        /// <param name="titre">Titre du livre</param>
        /// <param name="auteur">Nom de l'auteur</param>
        /// <param name="prix">Prix de vente</param>
        /// <param name="quantite">Quantité en stock</param>
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