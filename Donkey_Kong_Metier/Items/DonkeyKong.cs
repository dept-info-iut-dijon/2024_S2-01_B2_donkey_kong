using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Donkey Kong personnage principal ennemi.
    /// </summary>
    public class DonkeyKong : GameItem
    {
        public DonkeyKong(double x, double y, Game game) : base(x, y, game, "singe_debout.png", 1)
        {
            Collidable = true;
        }

        public override string TypeName
        {
            get
            {
                return "singe_debout";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            // Implémentation 3.1
        }
    }
}
