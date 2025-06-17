using Donkey_Kong_Metier.Items;
using DonkeyKongMetier;
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
            get { return Parametres.Langue; }
            set { Parametres.Langue = value; }
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
        }

        /// <summary>
        /// Initiation des items du jeu
        /// </summary>
        protected override void InitItems()
        {
            List<Plateforme> plateformes = new List<Plateforme>();

            double baseY = this.Screen.Height + 520; 
            double baseX = this.Screen.Width + 520;

            double y = baseY;
            for (int i = 0; i < 8; i++)
            {
                Plateforme pSol = new Plateforme(baseX - 470 + (i * 100), y, this);
                plateformes.Add(pSol);
                AddItem(pSol);
            }

            y -= 80; 
            for (int i = 0; i < 7; i++)
            {
                Plateforme p1 = new Plateforme(baseX - 420 + (i * 80), y, this);
                plateformes.Add(p1);
                AddItem(p1);
            }

            y -= 80; 
            for (int i = 0; i < 6; i++)
            {
                Plateforme p2 = new Plateforme(baseX - 380 + (i * 80), y, this);
                plateformes.Add(p2);
                AddItem(p2);
            }

            y -= 80;
            for (int i = 0; i < 7; i++)
            {
                Plateforme p3 = new Plateforme(baseX - 420 + (i * 70), y, this);
                plateformes.Add(p3);
                AddItem(p3);
            }

            y -= 80; 
            for (int i = 0; i < 6; i++)
            {
                Plateforme p4 = new Plateforme(baseX - 350 + (i * 70), y, this);
                plateformes.Add(p4);
                AddItem(p4);
            }

            y -= 80;
            for (int i = 0; i < 7; i++)
            {
                Plateforme pSommet = new Plateforme(baseX - 420 + (i * 80), y, this);
                plateformes.Add(pSommet);
                AddItem(pSommet);
            }

            DonkeyKong donkeyKong = new DonkeyKong(baseX - 400, y - 40, this); 
            AddItem(donkeyKong);

            Princesse princesse = new Princesse(baseX - 100, y - 40, this);
            AddItem(princesse);

            for (int i = 0; i < 3; i++)
            {
                Baril baril = new Baril(plateformes, baseX - 360 + (i * 40), y - 15, this);
                AddItem(baril);
            }

            TonneauHuile tonneauHuile = new TonneauHuile(baseX - 450, baseY - 30, this);
            AddItem(tonneauHuile);

            for (int i = 0; i < 2; i++)
            {
                BouleFeu bouleFeu = new BouleFeu(baseX - 430 + (i * 30), baseY - 20, this);
                AddItem(bouleFeu);
            }

            Marteau marteau1 = new Marteau(baseX - 200, baseY - 200 - 30, this);
            AddItem(marteau1);

            Marteau marteau2 = new Marteau(baseX - 300, baseY - 400 - 30, this);
            AddItem(marteau2);

            PlayBackgroundMusic("bacmusic.wav");
            BackgroundVolume = Parametres.Volume;
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
