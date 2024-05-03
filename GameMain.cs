using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RetroNumen.Utility;
using System;

namespace RetroNumen
{
    public class GameMain : Game
    {
        private static GraphicsDeviceManager _graphics;
        public static GraphicsDeviceManager Graphics { get { return _graphics; } }

        private static SpriteBatch _spriteBatch;
        public static SpriteBatch SpriteBatch { get { return _spriteBatch; } }

        private static Cache _cache;
        public static Cache Cache { get { return _cache; } }

        private static Random _random;
        public static Random Random { get { return _random; } } 

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}