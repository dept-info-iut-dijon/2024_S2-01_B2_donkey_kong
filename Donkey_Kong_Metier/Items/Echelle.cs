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
        public Echelle(double x, double y, Game game) : base(x, y, game, "ehcelle.png", 0)
        {
            Collidable = false; // Les échelles ne bloquent pas le mouvement
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
            // Les échelles n'ont pas d'effet de collision direct
            // C'est le joueur qui gère sa capacité à grimper quand il touche une échelle
        }
    }
}