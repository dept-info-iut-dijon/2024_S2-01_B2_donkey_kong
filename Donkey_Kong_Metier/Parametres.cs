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
            }
        }

        public static Parametres Charger()
        {
            Parametres p = new Parametres();

            if (File.Exists(fichierSauvegarde))
            {
                string[] lignes = File.ReadAllLines(fichierSauvegarde);

                if (lignes.Length >= 2)
                {
                    string[] partieLangue = lignes[0].Split('=');
                    if (partieLangue.Length == 2)
                    {
                        string valeurLangue = partieLangue[1];
                        if (valeurLangue == "Français")
                        {
                            p.langue = Langues.Français;
                        }
                        else if (valeurLangue == "Anglais")
                        {
                            p.langue = Langues.Anglais;
                        }
                    }
                    string[] partieVolume = lignes[1].Split('=');
                    if (partieVolume.Length == 2)
                    {
                        string valeurVolume = partieVolume[1];
                        p.volume = Convert.ToDouble(valeurVolume);
                    }
                }
            }
            return p;
        }
        #endregion
    }
}
