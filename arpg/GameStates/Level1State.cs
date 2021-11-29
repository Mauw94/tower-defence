using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using towerdef.Entities.Towers.Missiles.Explosions;
using towerdef.Helpers;
using towerdef.Helpers.EventQueue;
using towerdef.Levels;
using towerdef.Main;
using towerdef.Managers;

namespace towerdef.GameStates
{
    public class Level1State : BaseLevelState
    {
        public Level1State(TowerDefence game, ContentManager content, SessionStorageProvider sessionStorageProvider)
            : base(game, content, sessionStorageProvider)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Level.Level1.LevelWon)
                _game.ChangeState(new Level2State(_game, _content, _sessionStorageProvider));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            base.PostUpdate(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Init()
        {
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
