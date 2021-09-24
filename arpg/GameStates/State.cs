using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Main;

namespace towerdef.GameStates
{
    public abstract class State
    {
        protected Game1 _game;
        protected ContentManager _content;
        protected SessionStorageProvider _sessionStorageProvider;

        public State(Game1 game, ContentManager content, SessionStorageProvider sessionStorageProvider)
        {
            _game = game;
            _content = content;
            _sessionStorageProvider = sessionStorageProvider;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void PostUpdate(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
