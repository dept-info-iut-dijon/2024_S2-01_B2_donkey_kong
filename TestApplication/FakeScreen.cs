using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Donkey_Kong_Metier;
using Donkey_Kong_Metier.Items;


namespace TestsUnitaires
{
    /// <summary>
    /// Classe FakeScreen afin de faire les tests unitaires
    /// </summary>
    internal class FakeScreen : IScreen
    {

        private KeyEvent keyevent;
        private MouseButtonEvent mousebuttonevent;
        private MouseMoveEvent mousemovevent;
        private MouseWheelEvent mousewheelevent;
        public KeyEvent KeyDown { get => keyevent; set => keyevent = value; }
        public KeyEvent KeyUp { get => keyevent; set => keyevent = value; }
        public MouseWheelEvent MouseWheel { get => mousewheelevent; set => mousewheelevent = value; }
        public MouseButtonEvent MouseDown { get => mousebuttonevent ; set => mousebuttonevent = value; }
        public MouseButtonEvent MouseUp { get => mousebuttonevent; set => mousebuttonevent = value; }
        public MouseMoveEvent MouseMove { get => mousemovevent; set => mousemovevent = value; }

        public double Width => 800;

        public double Height => 600;

        public void DrawSprite(int spriteID, double x, double y, double angle = 0, double scaleX = 1, double scaleY = 1, int zindex = 0)
        {
            //
        }

        public void Focus()
        {
            //throw new NotImplementedException();
        }

        public double GetSpriteHeight(int spriteID)
        {
            return 2;
            //throw new NotImplementedException();
        }

        public double GetSpriteWidth(int spriteID)
        {
           return  2;
        }

        public void InitSpritesStore(string spritesFolderName)
        {
            //
        }

        public int LoadSprite(string spriteName)
        {
           return 2;
        }

        public void RemoveSprite(int spriteID)
        {
            //throw new NotImplementedException();
        }
    }
}
