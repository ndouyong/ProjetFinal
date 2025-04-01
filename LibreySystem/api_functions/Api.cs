using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFinal
{
    public class Api
    {
        //Cette fonction a pour but d'afficher le menu, recupere le choix de l'utilisateur et le retourner 
        #region Menu
        public static int Menu()
        {
            while (true)
            {
                try
                {
                    //On affiche le menu
                    Console.WriteLine("");
                    Console.WriteLine(" --- Menu Principal --- ");
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
    
        //Cette fonction a pour but d'ajouter une livre et retourner l'objet livre
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

        //Cette fonction a pour but d'afficher un livre
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

        #region Option_quitter
        //Une fonction simple pour quitter le Programme 
        public static bool Quitter()
        {
            Console.WriteLine("Programme terminer.\n");
            return false;
        }
        #endregion

        #region sous_fonction
        private static void Facture(Livre livre)
        {
            try
            {
                double taxe_du_montant = (livre.Prix * 13/100);
                Console.WriteLine(" --- Facture --- ");
                Console.WriteLine($" Livre : {livre.Titre} ");
                Console.WriteLine($" Prix hors taxe : ${livre.Prix} ");
                Console.WriteLine($" Taxe(13%) : ${taxe_du_montant} ");
                Console.WriteLine($" Total aprés taxe : $({livre.Prix + taxe_du_montant}) \n\n");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur lors de la génération de la facture : {ex.Message}");
            }
        }

        

        #endregion
    }
}