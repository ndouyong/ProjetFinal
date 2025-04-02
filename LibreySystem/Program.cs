/// <summary>
/// Point d'entrée principal de l'application de gestion de bibliothèque
/// Ce programme gère l'authentification des employés et le flux principal de l'application
/// </summary>
using ProjetFinal;

// Initialisation de la liste des employés avec leurs codes d'accès
List<Employer> employers = Execution.Debut();

// Message de bienvenue pour l'utilisateur
Console.WriteLine("\nBienvenue dans notre système de bibliothèque.\n");

// Boucle d'authentification jusqu'à ce qu'un employé valide soit trouvé
Employer employer;
do
{
    employer = Execution.Employer_Check(employers);
} while (employer == null);

// Affichage du message de bienvenue personnalisé
Console.WriteLine($"Bienvenue {employer.Nom}");

// Lancement du menu principal et des fonctionnalités de l'application
Execution.Execu(employer);



