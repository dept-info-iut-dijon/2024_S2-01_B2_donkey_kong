using IUTGame;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Donkey Kong personnage principal ennemi.
    /// </summary>
    public class DonkeyKong : GameItem, IAnimable
    {
        #region -- Attributs --
        /// <summary>
        /// Temps d'attente pour chaque création de baril
        /// </summary>
        private TimeSpan timeToCreate;

        /// <summary>
        /// Temps d'attente avant de faire défiler les images d'animation
        /// </summary>
        private TimeSpan timeToUpdateLancer;

        /// <summary>
        /// Attribut contenant toute les echelles du jeu
        /// </summary>
        private List<Echelle> echelles;

        /// <summary>
        /// Attribut contenant toute les plateformes du jeu
        /// </summary>
        private List<Plateforme> plateformes;

        /// <summary>
        /// Contient le jeu
        /// </summary>
        private LeJeu game;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de DOnkeyKong
        /// </summary>
        /// <param name="p"> Plateformes du jeu </param>
        /// <param name="e"> Echelles du jeu </param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="game"></param>
        public DonkeyKong(List<Plateforme> p, List<Echelle> e, double x, double y, LeJeu game) : base(x, y, game, "singe_debout.png", 1)
        {
            this.game = game;
            Collidable = true;
            timeToCreate = new TimeSpan(0, 0, 0, 1);
            timeToUpdateLancer = new TimeSpan(0, 0, 0, 1, 800);
            plateformes = p;
            echelles = e;
        }

        #endregion

        #region -- Propriétés -- 

        /// <summary>
        /// Prorpiétés renvoyant le type name donkey_kong
        /// </summary>
        public override string TypeName
        {
            get
            {
                return "donkey_kong";
            }
        }

        #endregion

        #region -- Méthodes --

        /// <summary>
        /// Animation de Donkey Kong
        /// </summary>
        /// <param name="dt"></param>
        public void Animate(TimeSpan dt)
        {
            timeToUpdateLancer -= dt;
            timeToCreate -= dt;

            if (timeToUpdateLancer.TotalMilliseconds < 0)
            {
                this.ChangeSprite("singe_baril.png");
                timeToUpdateLancer += new TimeSpan(5, 0, 0);
            }
            if (timeToCreate.TotalMilliseconds < 0)
            {
                this.ChangeSprite("singe_debout.png");
                Random r = new Random();
                Baril baril = new Baril(plateformes, echelles, GameWidth - 620, GameHeight - 480, TheGame);
                game.AjouterBaril(baril);
                TheGame.AddItem(baril);
                double ms = r.NextDouble() * 1500 + 1000;
                timeToCreate = new TimeSpan(0, 0, 0, 0, (int)ms);
                TimeSpan t = new TimeSpan(0, 0, 0, 0, 200);
                timeToUpdateLancer = timeToCreate.Subtract(t);
            }
        }

        /// <summary>
        /// L'effet des collision avec les game item 
        /// </summary>
        /// <param name="other"></param>
        public override void CollideEffect(GameItem other)
        {
            ///geré dans Joueur
        }

        #endregion
    }
}

