using System;
using System.Collections.Generic;

namespace RelationsEnClasses
{
    // Classe Auteur
    public class Auteur
    {
        private string nom;
        private string prenom;

        public Auteur(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public string GetNom()
        {
            return nom;
        }

        public string GetPrenom()
        {
            return prenom;
        }
    }

    // Classe Livre
    public class Livre
    {
        private string titre;
        private Auteur auteur;

        public Livre(string titre, Auteur auteur)
        {
            this.titre = titre;
            this.auteur = auteur;
        }

        public string GetTitre()
        {
            return titre;
        }

        public Auteur GetAuteur()
        {
            return auteur;
        }
    }

    // Classe abstraite Utilisateur
    public abstract class Utilisateur
    {
        private string nom;
        private string prenom;

        protected Utilisateur(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public string GetNom()
        {
            return nom;
        }

        public string GetPrenom()
        {
            return prenom;
        }

        public abstract void AfficherInfos();
    }

    // Classe Lecteur qui hérite de Utilisateur
    public class Lecteur : Utilisateur
    {
        public Lecteur(string nom, string prenom) : base(nom, prenom) { }

        public override void AfficherInfos()
        {
            Console.WriteLine($"Lecteur : {GetNom()} {GetPrenom()}");
        }
    }

    // Classe Bibliotheque (Composition avec Livre et Agrégation avec Utilisateur)
    public class Bibliotheque
    {
        private string nom;
        private List<Livre> livres = new List<Livre>(); // Composition avec Livre
        private List<Utilisateur> utilisateurs = new List<Utilisateur>(); // Agrégation avec Utilisateur

        public Bibliotheque(string nom)
        {
            this.nom = nom;
        }

        public string GetNom()
        {
            return nom;
        }

        public void AjouterLivre(Livre livre)
        {
            livres.Add(livre);
        }

        public void InscrireUtilisateur(Utilisateur utilisateur)
        {
            utilisateurs.Add(utilisateur);
        }

        public void AfficherCatalogue()
        {
            Console.WriteLine($"Catalogue de la bibliothèque {nom}:");
            foreach (var livre in livres)
            {
                Console.WriteLine($"- {livre.GetTitre()} par {livre.GetAuteur().GetPrenom()} {livre.GetAuteur().GetNom()}");
            }
        }
    }

    // Programme principal
    class Program
    {
        static void Main(string[] args)
        {
            // Création des auteurs
            Auteur auteur1 = new Auteur("Hugo", "Victor");
            Auteur auteur2 = new Auteur("Verne", "Jules");

            // Création des livres (association avec Auteur)
            Livre livre1 = new Livre("Les Misérables", auteur1);
            Livre livre2 = new Livre("Vingt mille lieues sous les mers", auteur2);

            // Création de la bibliothèque (composition avec Livre et agrégation avec Utilisateur)
            Bibliotheque bibliotheque = new Bibliotheque("Bibliothèque Municipale");

            // Ajout des livres à la bibliothèque
            bibliotheque.AjouterLivre(livre1);
            bibliotheque.AjouterLivre(livre2);

            // Création et inscription d'un lecteur
            Lecteur lecteur = new Lecteur("Dupont", "Jean");
            bibliotheque.InscrireUtilisateur(lecteur);

            // Affichage des informations
            bibliotheque.AfficherCatalogue();
            lecteur.AfficherInfos();
        }
    }
}
