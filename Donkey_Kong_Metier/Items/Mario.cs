using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Mario pour l'instant il est ps dutout finis .
    /// </summary>
    public class Mario : GameItem,  IAnimable
    {
        #region Attributs

        private bool peutGrimper = false;
        private bool surEchelle = false;
        private bool aMarteau = false;
        private double tempsMarteau = 0;

        #endregion

        #region Propriétés
        public bool AMarteau
        {
            get { return aMarteau; }
        }
        #endregion

        #region Constructeur
        public Mario(double x, double y, Game game) : base(x, y, game, "mario_debout_droite.png", 1)
        {
            Collidable = true;
        }
        #endregion

        #region Méthodes
        public void Animate(TimeSpan dt)
        {
          
        }

        public override string TypeName
        {
            get
            {
                return "mario";
            }
        }

        public override void CollideEffect(GameItem other)
        {
           
        }

        public void KeyDown(Key key)
        { }

        public void KeyUp(Key key)
        { }
        #endregion
    }
}
