﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Donkey_Kong_Metier
{
    /// <summary>
    /// Classe contenant les paramètres du jeu
    /// </summary>
    public class Parametres
    {
        #region--Attributs--

        /// <summary>
        /// Langues du jeu (Francais par défaut)
        /// </summary>
        private Langues langue = Langues.Français;

        /// <summary>
        /// Volume sonore du jeu (0.5 par défaut)
        /// </summary>
        private double volume = 0.5;

        /// <summary>
        /// Touche pour aller a gauche (Q par défaut)
        /// </summary>
        private string toucheGauche = "Q";

        /// <summary>
        /// Touche pour aller à droite (D par défaut)
        /// </summary>
        private string toucheDroite = "D";

        /// <summary>
        /// Touche pour monter (Z par défaut)
        /// </summary>
        private string toucheHaut = "Z";

        /// <summary>
        /// Touche pour aller en bas (S par défaut)
        /// </summary>
        private string toucheBas = "S";

        /// <summary>
        /// Touche pour sauter (Espace par défaut)
        /// </summary>
        private string toucheSaut = "Espace";

        /// <summary>
        /// meilleur score du jeu
        /// </summary>
        private int meilleurScore = 0;
        
        /// <summary>
        /// Fichier dans lequel les paramètres seront sauvegardés 
        /// et depuis lequel on pourra charger des paramètres
        /// </summary>
        private const string fichierSauvegarde = "parametres.txt";

        #endregion

        #region--Propriétés--

        /// <summary>
        /// Propriété de la langue du jeu
        /// </summary>
        public Langues Langue 
        { 
            get { return langue; }
            set 
            { 
                langue = value;
                Sauvegarder();
            }
        }

        /// <summary>
        /// Propriété du volume sonore du jeu
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set 
            { 
                this.volume = value;
                Sauvegarder();   
            }
        }

        /// <summary>
        /// Propriété de la touche gauche
        /// </summary>
        public string ToucheGauche
        {
            get { return toucheGauche; }
            set
            {
                toucheGauche = value;
                Sauvegarder();
            }
        }

        /// <summary>
        /// Propriété de la touche droite
        /// </summary>
        public string ToucheDroite
        {
            get { return toucheDroite; }
            set
            {
                toucheDroite = value;
                Sauvegarder();
            }
        }

        /// <summary>
        /// Propriété de la touche haut
        /// </summary>
        public string ToucheHaut
        {
            get { return toucheHaut; }
            set
            {
                toucheHaut = value;
                Sauvegarder();
            }
        }

        /// <summary>
        /// Propriété de la touche bas
        /// </summary>
        public string ToucheBas
        {
            get { return toucheBas; }
            set
            {
                toucheBas = value;
                Sauvegarder();
            }
        }

        /// <summary>
        /// Propriété de la touche saut
        /// </summary>
        public string ToucheSaut
        {
            get { return toucheSaut; }
            set
            {
                toucheSaut = value;
                Sauvegarder();
            }
        }
        /// <summary>
        ///  Propriété de meilleur score
        /// </summary>
        public int MeilleurScore
        {
            get { return meilleurScore; }
            private set
            {
                meilleurScore = value;
                Sauvegarder();
            }
        }

        #endregion

        #region--Méthodes--


        /// <summary>
        /// Vérifie si un score est un nouveau record
        /// </summary>
        /// <param name="nouveauScore">Score à vérifier</param>
        /// <returns>True si c'est un nouveau record</returns>
        public bool VerifierNouveauRecord(int nouveauScore)
        {
            if (nouveauScore > meilleurScore)
            {
                MeilleurScore = nouveauScore;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Sauvegarde les paramètres dans un fichier texte et score 
        /// </summary>
        public void Sauvegarder()
        {
              using (StreamWriter writer = new StreamWriter(fichierSauvegarde))
                {
                    writer.WriteLine($"Langue={Langue}");
                    writer.WriteLine($"Volume={Volume.ToString().Replace(',', '.')}");
                    writer.WriteLine($"ToucheGauche={ToucheGauche}");
                    writer.WriteLine($"ToucheDroite={ToucheDroite}");
                    writer.WriteLine($"ToucheHaut={ToucheHaut}");
                    writer.WriteLine($"ToucheBas={ToucheBas}");
                    writer.WriteLine($"ToucheSaut={ToucheSaut}");
                    writer.WriteLine($"MeilleurScore={MeilleurScore}"); 
                }
             
        }

        /// <summary>
        /// Charger le fichier de sauvegarde
        /// </summary>
        /// <returns>Les parametres du jeu</returns>
        public static Parametres Charger()
        {
            Parametres p = new Parametres();

            if (File.Exists(fichierSauvegarde))
            {
                string[] lignes = File.ReadAllLines(fichierSauvegarde);
                foreach (string ligne in lignes) 
                {
                    string[] parties = ligne.Split('=');
                    if (parties.Length == 2)
                    {
                        string cle = parties[0];
                        string valeur = parties[1];

                        switch (cle)
                        {
                            case "Langue":
                                
                                if (valeur == "Français")
                                {
                                    p.langue = Langues.Français;
                                }
                                else if (valeur == "Anglais")
                                {
                                    p.langue = Langues.Anglais;
                                }
       
                                break;
                            case "Volume":
                                p.volume = double.Parse(valeur, System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "ToucheGauche":
                                p.toucheGauche = valeur;
                                break;
                            case "ToucheDroite":
                                p.toucheDroite = valeur;
                                break;
                            case "ToucheHaut":
                                p.toucheHaut = valeur;
                                break;
                            case "ToucheBas":
                                p.toucheBas = valeur;
                                break;
                            case "ToucheSaut":
                                p.toucheSaut = valeur;
                                break;
                            case "MeilleurScore": 
                                if (int.TryParse(valeur, out int score))
                                    p.meilleurScore = score;
                                break;


                        }
                    }
                }
            }
            return p;
        }
        #endregion
    }
}
