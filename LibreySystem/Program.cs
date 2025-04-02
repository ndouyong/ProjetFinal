//Début du projet pour le système de bibliothèque.
using ProjetFinal;

//Initialisation des Employees 
List<Employer> employers = Execution.Debut();

//Debut de l'execution du projet
Console.WriteLine("\nBienvenue dans notre système de bibliothèque.\n");

//Executon du code final.
Employer employer;
do
{
    employer = Execution.Employer_Check(employers);
} while (employer == null);

Console.WriteLine($"Bienvenue {employer.Nom}");

Execution.Execu(employer);



