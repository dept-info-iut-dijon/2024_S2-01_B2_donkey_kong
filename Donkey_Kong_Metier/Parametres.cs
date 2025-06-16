using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_Metier
{
    /// <summary>
    /// Classe contenant les paramètres du jeu
    /// </summary>
    public class Parametres
    {
        #region Attributs

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
        /// Fichier dans lequel les paramètres seront sauvegardés 
        /// et depuis lequel on pourra charger des paramètres
        /// </summary>
        private const string fichierSauvegarde = "parametres.txt";

        #endregion

        #region Propriétés

        /// <summary>
        /// Accès à la langue du jeu
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
        /// Accès au volume sonore du jeu
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
        /// Accès à la touche gauche
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
        /// Accès à la touche droite
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
        /// Accès à la touche haut
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
        /// Accès à la touche bas
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
        /// Accès à la touche saut
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


        #endregion

        #region Méthodes
        /// <summary>
        /// Sauvegarde les paramètres dans un fichier texte
        /// </summary>
        public void Sauvegarder()
        {
            using (StreamWriter writer = new StreamWriter(fichierSauvegarde))
            {
                writer.WriteLine($"Langue={Langue}");
                writer.WriteLine($"Volume={Volume}");
                writer.WriteLine($"ToucheGauche={ToucheGauche}");
                writer.WriteLine($"ToucheDroite={ToucheDroite}");
                writer.WriteLine($"ToucheHaut={ToucheHaut}");
                writer.WriteLine($"ToucheBas={ToucheBas}");
                writer.WriteLine($"ToucheSaut={ToucheSaut}");
            }
        }

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
                                if (valeur == "Francais")
                                {
                                    p.langue = Langues.Français;
                                }
                                else if (valeur == "Anglais")
                                {
                                    p.langue = Langues.Anglais;
                                }
                                break;
                            case "Volume":
                                p.Volume = Convert.ToDouble(valeur); ;
                                break;
                            case "ToucheGauche":
                                p.ToucheGauche = valeur;
                                break;
                            case "ToucheDroite":
                                p.ToucheDroite = valeur;
                                break;
                            case "ToucheHaut":
                                p.ToucheHaut = valeur;
                                break;
                            case "ToucheBas":
                                p.ToucheBas = valeur;
                                break;
                            case "ToucheSaut":
                                p.ToucheSaut = valeur;
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
