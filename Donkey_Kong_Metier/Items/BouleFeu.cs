using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{

    /// <summary>
    /// Boule de feu présente dans le jeu.
    /// </summary>
    public class BouleFeu : GameItem
    {
        public BouleFeu(double x, double y, Game game) : base(x, y, game, "feu_droite.png", 2)
        {
            Collidable = true;
        }

        public override string TypeName
        {
            get
            {
                return "feu_droite";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            // Implémentation 3.1
        }
    }
}
