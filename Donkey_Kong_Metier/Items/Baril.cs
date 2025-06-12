using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Baril qui apparaît dans le jeu.
    /// </summary>
    public class Baril : GameItem
    {
        public Baril(double x, double y, Game game) : base(x, y, game, "baril.png", 1)
        {
            Collidable = true;
        }

        public override string TypeName
        {
            get
            {
                return "baril";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            // Implémentation  3.1
        }
    }
}
