# ProjetFinal

# Système de Gestion de Bibliothèque (LibreySystem)

## Description
LibreySystem est une application console en C# qui permet de gérer une bibliothèque de livres. Le système offre des fonctionnalités complètes pour gérer l'inventaire des livres, les ventes, les prêts et les retours, ainsi que la gestion des employés.

## Fonctionnalités
- 📚 Ajout de nouveaux livres
- 📖 Affichage de l'inventaire des livres
- 💰 Vente de livres avec génération de facture
- 📝 Système de prêt de livres
- 🔄 Gestion des retours de livres
- 👥 Gestion des employés
- 💾 Sauvegarde des données

## Prérequis
- .NET SDK (version 6.0 ou supérieure)
- Un éditeur de code (Visual Studio, VS Code, etc.)

## Installation
1. Clonez le dépôt :
```bash
git clone [URL_DU_REPO]
```

2. Naviguez vers le dossier du projet :
```bash
cd LibreySystem
```

3. Compilez le projet :
```bash
dotnet build
```

## Utilisation
1. Lancez l'application :
```bash
dotnet run
```

2. Utilisez le menu principal pour accéder aux différentes fonctionnalités :
   - 1. Ajouter un livre
   - 2. Afficher les livres disponibles
   - 3. Vendre un livre
   - 4. Prêter un livre
   - 5. Retourner un livre
   - 6. Quitter

## Structure du Projet
```
LibreySystem/
├── api_functions/
│   └── Api.cs           # Gestion des interactions utilisateur
├── models/
│   ├── Livre.cs         # Modèle de données pour les livres
│   └── Employer.cs      # Modèle de données pour les employés
├── Execution.cs         # Gestion de l'exécution du programme
└── Program.cs           # Point d'entrée de l'application
```

## Fonctionnalités Détaillées

### Gestion des Livres

#### Ajout de Livres
- Saisie du titre
- Saisie de l'auteur
- Définition du prix
- Gestion de la quantité en stock

#### Vente de Livres
- Sélection du livre par ID
- Vérification de la disponibilité
- Génération automatique de facture avec calcul des taxes (13%)
- Mise à jour automatique du stock

#### Système de Prêt
- Sélection du livre par ID
- Vérification de la disponibilité
- Mise à jour automatique du stock

#### Gestion des Retours
- Sélection du livre par ID
- Mise à jour automatique du stock

### Gestion des Employés
- Gestion des informations personnelles des employés
- Suivi des employés actifs
- Stockage des données des employés

### Système d'Exécution
- Gestion du flux principal du programme
- Coordination entre les différentes fonctionnalités
- Gestion des états du programme

## Gestion des Erreurs
Le système inclut une gestion robuste des erreurs pour :
- Les entrées invalides
- Les livres non trouvés
- Les problèmes de stock
- Les erreurs de saisie
- Les erreurs de gestion des employés
- Les erreurs d'exécution

## Contribution
Les contributions sont les bienvenues ! N'hésitez pas à :
1. Fork le projet
2. Créer une branche pour votre fonctionnalité
3. Commiter vos changements
4. Pousser vers la branche
5. Ouvrir une Pull Request

## Licence
Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus de détails.

## Contact
Pour toute question ou suggestion, n'hésitez pas à ouvrir une issue dans le dépôt GitHub. 