using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Donkey_Kong_Metier
{
    internal class Joueur : GameItem, IAnimable
    {
        public Joueur(double x, double y, Game game, string spriteName = "", int zindex = 0) : base(x, y, game, spriteName, zindex)
        {
        }

        public override string TypeName => throw new NotImplementedException();

        public void Animate(TimeSpan dt)
        {
            throw new NotImplementedException();
        }

        public override void CollideEffect(GameItem other)
        {
            throw new NotImplementedException();
        }

    }
}
