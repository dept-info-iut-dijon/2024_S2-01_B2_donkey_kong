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
    public class DonkeyKong : GameItem, IAnimable
    {
        public DonkeyKong(double x, double y, Game game) : base(x, y, game, "singe_debout.png", 1)
        {
            Collidable = true;
        }

        public void Animate(TimeSpan dt)
        {
            // Animation de DK 
            // implémenter  logique de lancement de barils
        }

        public override string TypeName
        {
            get
            {
                return "donkey_kong";
            }
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "Joueur")
            {
                TheGame.Loose();
            }
        }
    }
}

