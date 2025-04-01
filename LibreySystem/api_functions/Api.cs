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


    }
}