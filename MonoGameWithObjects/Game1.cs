using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameWithObjects
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Die myD1, myD2;
        private SpriteFont _gameFont;

        private List<Texture2D> _diceTextures;

        private Hero _myHero;
    

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _myHero = new Hero("Aaron The GREAT!", 75);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameFont = Content.Load<SpriteFont>("GameFont");

            // TODO: use this.Content to load your game content here
            _diceTextures = new List<Texture2D>();
            for(int i = 0; i < 6; i++)
                _diceTextures.Add(Content.Load<Texture2D>("d" + (i + 1)));
            

            myD1 = new Die(1000000, _diceTextures, 10, 10);
            myD2 = new Die(3, _diceTextures, 10, 100);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            myD1.Update();
            myD2.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.H))
                _myHero.Heal(1);

            if (Keyboard.GetState().IsKeyDown(Keys.K))
                _myHero.TakeDamage(1);



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            myD1.Draw(_spriteBatch);
            myD2.Draw(_spriteBatch);

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_gameFont, _myHero.GetName() 
                + " has " + _myHero.GetHealth() 
                + " health.", new Vector2(10, 200), Color.White);


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
