using Donkey_Kong_Metier.Items;
using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Donkey_Kong_Metier
{
    /// <summary>
    /// Classe représentant le joueur
    /// </summary>
    public class Joueur : GameItem, IAnimable, IKeyboardInteract
    {
        #region Attributs
        // Constante pour la vitesse
        private const double VitesseDeplacement = 3.0;

        // État du mouvement
        private bool mouvementGauche = false;
        private bool mouvementDroite = false;
        private bool mouvementHaut = false;
        private bool mouvementBas = false;

        // Animation et sprites
        private double tempsAnimation = 0;
        private bool piedDroit = true;
        private string derniereDirection = "droite";

        // Attributs du jeu
        private int nbVie = 3;
        private int score = 0;
        private bool aMarteau = false;
        private double tempsMarteau = 0;

        #endregion

        #region Propriétés
        public bool AMarteau
        {
            get { return aMarteau; }
        }

        public int Score
        {
            get { return score; }
        }

        public int NbVie
        {
            get { return nbVie; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du joueur
        /// </summary>
        /// <param name="x">Coordonnées x du joueur</param>
        /// <param name="y">Coordonnées y du joueur</param>
        /// <param name="game">Le jeu en cours</param>
        /// <param name="zindex">Priorité d'affichage du sprite</param>
        public Joueur(double x, double y, Game game, int zindex = 1)
            : base(x, y, game, "mario_debout_droite.png", zindex)
        {
            Collidable = true;
        }
        #endregion

        #region Propriété héritée
        /// <summary>
        /// Type de l'objet
        /// </summary>
        public override string TypeName => "Joueur";
        #endregion

        #region Méthodes d'animation
        /// <summary>
        /// Animation du joueur
        /// </summary>
        /// <param name="dt">Temps écoulé depuis la dernière frame</param>
        public void Animate(TimeSpan dt)
        {
            tempsAnimation += dt.TotalSeconds;

            bool enMouvement = false;

            // Gestion du mouvement horizontal
            if (mouvementGauche && !mouvementDroite)
            {
                MoveXY(-VitesseDeplacement, 0);
                derniereDirection = "gauche";
                enMouvement = true;

                // Animation de marche
                if (tempsAnimation >= 0.15)
                {
                    if (piedDroit)
                        ChangeSprite("mario_retourner_gauche.png");
                    else
                        ChangeSprite("mario_retourner_gauche2.png");

                    piedDroit = !piedDroit;
                    tempsAnimation = 0;
                }
            }
            else if (mouvementDroite && !mouvementGauche)
            {
                MoveXY(VitesseDeplacement, 0);
                derniereDirection = "droite";
                enMouvement = true;

                // Animation de marche
                if (tempsAnimation >= 0.15)
                {
                    if (piedDroit)
                        ChangeSprite("mario_retourner_droite.png");
                    else
                        ChangeSprite("mario_retouner_droite_face.png");

                    piedDroit = !piedDroit;
                    tempsAnimation = 0;
                }
            }

            // Gestion du mouvement vertical
            if (mouvementHaut && !mouvementBas)
            {
                MoveXY(0, -VitesseDeplacement);
                enMouvement = true;

                // Animation d'escalade
                if (tempsAnimation >= 0.2)
                {
                    if (piedDroit)
                        ChangeSprite("mario_echelle2.png");
                    else
                        ChangeSprite("mario_echelle3.png");

                    piedDroit = !piedDroit;
                    tempsAnimation = 0;
                }
            }
            else if (mouvementBas && !mouvementHaut)
            {
                MoveXY(0, VitesseDeplacement);
                enMouvement = true;

                // Animation d'escalade
                if (tempsAnimation >= 0.2)
                {
                    if (piedDroit)
                        ChangeSprite("mario_echelle4.png");
                    else
                        ChangeSprite("mario_echelle5.png");

                    piedDroit = !piedDroit;
                    tempsAnimation = 0;
                }
            }

            // Si pas de mouvement, sprite debout
            if (!enMouvement)
            {
                if (aMarteau)
                {
                    if (derniereDirection == "droite")
                        ChangeSprite("mario_debout_marteau_droite.png");
                    else
                        ChangeSprite("mario_debout_marteau_gauche.png");
                }
                else
                {
                    if (derniereDirection == "droite")
                        ChangeSprite("mario_debout_droite.png");
                    else
                        ChangeSprite("mario_debout_gauche.png");
                }
                tempsAnimation = 0;
            }

            // Gestion du temps de marteau
            if (aMarteau)
            {
                tempsMarteau += dt.TotalSeconds;
                if (tempsMarteau >= 10.0)
                {
                    aMarteau = false;
                    tempsMarteau = 0;
                }
            }

            // Vérification des limites de l'écran
            if (Left < 0) PutXY(0, Top);
            if (Top < 0) PutXY(Left, 0);
            if (Right > GameWidth) PutXY(GameWidth - Width, Top);
            if (Bottom > GameHeight) PutXY(Left, GameHeight - Height);
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
                case Key.Left:
                    mouvementGauche = true;
                    break;
                case Key.Right:
                    mouvementDroite = true;
                    break;
                case Key.Up:
                    mouvementHaut = true;
                    break;
                case Key.Down:
                    mouvementBas = true;
                    break;
                case Key.Space:
                    Sauter();
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
                case Key.Left:
                    mouvementGauche = false;
                    break;
                case Key.Right:
                    mouvementDroite = false;
                    break;
                case Key.Up:
                    mouvementHaut = false;
                    break;
                case Key.Down:
                    mouvementBas = false;
                    break;
            }
        }

        /// <summary>
        /// Gestion du saut
        /// </summary>
        private void Sauter()
        {
            if (derniereDirection == "droite")
                ChangeSprite("mario_saut_droite.png");
            else
                ChangeSprite("mario_saut_gauche.png");
        }
        #endregion

        #region Collision
        /// <summary>
        /// Collision avec les autres objets
        /// </summary>
        /// <param name="other">Objet avec lequel il y a collision</param>
        public override void CollideEffect(GameItem other)
        {
            switch (other.TypeName)
            {
                case "baril":
                case "boule_feu":
                    if (!aMarteau)
                    {
                        nbVie--;
                        ChangeSprite("mario_ko.png");

                        if (nbVie <= 0)
                        {
                            TheGame.Loose();
                        }
                    }
                    break;

                case "marteau_debout":
                    aMarteau = true;
                    tempsMarteau = 0;
                    break;

                case "princesse":
                    TheGame.Win();
                    break;
            }
        }
        #endregion
    }
}