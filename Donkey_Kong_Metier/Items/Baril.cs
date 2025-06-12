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
    public class Baril : GameItem, IAnimable
    {
        public Baril(double x, double y, Game game) : base(x, y, game, "baril.png", 1)
        {
            Collidable = true;
        }

        public void Animate(TimeSpan dt)
        {
            // Le baril descend et roule
            // implémenter logique de mouvement 
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
            if (other.TypeName == "tonneau_huile")
            {
                // baril en boule de feu
                BouleFeu feu = new BouleFeu(Left, Top, TheGame);
                TheGame.AddItem(feu);
                TheGame.RemoveItem(this);
            }
            else if (other.TypeName == "mario")
            {
                // Vérifier si Mario a le marteau actif
                
                if (other is Mario mario && mario.AMarteau)
                {
                    TheGame.RemoveItem(this);
                    // il faut aussi que l'on oublie d'Ajouter des points au score
                }
            }
        }
    }
}
