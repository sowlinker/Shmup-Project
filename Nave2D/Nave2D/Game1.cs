using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nave2D
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Scrolling scrolling1;
        Scrolling scrolling2;


        //Objects



        Texture2D nave;
        Rectangle navePosicao;
        Point naveVelocidade;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            graphics.PreferredBackBufferWidth = 500;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 800;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            scrolling1 = new Scrolling(Content.Load<Texture2D>("Imagens/background"), new Rectangle(0, 0, 500, 800));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("Imagens/background2"), new Rectangle(0, -800, 500, 800));


            // TODO: use this.Content to load your game content here





            nave = Content.Load<Texture2D>("Imagens\\nave-2d");
            navePosicao = new Rectangle(new Point((graphics.PreferredBackBufferWidth - 100) / 2, 700), new Point(100, 100));
            naveVelocidade = new Point(5, 5);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            
        }   


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here




            //if (scrolling1.Rectangle.Y + scrolling1.background.Height <= 0)
            //scrolling1.Rectangle.Y += 1;//scrolling2.Rectangle.Y + scrolling2.background.Height;

            // if (scrolling2.Rectangle.Y + scrolling2.background.Height <= 0)
            //scrolling2.Rectangle.Y += 1;// scrolling1.Rectangle.Y + scrolling1.background.Height;



            scrolling1.Update();
            scrolling2.Update();

            if(scrolling1.Rectangle.Y >= graphics.PreferredBackBufferHeight)
            {
                scrolling1.Rectangle.Y = -799;
            }

            if (scrolling2.Rectangle.Y >= graphics.PreferredBackBufferHeight)
            {
                scrolling2.Rectangle.Y = -798;
            }







            //variavel para facilitar o uso do Keyboard.GetState()
            var kbs = Keyboard.GetState();

            //Variáveis de Controle de Movimento
            bool leftArrow = false, rightArrow = false, upArrow = false, downArrow = false;
            //Se estiver pressionada a Seta para Esquerda, LeftArrow  =true
            leftArrow = kbs.IsKeyDown(Keys.Left);
            //Se estiver pressionada a Seta para Direita, rightArrow = true
            rightArrow = kbs.IsKeyDown(Keys.Right);
            //Se estiver pressionada a Seta para Cima, upArrow = True
            upArrow = kbs.IsKeyDown(Keys.Up);
            //Se estiver pressionada a Seta para Cima, downArrow = True
            downArrow = kbs.IsKeyDown(Keys.Down);
            //Se SOMENTE uma das teclas estiver pressionada, muda a posição X
            if(leftArrow ^ rightArrow)
            {
                //Muda a posição X de acordo com a Velocidade e a tecla pressionada
                navePosicao.X += naveVelocidade.X * (leftArrow ? -1 : 1);

            }

            //Se Somente uma das teclas estiver pressionada, muda a posição Y
           

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            scrolling1.Draw(spriteBatch);
            scrolling2.Draw(spriteBatch);
            spriteBatch.End();


            spriteBatch.Begin();
            spriteBatch.Draw(nave, navePosicao, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
