using System;
using System.Collections.Generic;
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

        #endregion

        #region Propriétés

        /// <summary>
        /// Accès à la langue du jeu
        /// </summary>
        public Langues Langue 
        { 
            get { return langue; }
            set { langue = value; }
        }

        /// <summary>
        /// Accès au volume sonore du jeu
        /// </summary>
        public double Volume
        {
            get { return volume; }
            set { this.volume = value; }
        }

        #endregion
    }
}
