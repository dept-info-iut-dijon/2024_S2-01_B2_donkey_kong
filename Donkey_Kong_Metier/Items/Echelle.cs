using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Échelle pour que Mario puisse monter et descendre.
    /// </summary>
    public class Echelle : GameItem
    {
        public Echelle(double x, double y, Game game) : base(x, y, game, "echelle.png", 0)
        {
            Collidable = false;
        }

        public override string TypeName
        {
            get
            {
                return "echelle";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            // Implémentation  3.1
        }
    }

}
