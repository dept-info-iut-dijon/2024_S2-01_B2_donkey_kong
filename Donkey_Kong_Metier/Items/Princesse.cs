using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Princesse à sauver en haut du niveau.
    /// </summary>
    public class Princesse : GameItem, IAnimable
    {
        private double tempsAnimation = 0;
        private bool piedGauche = true;

        public Princesse(double x, double y, Game game) : base(x, y, game, "peach_gauche.png", 1)
        {
            Collidable = true;
        }

        public void Animate(TimeSpan dt)
        {
            tempsAnimation += dt.TotalSeconds;

            // Change de sprite toutes les 1 secondes
            if (tempsAnimation >= 1)
            {
                if (piedGauche)
                {
                    ChangeSprite("peach_droite.png");
                }
                else
                {
                    ChangeSprite("peach_gauche.png");
                }

                piedGauche = !piedGauche;
                tempsAnimation = 0;
            }
        }

        public override string TypeName
        {
            get
            {
                return "princesse";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Joueur")
            {
                TheGame.Win();
            }
        }
    }
}
