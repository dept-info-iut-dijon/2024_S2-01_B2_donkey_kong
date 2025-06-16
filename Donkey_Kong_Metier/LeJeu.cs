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
        #region Attributs

        /// <summary>
        /// Correspond à la langue du jeu
        /// </summary>
        private Langues langue;
        #endregion

        #region Propriétés

        /// <summary>
        /// Paramètres du jeu
        /// </summary>
        public Parametres Parametres { get; set; }

        /// <summary>
        /// Renvoie la langue du jeu
        /// </summary>
        public Langues Langue
        {
            get { return langue; }
            set { langue = value; }
        }

        /// <summary>
        /// Volume sonore du jeu
        /// </summary>
        public double Volume
        {
            get { return Parametres.Volume; }
            set 
            { 
                Parametres.Volume = value; 
                this.BackgroundVolume = value;
            }
        }


        /// <summary>
        /// Propriété pour obtenir le jeu
        /// </summary>
        public LeJeu Jeu => this;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur du jeu qui prend un écran, le fichier des images, fichier des sons, et la langue si autre que française et fps si modification
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="spritesFolder"></param>
        /// <param name="soundsFolder"></param>
        /// <param name="langue"></param>
        /// <param name="fps"></param>
        public LeJeu(IScreen screen, string spritesFolder, string soundsFolder, Langues langue = Langues.Français, int fps = 50) : base(screen, spritesFolder, soundsFolder, fps)
        {
            Parametres = Parametres.Charger();
            if (langue != Langues.Français)
            {
                this.Parametres.Langue = langue;
            }
            this.langue = this.Parametres.Langue;
            Parametres fichier  = new Parametres();
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
            BackgroundVolume = Parametres.Volume;
            //AddItem(new DonkeyKong(this));
        }


        #endregion

        #region Méthodes

        /// <summary>
        /// Méthode exécutée quand le joueur gagne
        /// </summary>
        protected override void RunWhenWin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode exécutée quand le joueur perd
        /// </summary>
        protected override void RunWhenLoose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
