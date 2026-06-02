MediaTek86 – Application de gestion du personnel

Présentation

MediaTek86 est une application développée en C# avec Windows Forms permettant à un responsable de gérer le personnel et les absences d'une médiathèque.

L'application permet de :

- se connecter avec un compte responsable ;
- afficher la liste du personnel ;
- ajouter, modifier et supprimer un personnel ;
- consulter les absences d'un personnel ;
- ajouter, modifier et supprimer une absence.

Technologies utilisées

Visual Studio 2022
C#
Windows Forms
MySQL
WampServer
phpMyAdmin
GitHub

Architecture

L'application respecte le modèle MVC.

Organisation du projet :

text
MediaTek86
├── bddmanager
├── controleur
├── dal
├── modele
└── vue


Base de données

La base de données utilisée est `mediatek86`.

Elle contient les tables suivantes :

responsable
personnel
service
absence
motif

Le script complet de création de la base de données est disponible dans le dépôt sous le nom :


mediatek86.sql


Fonctionnalités

Connexion

Le responsable doit saisir un login et un mot de passe.
Le mot de passe est vérifié avec un hash SHA2 en base de données.

Gestion du personnel

L'application permet d'ajouter, modifier et supprimer un personnel.

Champs disponibles :

nom
prénom
téléphone
mail
service

Gestion des absences

Pour chaque personnel, l'application permet de gérer ses absences.

Champs disponibles :

date de début
date de fin
motif

Captures d'écran

MCD

<img width="545" height="487" alt="image" src="https://github.com/user-attachments/assets/70d05b32-71f1-4375-b0bf-3ee28062b4b9" />


Fenêtre de connexion

<img width="282" height="303" alt="image" src="https://github.com/user-attachments/assets/0b42c1ee-71b9-4bd4-8235-a4d37b247849" />


Gestion du personnel

<img width="602" height="298" alt="image" src="https://github.com/user-attachments/assets/b7221ce7-6a19-4b37-84e4-f5b97a5ae78d" />


Gestion des absences

<img width="402" height="266" alt="image" src="https://github.com/user-attachments/assets/7e2bd1ca-f4fc-4769-ae36-6ca3cfb6ea63" />


Diagramme de paquetages

<img width="922" height="613" alt="image" src="https://github.com/user-attachments/assets/ece1dd1a-63bf-4280-a5f8-072fa0e342e7" />


Installation

1. Installer WampServer.
2. Importer le fichier `mediatek86.sql` dans MySQL.
3. Vérifier que l'utilisateur `gestionnaire` existe.
4. Installer l'application avec l'installateur fourni.
5. Lancer l'application.

## Identifiants de test

Login :


admin


Mot de passe :

admin123

Historique des commits

Création du projet Visual Studio
Création de la structure MVC
Création des interfaces graphiques
Ajout des classes métier
Ajout de la couche DAL
Ajout du contrôleur
Connexion à la base de données
Ajout du CRUD personnel
Ajout du CRUD absences
Génération de la documentation technique
Préparation du déploiement

<img width="922" height="613" alt="Capture d’écran 2026-06-02 140743" src="https://github.com/user-attachments/assets/bdfe085a-48e8-44f0-8e3a-74d0a54e7746" />
Auteur

Projet réalisé dans le cadre du BTS SIO SLAM.
