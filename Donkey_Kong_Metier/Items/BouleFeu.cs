using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonkeyKongMetier;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Boule de feu présente dans le jeu.
    /// </summary>
    public class BouleFeu : GameItem, IAnimable
    {
        #region Constructeur
        public BouleFeu(double x, double y, Game game) : base(x, y, game, "feu_bas_droite.png", 2)
        {
            Collidable = true;
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

        #region Méthodes
        public void Animate(TimeSpan dt)
        {
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
        }
        #endregion
    }
}
