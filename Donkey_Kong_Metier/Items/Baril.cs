using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donkey_Kong_Metier;
using DonkeyKongMetier;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    
    /// <summary>
    /// Baril qui apparaît dans le jeu.
    /// </summary>
    public class Baril : GameItem, IAnimable
    {
        #region Attributs
        /// <summary>
        /// Listes de toute les plateformes du jeu
        /// </summary>
        private List<Plateforme> plateformes;

        #endregion


        #region Propriété
        public override string TypeName
        {
            get
            {
                return "baril";
            }
        }

        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du baril
        /// </summary>
        /// <param name="p"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="game"></param>
        public Baril(List<Plateforme> p, double x, double y, Game game) : base(x, y, game, "baril.png", 1)
        {
            Collidable = true;
            this.plateformes = p;
        }

        #endregion

        #region Méthodes
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

        /// <summary>
        /// Méthode implémentant les conséquences lorsqu'un barril touche autre chose
        /// </summary>
        /// <param name="other"></param>
        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "tonneau_huile")
            {
                // baril en boule de feu
                BouleFeu feu = new BouleFeu(Left, Top, TheGame);
                TheGame.AddItem(feu);
                TheGame.RemoveItem(this);
            }
        }

        /// <summary>
        /// Méthode qui vérifie s'il y a eu une collision avec une platforme, qu'importe laquelle
        /// </summary> 
        /// <param name="plateforme"></param>
        /// <returns></returns>
        public bool VerificationCollision(List<Plateforme> plateforme)
        {
            foreach (Plateforme p in plateforme)
            {
                if (this.IsCollide(p))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}