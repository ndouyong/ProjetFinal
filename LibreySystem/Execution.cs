using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    /// <summary>
    /// Classe principale gérant l'exécution du système de bibliothèque
    /// Contient les méthodes essentielles pour l'initialisation et le fonctionnement de l'application
    /// </summary>
    public class Execution
    {
        #region Initialisation
        /// <summary>
        /// Initialise la liste des employés avec leurs codes d'accès
        /// </summary>
        /// <returns>Liste des employés pré-enregistrés dans le système</returns>
        public static List<Employer> Debut()
        {
            // Création d'une nouvelle liste pour stocker les employés
            List<Employer> employers = new();

            // Ajout des employés avec leurs codes d'accès respectifs
            // Format: (Code d'accès, Nom de l'employé)
            employers.Add(new Employer("011", "Abderrahmane"));
            employers.Add(new Employer("102", "Samir"));
            employers.Add(new Employer("033", "Jonathan"));
            employers.Add(new Employer("204", "Harold"));
            employers.Add(new Employer("384", "Mohamed"));

            return employers;
        }
        #endregion

        #region Validation_code
        /// <summary>
        /// Vérifie et valide le code d'accès d'un employé
        /// </summary>
        /// <param name="employers">Liste des employés enregistrés</param>
        /// <returns>L'employé correspondant au code saisi, ou null si le code est invalide</returns>
        public static Employer Employer_Check(List<Employer> employers)
        {
            try
            {
                string code;
                // Boucle de saisie jusqu'à obtenir un code valide
                do
                {
                    Console.WriteLine("Entrer le code employer : ");
                    code = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(code)) Console.WriteLine("Le code ne peut etre vide");

                } while (string.IsNullOrEmpty(code));

                // Recherche de l'employé correspondant au code saisi
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
        /// <summary>
        /// Gère le menu principal et les opérations de l'application
        /// </summary>
        /// <param name="employer">Employé connecté au système</param>
        public static void Execu(Employer employer)
        {
            try
            {
                // Initialisation de la liste des livres
                List<Livre> livres = new();

                bool continuer = true;
                while (continuer)
                {
                    switch (Api.Menu())
                    {
                        case 1: // Ajout d'un nouveau livre
                            {
                                int id = livres.Count + 1;
                                livres.Add(Api.Ajout_livre(id));
                                Console.WriteLine("Livre ajouté avec succès !");
                                break;
                            }

                        case 2: // Affichage de tous les livres
                            {
                                Api.Afficher(livres);
                                break;
                            }

                        case 3: // Vente d'un livre
                            {
                                Livre buffer = Api.Vendre(livres);
                                if (buffer != null)
                                {
                                    livres[buffer.Id - 1].Quantite = buffer.Quantite;
                                }
                                break;
                            }

                        case 4: // Prêt d'un livre
                            {
                                Livre buffer = Api.Preter(livres);
                                if (buffer != null)
                                {
                                    livres[buffer.Id - 1].Quantite = buffer.Quantite;
                                }
                                break;
                            }

                        case 5: // Retour d'un livre
                            {
                                Livre buffer = Api.Retourner(livres);
                                if (buffer != null)
                                {
                                    livres[buffer.Id - 1].Quantite = buffer.Quantite;
                                }
                                break;
                            }

                        case 6: // Quitter l'application
                            {
                                continuer = Api.Quitter();
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