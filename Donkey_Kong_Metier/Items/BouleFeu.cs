using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup.Localizer;
using Donkey_Kong_Metier;
using DonkeyKongMetier;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Boule de feu présente dans le jeu.
    /// </summary>
    public class BouleFeu : GameItem, IAnimable
    {
        #region Attributs
        /// <summary>
        /// Attribut pour savoir si la boule de feu touche l'escalier
        /// </summary>
        private bool toucherEscalier;
        #endregion

        #region Constructeur
        public BouleFeu(double x, double y, Game game) : base(x, y, game, "feu_bas_droite.png", 2)
        {
            Collidable = true;
            toucherEscalier = false;
        }
        #endregion

        #region Propriété
        public override string TypeName
        {
            get
            {
                return "boule_feu";
            }
        }
        #endregion

        #region Méthodes*

        /// <summary>
        /// Méthode permettant d'animer et de déplacer la boule de feu
        /// </summary>
        /// <param name="dt"></param>
        public void Animate(TimeSpan dt)
        {
            Random random = new Random();

            if (toucherEscalier)
            {
                toucherEscalier = false;
                random.Next();
                switch (random.Next(1))
                {
                    case 0:
                        MoveXY(0, -2);
                        MoveXY(0, -2);
                        MoveXY(0, -2);
                        MoveXY(0, -2);
                        //verifier qu'il va au bout de l'echelle
                        break;
                    case 1:
                        MoveXY(0, 0);
                        break;
                }
            }
            else
            {
                switch (random.Next(1))
                {
                    case 0:
                        MoveXY(2, 0);
                        break;
                    case 1:
                        MoveXY(-2, 0);
                        break;
                }
            }
            
            // La boule de feu se déplace 
            // implémenter mouvement aléatoire
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Joueur")
            {
                // Vérifier si Mario a le marteau actif
                if (other is Joueur joueur && joueur.AMarteau)
                {
                    TheGame.RemoveItem(this);
                    // il faut aussi que l'on oublie d'Ajouter des points au score
                }
            }
            else if (other.TypeName == "echelle")
            {
                toucherEscalier = true;
            }
        }
        #endregion
    }
}
