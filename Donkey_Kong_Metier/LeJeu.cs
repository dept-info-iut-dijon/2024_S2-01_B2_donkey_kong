using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_Metier
{
    /// <summary>
    /// Classe contenant le jeu
    /// </summary>
    public class LeJeu : Game
    {
        #region Attribut
        /// <summary>
        /// Correspond à la langue du jeu
        /// </summary>
        private Langues langue;
        #endregion

        #region Propiétés
        
        /// <summary>
        /// Renvoie la langue du jeu
        /// </summary>
        public Langues Langue
        {
            get { return langue; }
            set { langue = value; }
        }

        #endregion

        #region Constructeur
        public LeJeu(IScreen screen, string spritesFolder, string soundsFolder, Langues langue = Langues.Français, int fps = 50) : base(screen, spritesFolder, soundsFolder, fps)
        {
        }

        protected override void InitItems()
        {
            throw new NotImplementedException();
        }

        protected override void RunWhenWin()
        {
            throw new NotImplementedException();
        }

        protected override void RunWhenLoose()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Méthodes


        #endregion
    }
}
