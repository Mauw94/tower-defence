using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using towerdef.GameStates;
using towerdef.Main;

namespace towerdef
{
    public class TowerDefence : Game
    {
        public static AppState AppState;
        public static Random Random;

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        // todo: fix -> cant be accessible like this
        public static string GameKey;

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        private State _currentState;
        private State _nextState;
        private SessionStorageProvider _sessionStorageProvider;
        private ServiceBus _serviceBus;

        public TowerDefence()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            AppState = AppState.NotRunning;
            _serviceBus = new ServiceBus();
            _serviceBus.AddMessage("Towerdefence is " + AppState.ToString());
        }

        protected override void Initialize()
        {
            AppState = AppState.Running;
            Random = new Random();
            
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            GameKey = Guid.NewGuid().ToString();
            _sessionStorageProvider = new SessionStorageProvider();
            _sessionStorageProvider.CreateNewSession(GameKey);
            _serviceBus.AddMessage("Towerdefence is " + AppState.ToString());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, Content, _sessionStorageProvider);
            _currentState.LoadContent();
            _nextState = null;
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.LoadContent();

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public static string GetMessage()
        {
            return null;
        }
    }
}
