using arpg.Entities.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using towerdef.Entities.Enemies;
using towerdef.Entities.Towers;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.GameStates
{
    public class Level1State : State
    {
        private Texture2D _gameMap;
        private Texture2D _basicTowerTexture;
        private Texture2D _missileTexture;
        private Texture2D _basicSkeletonTexture;
        private List<Sprite> _sprites;
        private EnemyManager _enemyManager;
        private MissileManager _missileManager;
        private bool _levelStarted = false;

        public Level1State(Game1 game, ContentManager content) : base(game, content)
        {
        }

        public override void LoadContent()
        {
            // load textures.
            _gameMap = _content.Load<Texture2D>("level1");
            _basicTowerTexture = _content.Load<Texture2D>("tower1");
            _missileTexture = _content.Load<Texture2D>("missile");
            _basicSkeletonTexture = _content.Load<Texture2D>("skeleton1");

            // initialize managers.
            _enemyManager = new EnemyManager();
            _missileManager = new MissileManager(_missileTexture);
            Init();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // todo: check for enemies to remove here.
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_gameMap, new Vector2(0, 0), Color.White);

            foreach (var sprite in _sprites.ToArray())
                sprite.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        void Init()
        {
            var skeleton1 = _enemyManager.GenerateSkeleton(_basicSkeletonTexture);
            var skeleton2 = _enemyManager.GenerateSkeleton(_basicSkeletonTexture);
            skeleton2.Position = new Vector2(Game1.ScreenWidth - 200, Game1.ScreenHeight / 2);

            var tower1 = new BasicTower(_basicTowerTexture, _missileManager);

            _sprites = new List<Sprite>()
            {
                tower1,
                skeleton1,
                skeleton2
            };

            _levelStarted = true;
        }
    }
}
