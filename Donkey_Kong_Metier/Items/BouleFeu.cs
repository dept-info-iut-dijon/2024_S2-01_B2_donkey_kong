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
   
        public class BouleFeu : GameItem, IAnimable
        {
            public BouleFeu(double x, double y, Game game) : base(x, y, game, "boule_feu.png", 2)
            {
                Collidable = true;
            }

            public void Animate(TimeSpan dt)
            {
                // La boule de feu se déplace 
                // implémenter mouvement aléatoire
            }

            public override string TypeName
            {
                get
                {
                    return "boule_feu";
                }
            }

            public override void CollideEffect(GameItem other)
            {
                // Implémentation 3.1
            }
        }
    }
