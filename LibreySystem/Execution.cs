using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Execution
    {
        #region Initialisation
        public static List<Employer> Debut()
        {
            //Création de la liste des employés
            List<Employer> employers = new();

            //Ajouter manuelle des employés
            employers.Add(new Employer("011", "Abderrahmane"));
            employers.Add(new Employer("102", "Samir"));
            employers.Add(new Employer("033", "Jonathan"));
            employers.Add(new Employer("204", "Harold"));
            employers.Add(new Employer("384", "Mohamed"));

            return employers;
        }
        #endregion

        #region Valdation_code
        //Validation du code de l'utilisateur
        public static Employer Employer_Check(List<Employer> employers)
        {
            try
            {
                string code;
                do
                {
                    Console.WriteLine("Entrer le code employer : ");
                    code = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(code)) Console.WriteLine("Le code ne peut etre vide");

                } while (string.IsNullOrEmpty(code));

                Employer employer = employers.FirstOrDefault(e => e.Numero == code);

                if (employer == null)
                {
                    Console.WriteLine("Code Invalide, Merci de verifier votre code.");
                    return null;
                }

                return employer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la verfifcation du code employer : {ex.Message}");
            }
        }
        #endregion

        #region Execution_code
        public static void Execu(Employer employer)
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
        #endregion


    }
}