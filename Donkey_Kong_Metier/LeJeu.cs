using Donkey_Kong_Metier.Items;
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

        public LeJeu Jeu => this;

        #endregion

        #region Constructeur
        public LeJeu(IScreen screen, string spritesFolder, string soundsFolder, Langues langue = Langues.Français, int fps = 50) : base(screen, spritesFolder, soundsFolder, fps)
        {
        }

        /// <summary>
        /// Initiation des items du jeu
        /// </summary>
        protected override void InitItems()
        {
            List<Plateforme> plateformes = new List<Plateforme>();
            double y = this.Screen.Height + 360;
            double x = this.Screen.Width + 520;


            Plateforme p1 = new Plateforme(x, y, this);
            plateformes.Add(p1);


            y -= 100;
            x += 50;
            Baril j = new Baril(plateformes, x, y, this);
            AddItem(j);
            PlayBackgroundMusic("bacmusic.wav");

            //AddItem(new DonkeyKong(this));
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
