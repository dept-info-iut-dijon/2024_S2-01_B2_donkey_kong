using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Marteau que Mario peut ramasser.
    /// </summary>
    public class Marteau : GameItem
    {
        public Marteau(double x, double y, Game game) : base(x, y, game, "marteau_haut.png", 1)
        {
            Collidable = true;
        }

        public override string TypeName
        {
            get
            {
                return "marteau_debout";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "mario")
            {
                TheGame.RemoveItem(this);
            }
        }
    }
}
