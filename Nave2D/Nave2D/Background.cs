using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2D
{
    public class Background
    {
        public Texture2D background;
        public Rectangle Rectangle;


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Rectangle, Color.White);
        }
    }
    class Scrolling : Background
    {
        private object graphics;

        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            background = newTexture;
            Rectangle = newRectangle;
        }

        public void Update()
        {
            Rectangle.Y += 3;
        }
    }
}
