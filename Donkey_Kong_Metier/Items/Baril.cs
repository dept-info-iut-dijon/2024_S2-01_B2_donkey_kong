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
        private List<Plateforme> plateformes;
        public Baril(List<Plateforme> p, double x, double y, Game game) : base(x, y, game, "baril.png", 1)
        {
            Collidable = true;
            this.plateformes = p;
        }

        /// <summary>
        /// Méthode pour animer le baril
        /// </summary>
        /// <param name="dt"></param>
        public void Animate(TimeSpan dt)
        {
            //this.ChangeSprite(); pour animer
            if (VerificationCollision(plateformes))
            {
                if (this.Right > 400)
                {
                    this.MoveXY(-1, 0);
                }
                else
                {
                    this.MoveXY(1, 0);
                }
            }
            else
            {
                this.MoveXY(0, +1);
            }
            
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
                    // il faut aussi que l'on oublie pas d'Ajouter des points au score
                }
            }
        }

        /// <summary>
        /// Méthode qui vérifie s'il y a eu une collision avec une platforme, qu'importe laquelle
        /// </summary> 
        /// <param name="plateforme"></param>
        /// <returns></returns>
        public bool VerificationCollision(List<Plateforme> plateforme)
        {
            bool res = false;
            foreach (Plateforme p in plateforme)
            {
                if (this.IsCollide(p))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
    }
}
