using Donkey_Kong_Metier.Items;
using Donkey_Kong_Metier;
using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeyKongMetier;

namespace Donkey_Kong_Metier
{
    /// <summary>
    /// Classe contenant le jeu
    /// </summary>
    public class LeJeu : Game
    {
        #region--Attributs--
        //Le joueur
        private Joueur joueur;
        #endregion
       
        #region--Propriétés--
    
        /// <summary>
        /// Paramètres du jeu
        /// </summary>
        public Parametres Parametres { get; set; }

        /// <summary>
        /// Score du joueur
        /// </summary>
        public Score ScoreJeu { get; set; }

        /// <summary>
        /// Propriété de la langue du jeu
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
        /// Propiété pour le meilleur score
        /// </summary>
        public int MeilleurScore
        {
            get { return Parametres.MeilleurScore; }
        }

        /// <summary>
        /// Propriété pour le joueur
        /// </summary>
        public Joueur Joueur
        {
            get { return joueur; }
        }
        #endregion

        #region--Constructeur--

        /// <summary>
        /// Constructeur du jeu qui prend un écran, le fichier des images, fichier des sons, et la langue si autre que française et fps si modification
        /// </summary>
        /// <param name="screen">L'ecran du jeu</param>
        /// <param name="spritesFolder">La ou sont les sprites</param>
        /// <param name="soundsFolder">La ou sont les sons</param>
        /// <param name="langue">langue du jeu</param>
        /// <param name="fps">fps du jeu</param>
        public LeJeu(IScreen screen, string spritesFolder, string soundsFolder, Langues langue = Langues.Français, int fps = 50) : base(screen, spritesFolder, soundsFolder, fps)
        {
            Parametres = Parametres.Charger();
        
        }
        #endregion

        #region--Méthodes--
        /// <summary>
        /// Initiation des items du jeu
        /// </summary>
        protected override void InitItems()
        {
            List<Plateforme> plateformes = new List<Plateforme>();

            double baseY = this.Screen.Height + 520;
            double baseX = this.Screen.Width + 520;

            double y = baseY;

            // Création des plateformes (inchangé)
            for (int i = 0; i < 9; i++)
            {
                Plateforme pSol = new Plateforme(baseX - 570 + (i * 100), y, this);
                plateformes.Add(pSol);
                AddItem(pSol);
            }

            y -= 80;
            for (int i = 0; i < 8; i++)
            {
                Plateforme p1 = new Plateforme(baseX - 570 + (i * 100), y, this);
                plateformes.Add(p1);
                AddItem(p1);
            }

            y -= 80;
            for (int i = 0; i < 8; i++)
            {
                Plateforme p2 = new Plateforme(baseX - 470 + (i * 100), y, this);
                plateformes.Add(p2);
                AddItem(p2);
            }

            y -= 80;
            for (int i = 0; i < 8; i++)
            {
                Plateforme p3 = new Plateforme(baseX - 570 + (i * 100), y, this);
                plateformes.Add(p3);
                AddItem(p3);
            }

            y -= 80;
            for (int i = 0; i < 8; i++)
            {
                Plateforme p4 = new Plateforme(baseX - 470 + (i * 100), y, this);
                plateformes.Add(p4);
                AddItem(p4);
            }

            y -= 80;
            for (int i = 0; i < 8; i++)
            {
                Plateforme pSommet = new Plateforme(baseX - 570 + (i * 100), y, this);
                plateformes.Add(pSommet);
                AddItem(pSommet);
            }

            Princesse princesse = new Princesse(baseX - 50, y - 20, this);
            AddItem(princesse);


            TonneauHuile tonneauHuile = new TonneauHuile(baseX - 450, baseY - 22, this);
            AddItem(tonneauHuile);

            Marteau marteau1 = new Marteau(baseX - 200, baseY - 40, this);
            AddItem(marteau1);

            Marteau marteau2 = new Marteau(baseX - 300, baseY - 120, this);
            AddItem(marteau2);

            Marteau marteau3 = new Marteau(baseX - 150, baseY - 280, this);
            AddItem(marteau3);

            List<Echelle> echelles = new List<Echelle>();
            List<Echelle> echellesCassees = new List<Echelle>();

            void CreerEchelle(double x, double yBas, double yHaut, bool estComplete = true)
            {
                double distance = yBas - yHaut;
                int nbSegments = (int)Math.Round(distance / 12);

                double startY = yBas - 10;

                for (int j = 0; j < nbSegments; j++)
                {
                    if (!estComplete && (j >= 2 && j <= 4))
                    {
                        continue;
                    }

                    Echelle echelle = new Echelle(x, startY - (j * 12), this);

                    if (estComplete)
                    {
                        echelles.Add(echelle);
                    }
                    else
                    {
                        echellesCassees.Add(echelle);
                    }

                    AddItem(echelle);
                }
            }


            CreerEchelle(baseX - 350, baseY, baseY - 80, true);
            CreerEchelle(baseX - 150, baseY, baseY - 80, false);
            CreerEchelle(baseX + 50, baseY, baseY - 80, false);

            CreerEchelle(baseX - 200, baseY - 80, baseY - 160, true);
            CreerEchelle(baseX - 70, baseY - 80, baseY - 160, false);

            CreerEchelle(baseX - 400, baseY - 160, baseY - 240, true);
            CreerEchelle(baseX - 250, baseY - 160, baseY - 240, false);
            CreerEchelle(baseX - 100, baseY - 160, baseY - 240, false);
            CreerEchelle(baseX + 50, baseY - 160, baseY - 240, false);

            CreerEchelle(baseX - 350, baseY - 240, baseY - 320, true);
            CreerEchelle(baseX - 150, baseY - 240, baseY - 320, false);

            CreerEchelle(baseX - 300, baseY - 320, baseY - 400, true);
            CreerEchelle(baseX - 100, baseY - 320, baseY - 400, false);
            CreerEchelle(baseX + 100, baseY - 320, baseY - 400, false);

            if (joueur == null)
            {
                joueur = new Joueur(baseX - 500, baseY - 30, this, plateformes, echelles, 2);
                AddItem(joueur);
            }

            for (int i = 0; i < 3; i++)
            {
                Baril baril = new Baril(plateformes, echelles, baseX - 360 + (i * 40), y - 15, this);
                AddItem(baril);
            }

            DonkeyKong donkeyKong = new DonkeyKong(plateformes, echelles, baseX - 400, y - 30, this);
            AddItem(donkeyKong);

            PlayBackgroundMusic("bacmusic.wav");
            BackgroundVolume = Parametres.Volume;
        }

        /// <summary>
        /// Méthode exécutée quand le joueur gagne
        /// </summary>
        protected override void RunWhenWin()
        {
            if (joueur != null)
            {
                // Bonus de victoire
                joueur.AjouterPoints(1000);
                // Vérifier si c'est un nouveau record
                bool nouveauRecord = Parametres.VerifierNouveauRecord(joueur.ScoreActuel);
            }
        }

        /// <summary>
        /// Méthode exécutée quand le joueur perd
        /// </summary>
        protected override void RunWhenLoose()
        {
            if (joueur != null)
            {
                // Vérifier si c'est un nouveau record même en cas de défaite
                bool nouveauRecord = Parametres.VerifierNouveauRecord(joueur.ScoreActuel);
                if(joueur.NbVie>1)
                    this.InitItems();
            }
        }

        #endregion
    }
}
