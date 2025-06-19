using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;
using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DonkeyKongMetier
{
    /// <summary>
    /// Classe représentant le joueur
    /// </summary>
    public class Joueur : GameItem, IAnimable, IKeyboardInteract
    {
        #region Attributs
        // Constantes pour le mouvement
        private const double VitesseDeplacement = 3.0;
        private const double VitesseSaut = -8.0; // Vitesse initiale du saut (négatif = vers le haut)
        private const double Gravite = 0.3; // Force de gravité
        private const double VitesseMaxChute = 10.0; // Vitesse maximale de chute

        // État du mouvement
        private bool mouvementGauche = false;
        private bool mouvementDroite = false;
        private bool mouvementHaut = false;
        private bool mouvementBas = false;

        // Propriété physique
        private double vitesseVertical = 0;
        private bool enSaut = false;
        private bool auSol = false;
        private bool surEchelle = false;
        private bool peutMonterEchelle = false;
        private bool peutDescendreEchelle = false;

        // Attributs du jeu
        private int nbVie = 3;
        //score du joueur
        private Score monScore;

        private Game game;
        //determine si le joueur peut grimper
        private bool peutGrimper = false;
        //determine si le joeuur a un marteau
        private bool aMarteau = false;
        private double tempsMarteau = 0;

        // Référence vers les paramètres pour les touches
        private Donkey_Kong_Metier.Parametres parametres;

        // Références aux plateformes et échelles pour les collisions
        private List<Plateforme> plateformes;
        private List<Echelle> echelles;

        #endregion

        #region Propriétés
        public bool AMarteau
        {
            get { return aMarteau; }
        }

        public int Score
        {
            get
            {
                if (monScore != null)
                {
                    return monScore.ScoreActuel;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int NbVie
        {
            get { return nbVie; }
        }

        public override string TypeName => "Joueur";

        public double TempsMarteau
        { 
            get { return tempsMarteau; }
        }
        public Score MonScore
        {
            get { return monScore; }
        }
        public int ScoreActuel
        {
            get { return monScore.ScoreActuel; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du joueur
        /// </summary>
        /// <param name="x">Coordonnées x du joueur</param>
        /// <param name="y">Coordonnées y du joueur</param>
        /// <param name="game">Le jeu en cours</param>
        /// <param name="parametres">Les paramètres du jeu pour les touches</param>
        /// <param name="plateformes">Liste des plateformes du niveau</param>
        /// <param name="echelles">Liste des échelles du niveau</param>
        /// <param name="zindex">Priorité d'affichage du sprite</param>
        public Joueur(double x, double y, Game game, List<Plateforme> plateformes, List<Echelle> echelles, int zindex = 1)
            : base(x, y, game, "mario_debout_droite.png", zindex)
        {
            this.game = game;
            this.plateformes = plateformes;
            this.echelles = echelles;
            Collidable = true;
            monScore = new Score();
        }
        #endregion

        #region --Méthodes--

        /// <summary>
        /// Animation du joueur
        /// </summary>
        /// <param name="dt">Temps écoulé depuis la dernière frame</param>
        public void AjouterPoints(int points)
        {
            if (monScore == null)
            {
                Console.WriteLine("ERREUR : monScore est null, initialisation...");
                monScore = new Score();
            }

            Console.WriteLine($"Ajout de {points} points. Score avant: {monScore.ScoreActuel}");
            monScore.AjouterPoints(points);
            Console.WriteLine($"Score après: {monScore.ScoreActuel}");
        }


        public void Animate(TimeSpan dt)
        {
            // Vérification des collisions avec les plateformes et échelles
            VerifierCollisions();

            // Gestion du mouvement horizontal
            if (mouvementGauche && !mouvementDroite)
            {
                MoveXY(-VitesseDeplacement, 0);
                if (!enSaut && !surEchelle)
                {
                    if (aMarteau)
                        ChangeSprite("mario_marteau_gauche.png.png");
                    else
                        ChangeSprite("mario_debout_gauche.png");
                }
            }
            else if (mouvementDroite && !mouvementGauche)
            {
                MoveXY(VitesseDeplacement, 0);
                if (!enSaut && !surEchelle)
                {
                    if (aMarteau)
                        ChangeSprite("mario_marteau_droite.png");
                    else
                        ChangeSprite("mario_debout_droite.png");
                }
            }
            else if (!enSaut && !surEchelle && !mouvementGauche && !mouvementDroite)
            {
                // Sprite statique quand on ne bouge pas
                if (aMarteau)
                    ChangeSprite("mario_debout_marteau_droite.png");
                else
                    ChangeSprite("mario_debout_droite.png");
            }

            // Gestion du mouvement sur échelle
            if (surEchelle)
            {
                vitesseVertical = 0; // Pas de gravité sur l'échelle
                enSaut = false;

                if (mouvementHaut && peutMonterEchelle)
                {
                    MoveXY(0, -VitesseDeplacement);
                    ChangeSprite("mario_dos.png");
                }
                else if (mouvementBas && peutDescendreEchelle)
                {
                    MoveXY(0, VitesseDeplacement);
                    ChangeSprite("mario_dos2.png");
                }
            }
            else
            {
                // Application de la gravité si pas sur une échelle
                if (!auSol)
                {
                    vitesseVertical += Gravite;
                    if (vitesseVertical > VitesseMaxChute)
                        vitesseVertical = VitesseMaxChute;
                }
                if (auSol && vitesseVertical > 0)
                {
                    vitesseVertical = 0;
                    enSaut = false;
                }

                // Application du mouvement vertical
                MoveXY(0, vitesseVertical);
            }

            // Gestion du sprite de saut
            if (enSaut && !surEchelle)
            {
                    if (mouvementDroite || (!mouvementGauche && !mouvementDroite))
                        ChangeSprite("mario_saut_droite.png");
                    else
                        ChangeSprite("mario_saut_gauche.png");
            }

            // Gestion du temps de marteau
            if (aMarteau)
            {
                tempsMarteau += dt.TotalSeconds;
                if (tempsMarteau >= 10.0) // Le marteau dure 10 secondes
                {
                    aMarteau = false;
                    tempsMarteau = 0;

                    if (enSaut && !surEchelle)
                    {
                        if (mouvementDroite || (!mouvementGauche && !mouvementDroite))
                        {
                            ChangeSprite("mario_marteau_droite.png");
                        }
                        else
                        {
                            ChangeSprite("mario_marteau_gauche.png");
                        }
                    }
                    else if (mouvementGauche && !mouvementDroite)
                    {
                        ChangeSprite("mario_marteau_gauche.png");
                    }
                    else if (mouvementDroite && !mouvementGauche)
                    {
                        ChangeSprite("mario_marteau_droite.png");
                    }
                    else
                    {
                        ChangeSprite("mario_marteau_droite.png");
                    }
                    
                }
            }

            // Vérification des limites de l'écran
            if (Left < 0) PutXY(0, Top);
            if (Top < 0) PutXY(Left, 0);
            if (Right > GameWidth) PutXY(GameWidth - Width, Top);
            if (Bottom > GameHeight) PutXY(Left, GameHeight - Height);
        }

        /// <summary>
        /// Vérifie les collisions avec plateformes et échelles
        /// </summary>
        private void VerifierCollisions()
        {
            // Vérification si on est au sol
            auSol = false;
            foreach (var plateforme in plateformes)
            {
                // On considère qu'on est au sol si on est juste au-dessus d'une plateforme
                if (Bottom >= plateforme.Top - 5 && Bottom <= plateforme.Top + 5 &&
                    Right > plateforme.Left && Left < plateforme.Right)
                {
                    auSol = true;
                    // Ajuster la position pour être exactement sur la plateforme
                    if (vitesseVertical > 0) // Si on tombe
                    {
                        PutXY(Left, plateforme.Top - Height);
                    }
                    break;
                }
            }

            // Vérification si on est sur/près d'une échelle
            surEchelle = false;
            peutMonterEchelle = false;
            peutDescendreEchelle = false;

            foreach (var echelle in echelles)
            {
                // Vérifier si le joueur est aligné avec l'échelle (horizontalement)
                if (Left < echelle.Right - 10 && Right > echelle.Left + 10)
                {
                    // Vérifier si on peut monter
                    if (Bottom > echelle.Top && Top < echelle.Bottom)
                    {
                        peutMonterEchelle = true;
                        peutDescendreEchelle = true;

                        // Si on appuie sur haut ou bas, on s'accroche à l'échelle
                        if (mouvementHaut || mouvementBas)
                        {
                            surEchelle = true;
                            // Centrer le joueur sur l'échelle
                            PutXY(echelle.Left + (echelle.Width - Width) / 2, Top);
                        }
                    }
                }
            }
        }
        #endregion

        #region Gestion du clavier
        /// <summary>
        /// Gestion de l'appui sur une touche
        /// </summary>
        /// <param name="key">Touche pressée</param>
        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Q:
                    mouvementGauche = true;
                    break;
                case Key.D:
                    mouvementDroite = true;
                    break;
                case Key.Z:
                    mouvementHaut = true;
                    break;
                case Key.S:
                    mouvementBas = true;
                    break;
                case Key.Space:
                    // Saut uniquement si au sol et pas sur échelle
                    if (auSol && !surEchelle && !enSaut)
                    {
                        vitesseVertical = VitesseSaut;
                        enSaut = true;
                        this.PlaySound("jump.wav");
                    }
                    break;
            }
        }

        /// <summary>
        /// Gestion du relâchement d'une touche
        /// </summary>
        /// <param name="key">Touche relâchée</param>
        public void KeyUp(Key key)
        {
            switch (key)
            {
                case Key.Q:
                    mouvementGauche = false;
                    break;
                case Key.D:
                    mouvementDroite = false;
                    break;
                case Key.Z:
                    mouvementHaut = false;
                    break;
                case Key.S:
                    mouvementBas = false;
                    break;
            }

        }
        #endregion

        #region Collision
            /// <summary>
            /// Collision avec les autres objets
            /// </summary>
            /// <param name="other">Objet avec lequel il y a collision</param>
        public override void CollideEffect(GameItem other)
        {
            if (!other.Collidable)
            {
                
                return;
            }


            if (other.TypeName == "baril" || other.TypeName == "boule_feu" || other.TypeName == "DonkeyKong")
            {
                if (aMarteau == false)
                {
                    nbVie -= 1;
                    if (nbVie < 1)
                    {
                        game.Loose();
                    }
                }
                else
                {
                    
                        other.Collidable = false;
                        AjouterPoints(300);
                        game.RemoveItem(other);
                    }
                    
            }
            else if (other.TypeName =="marteau")
            {
                
                    other.Collidable = false;

                    aMarteau = true;
                    tempsMarteau = 0;
                    AjouterPoints(100);
                    game.RemoveItem(other);
                    ChangeSprite("mario_marteau_droite.png");
                
                }
            else if (other.TypeName =="princesse")
            {
              
                
                    other.Collidable = false;
                    AjouterPoints(5000);
                    PlaySound("win1.wav");
                    game.Win();
                }
                

            
        }
        #endregion
    }
}