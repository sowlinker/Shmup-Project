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
    class Enemy
    {
        public float velocidade { get; set; }

        public Vector2 Posicao { get; set; } //inicio

        public Vector2 Direcao { get; set; } //termino

        public Texture2D Textura { get; set; }

        public Rectangle Frame { get; set; }

        //Metodo Construtor
        public Enemy(ContentManager content, Vector2 posicao)
        {
            Textura = content.Load<Texture2D>("Imagens\\enemy1");
            Posicao = posicao;
            velocidade = 0;
            Direcao = Vector2.Zero;
        }

        public void Movement(GameTime gameTime, Vector2 Direction)
        {
            float timeExecution = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Posicao += velocidade * Direction * timeExecution;
        }

        public void Acceleration(GameTime gameTime)
        {
            float timeExecution = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Posicao *= velocidade * Direcao * timeExecution;
        }

        public void Drawed(SpriteBatch spriteBatch)
        {
            Frame = new Rectangle((int)Posicao.X, (int)Posicao.Y, Textura.Width, Textura.Height);
            spriteBatch.Draw(Textura, Frame, Color.White);
        }
    }
}
