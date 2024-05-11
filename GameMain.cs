using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RetroNumen.Display;
using RetroNumen.Entity.Character;
using RetroNumen.Input;
using RetroNumen.Utility;
using System;
using System.Collections.Generic;

namespace RetroNumen
{
    public class GameMain : Game
    {
        #region Static Elements
        private static GraphicsDeviceManager _graphics;
        public static GraphicsDeviceManager Graphics { get { return _graphics; } }

        private static SpriteBatch _spriteBatch;
        public static SpriteBatch SpriteBatch { get { return _spriteBatch; } }

        private static Cache _cache;
        public static Cache Cache { get { return _cache; } }

        private static Random _random;
        public static Random Random { get { return _random; } }

        private static InputManager _inputManager;
        public static InputManager InputManager { get { return _inputManager; } }
        #endregion

        #region Local Elements
        private static DisplayContainer displayContainer;
        private Rectangle _background;
        private Dictionary<int, CharacterBase> _characters;
        #endregion

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 896;
            _graphics.PreferredBackBufferHeight = 672;
        }

        protected override void Initialize()
        {
            _random = new Random();
            _inputManager = InputManager.Instance;
            _cache = Cache.Instance(Content);
            _background = new Rectangle(0, 0, 896, 672);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _cache.Initialize();
            displayContainer = DisplayContainer.Instance;
            _characters = new Dictionary<int, CharacterBase>()
            {
                { 0, new Player(0) }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _inputManager.Update(Keyboard.GetState(), Mouse.GetState());

            displayContainer.Update(gameTime);

            foreach (CharacterBase character in _characters.Values)
            {
                character.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_cache.Textures["background"], this._background, Color.White);
            displayContainer.Draw();
            foreach (CharacterBase character in _characters.Values)
            {
                character.Draw();
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}