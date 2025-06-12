using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{

    /// <summary>
    /// Plateforme sur laquelle les personnages peuvent se déplacer.
    /// </summary>
    public class Plateforme : GameItem
    {
        public Plateforme(double x, double y, Game game) : base(x, y, game, "plateforme.png")
        {
            Collidable = true;
        }

        public override string TypeName
        {
            get
            {
                return "plateforme";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            throw new NotImplementedException();
            // comme echelle
        }
    }
}
