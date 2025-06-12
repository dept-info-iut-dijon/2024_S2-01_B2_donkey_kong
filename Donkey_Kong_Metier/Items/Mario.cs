using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUTGame;

namespace Donkey_Kong_Metier.Items
{
    /// <summary>
    /// Mario pour l'instant il est ps dutout finis .
    /// </summary>
    public class Mario : GameItem,  IAnimable
    {

        private bool peutGrimper = false;
        private bool surEchelle = false;
        private bool aMarteau = false;
        private double tempsMarteau = 0;
        public bool AMarteau
        {
            get { return aMarteau; }
        }


        public Mario(double x, double y, Game game) : base(x, y, game, "mario.png", 1)
        {
            Collidable = true;
        }

       
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
    }
}
