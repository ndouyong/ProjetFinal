using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{

    /// Classe représentant un employé du système de bibliothèque
    public class Employer
    {
        public string Numero { get; set;}
        public string Nom {get; set;}

        /// <summary>
        /// Constructeur de la classe Employer
        /// </summary>
        /// <param name="numero">Code d'identification de l'employé</param>
        /// <param name="nom">Nom de l'employé</param>
        public Employer(string numero, string nom)
        {
            this.Numero = numero;
            this.Nom = nom;
        }
    }
}