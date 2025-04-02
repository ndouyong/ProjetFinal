using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    /// <summary>
    /// Classe Api qui gère toutes les interactions avec l'utilisateur et les opérations sur les livres
    /// </summary>
    public class Api
    {
        /// <summary>
        /// Affiche le menu principal et récupère le choix de l'utilisateur
        /// </summary>
        /// <returns>Un entier représentant l'option choisie par l'utilisateur (1-6)</returns>
        #region Menu
        public static int Menu()
        {
            while (true)
            {
                try
                {
                    //On affiche le menu
                    Console.WriteLine("");
                    Console.WriteLine("\u001b[1m --- Menu Principal --- \u001b[0m");
                    Console.WriteLine(" 1. Ajouter un livre ");
                    Console.WriteLine(" 2. Afficher les livres disponibles ");
                    Console.WriteLine(" 3. Vendre un livre ");
                    Console.WriteLine(" 4. Prêter un livre ");
                    Console.WriteLine(" 5. Retourner un livre ");
                    Console.WriteLine(" 6. Quitter ");
                    Console.Write(" Choisissez une option (1-6) : ");

                    //On récupère et valide le choix de l'utilisateur
                    if (int.TryParse(Console.ReadLine(), out int choix))
                    {
                        if (choix >= 1 && choix <= 6)
                        {
                            return choix;
                        }
                    }
                    
                    Console.WriteLine("Option invalide. Veuillez réessayer. \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur est survenue : {ex.Message}");
                    Console.WriteLine("Veuillez réessayer.");
                }
            }
        }
        #endregion
    
        /// <summary>
        /// Permet d'ajouter un nouveau livre à la bibliothèque
        /// </summary>
        /// <param name="id">L'identifiant unique du livre</param>
        /// <returns>Un nouvel objet Livre avec les informations saisies par l'utilisateur</returns>
        #region Fonction_Ajout
        public static Livre Ajout_livre(int id)
        {
            try
            {
                string titre;
                string auteur;
                double prix;
                int quantite;

                // Validation du titre
                do {
                    Console.WriteLine("Entrez le titre du livre : ");
                    titre = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(titre))
                    {
                        Console.WriteLine("Le titre ne peut pas être vide. Veuillez réessayer.");
                    }
                } while (string.IsNullOrEmpty(titre));

                // Validation de l'auteur
                do {
                    Console.WriteLine("Entrez l'auteur du livre : ");
                    auteur = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(auteur))
                    {
                        Console.WriteLine("L'auteur ne peut pas être vide. Veuillez réessayer.");
                    }
                } while (string.IsNullOrEmpty(auteur));

                // Validation du prix
                do {
                    Console.WriteLine("Entrez le prix du livre : ");
                    if (!double.TryParse(Console.ReadLine(), out prix) || prix < 0)
                    {
                        Console.WriteLine("Prix invalide. Veuillez entrer un nombre positif.");
                        prix = -1;
                    }
                } while (prix < 0);

                // Validation de la quantité
                do {
                    Console.WriteLine("Entrez la quantité disponible : ");
                    if (!int.TryParse(Console.ReadLine(), out quantite) || quantite < 0)
                    {
                        Console.WriteLine("Quantité invalide. Veuillez entrer un nombre entier positif.");
                        quantite = -1;
                    }
                } while (quantite < 0);

                return new Livre(id, titre, auteur, prix, quantite);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'ajout du livre : {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Affiche la liste de tous les livres disponibles dans la bibliothèque
        /// </summary>
        /// <param name="livres">La liste des livres à afficher</param>
        #region Afficher_livre
        public static void Afficher(List<Livre> livres)
        {
            try
            {
                Console.WriteLine("Livres disponibles : ");
                //On verifie si notre base est vide ou pas
                if (livres == null || livres.Count == 0)
                {
                    Console.WriteLine("Nous n'avons aucun livre presentement.");
                    return;
                }
                
                //Boucle qui affiche a l'utilisateur tous les livres
                for (int i = 0; i < livres.Count; i++)
                {
                    Console.WriteLine($"{i+1}. Titre : {livres[i].Titre}, Auteur : {livres[i].Auteur}, Prix : ${livres[i].Prix}, Quantité : {livres[i].Quantite}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de l'affichage des livres : {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Gère le processus de vente d'un livre
        /// </summary>
        /// <param name="livres">La liste des livres disponibles</param>
        /// <returns>Le livre vendu ou null si la vente n'a pas pu être effectuée</returns>
        #region Vendre_livre
        public static Livre Vendre(List<Livre> livres)
        {
            try
            {
                // Vérification initiale de la liste
                if (livres == null || livres.Count == 0)
                {
                    Console.WriteLine("Aucun livre disponible à la vente.");
                    return null;
                }

                // Afficher les livres disponibles
                //Afficher(livres);
                Console.WriteLine("\nEntrez le numéro du livre à vendre : ");
                
                if (!int.TryParse(Console.ReadLine(), out int choix))
                {
                    Console.WriteLine("Numéro de livre invalide.");
                    return null;
                }

                // Ajuster l'index pour correspondre à l'ID du livre
                Livre livre = livres.FirstOrDefault(l => l.Id == choix);
                
                if (livre == null)
                {
                    Console.WriteLine("Livre non trouvé.");
                    return null;
                }

                if (livre.Quantite <= 0)
                {
                    Console.WriteLine("Désolé, ce livre n'est plus en stock.");
                    return null;
                }

                // Procéder à la vente
                Facture(livre);
                livre.Quantite--;
                //Console.WriteLine("Vente effectuée avec succès!");
                return livre;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la vente du livre : {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Gère le processus de prêt d'un livre
        /// </summary>
        /// <param name="livres">La liste des livres disponibles</param>
        /// <returns>Le livre prêté ou null si le prêt n'a pas pu être effectué</returns>
        #region Preter_livre
        public static Livre Preter(List<Livre> livres)
        {
            try
            {
                // Vérification initiale de la liste
                if (livres == null || livres.Count == 0)
                {
                    Console.WriteLine("Aucun livre disponible pour le prêt.");
                    return null;
                }

                // Afficher les livres disponibles
                //Afficher(livres);
                Console.WriteLine("\nEntrez le numéro du livre à prêter  : ");
                
                if (!int.TryParse(Console.ReadLine(), out int choix))
                {
                    Console.WriteLine("Numéro de livre invalide.");
                    return null;
                }

                // Ajuster l'index pour correspondre à l'ID du livre
                Livre livre = livres.FirstOrDefault(l => l.Id == choix);
                
                if (livre == null)
                {
                    Console.WriteLine("Livre non trouvé.");
                    return null;
                }

                if (livre.Quantite <= 0)
                {
                    Console.WriteLine("Désolé, ce livre n'est plus en stock.");
                    return null;
                }

                // Procéder au prét
                Console.WriteLine($"\nLivre prêté : {livre.Titre}");
                livre.Quantite--;
                //Console.WriteLine("Vente effectuée avec succès!");
                return livre;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors du Prêt du livre : {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Gère le processus de retour d'un livre
        /// </summary>
        /// <param name="livres">La liste des livres disponibles</param>
        /// <returns>Le livre retourné ou null si le retour n'a pas pu être effectué</returns>
        #region Retourner_livre
        public static Livre Retourner(List<Livre> livres)
        {
            try
            {
                // Vérification initiale de la liste
                if (livres == null || livres.Count == 0)
                {
                    Console.WriteLine("Aucun livre enregistré.");
                    return null;
                }

                // Afficher les livres disponibles
                //Afficher(livres);
                Console.WriteLine("\nEntrez le numéro du livre à retourner  : ");
                
                if (!int.TryParse(Console.ReadLine(), out int choix))
                {
                    Console.WriteLine("Numéro de livre invalide.");
                    return null;
                }

                // Ajuster l'index pour correspondre à l'ID du livre
                Livre livre = livres.FirstOrDefault(l => l.Id == choix);
                
                if (livre == null)
                {
                    Console.WriteLine("Livre non trouvé.");
                    return null;
                }


                // Procéder au Retour 
                Console.WriteLine($"\nLivre retourné : {livre.Titre}");
                livre.Quantite++;
                //Console.WriteLine("Vente effectuée avec succès!");
                return livre;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors du Prêt du livre : {ex.Message}");
            }
        }
        #endregion

        /// <summary>
        /// Gère la sortie propre du programme
        /// </summary>
        /// <returns>false pour indiquer la fin du programme</returns>
        #region Option_quitter
        public static bool Quitter()
        {
            Console.WriteLine("Programme terminer.\n");
            return false;
        }
        #endregion

        /// <summary>
        /// Génère et affiche une facture pour la vente d'un livre
        /// </summary>
        /// <param name="livre">Le livre pour lequel générer la facture</param>
        #region sous_fonction
        private static void Facture(Livre livre)
        {
            try
            {
                double taxe_du_montant = (livre.Prix * 13/100);
                Console.WriteLine("\u001b[1m --- Facture --- \u001b[0m");
                Console.WriteLine($" Livre : {livre.Titre} ");
                Console.WriteLine($" Prix hors taxe : ${livre.Prix:F2} ");
                Console.WriteLine($" Taxe(13%) : ${taxe_du_montant:F2} ");
                Console.WriteLine($" Total aprés taxe : ${(livre.Prix + taxe_du_montant):F2} \n\n");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la génération de la facture : {ex.Message}");
            }
        }
        #endregion
    }
}