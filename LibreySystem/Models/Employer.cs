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
        private int Numero { get; set;}
        private string Nom {get; set;}

        public Employer(int numero, string nom)
        {
            this.Numero = numero;
            this.Nom = nom;
        }
    }
}