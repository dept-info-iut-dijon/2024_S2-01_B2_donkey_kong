using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Tonneau d'huile présent dans le niveau.
    /// </summary>
    public class TonneauHuile : GameItem
    {
        public TonneauHuile(double x, double y, Game game) : base(x, y, game, "oil.png", 0)
        {
            Collidable = true;
        }

        public override string TypeName
        {
            get
            {
                return "tonneau_huile";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            // il fait rien 
        }
    }
}
