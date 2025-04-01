using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using ProjetFinal;
namespace LibreySystem
{
    public class Execution
    {
        public static void Execu()
        {
            try
            {
                List<Livre> livres = new();

                //Console.WriteLine(livres.Count);
                bool x = true;
                while (x)
                {
                    switch (Api.Menu())
                    {
                        //Option 1 pour ajouter un livre
                        case 1:
                            {
                                int id = livres.Count + 1;
                                livres.Add(Api.Ajout_livre(id));
                                break;
                            }

                        //Option 2 pour Affichier les livres
                        case 2:
                            {
                                Api.Afficher(livres);

                                break;
                            }

                        //Option pour vendre un livre
                        case 3:
                            {
                                Livre buffer = Api.Vendre(livres);
                                if (buffer != null)
                                {
                                    livres[buffer.Id - 1].Quantite = buffer.Quantite;
                                }
                                break;
                            }

                        case 4:
                            {
                                Livre buffer = Api.Preter(livres);
                                if (buffer != null)
                                {
                                    livres[buffer.Id - 1].Quantite = buffer.Quantite;
                                }
                                break;
                            }
                        case 5:
                            {
                                Livre buffer = Api.Retourner(livres);
                                if (buffer != null)
                                {
                                    livres[buffer.Id - 1].Quantite = buffer.Quantite;
                                }
                                break;
                            }

                        case 6:
                            {
                                x = Api.Quitter();
                                break;
                            }

                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}