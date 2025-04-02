using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Employer
    {
        public string Numero { get; set;}
        public string Nom {get; set;}

        public Employer(string numero, string nom)
        {
            this.Numero = numero;
            this.Nom = nom;
        }
    }
}