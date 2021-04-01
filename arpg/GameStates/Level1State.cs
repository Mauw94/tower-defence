using arpg.Entities.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using towerdef.Helpers;
using towerdef.Levels;
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
        private Texture2D _hudTexture;
        private Texture2D _undoButton;
        private Texture2D _healthTexture;

        private List<Sprite> _sprites;

        private EnemyManager _enemyManager;
        private MissileManager _missileManager;
        private BuildManager _buildManager;

        private LevelBuilderHUD _builderHud;

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
            _hudTexture = _content.Load<Texture2D>("builderhud");
            _undoButton = _content.Load<Texture2D>("undo");
            _healthTexture = _content.Load<Texture2D>("health");

            TextureHelper.HealthTexture = _healthTexture;

            // initialize managers.
            _enemyManager = new EnemyManager();
            _missileManager = new MissileManager(_missileTexture);
            _buildManager = new BuildManager();

            // initialize helpers
            _builderHud = new LevelBuilderHUD(_hudTexture, _basicTowerTexture, _undoButton);

            Init();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                _levelStarted = true;

            if (_levelStarted)
            {
                foreach (var enemy in EnemyManager.Enemies.ToArray())
                    enemy.Update(gameTime);

                foreach (var build in BuildManager.Towers.ToArray())
                    build.Update(gameTime);

                foreach (var missile in MissileManager.Missiles.ToArray())
                    missile.Update(gameTime);
            } 
            else
            {
                _builderHud.Update(gameTime);
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // todo: check for enemies to remove here.
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            // draw game map.
            spriteBatch.Draw(_gameMap, new Vector2(0, 0), Color.White);

            // draw towers that were placed before round start.
            foreach (var build in BuildManager.Towers.ToArray())
                build.Draw(gameTime, spriteBatch);

            // draw enemies and missiles being fired.
            if (_levelStarted)
            {
                foreach (var enemy in EnemyManager.Enemies.ToArray())
                    enemy.Draw(gameTime, spriteBatch);
                
                foreach (var missiles in MissileManager.Missiles.ToArray())
                    missiles.Draw(gameTime, spriteBatch);
            } 
            else
            {
                // draw hud.
                _builderHud.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        void Init()
        {
            EnemyManager.GenerateSkeleton(_basicSkeletonTexture);
            var skel2 = EnemyManager.GenerateSkeleton(_basicSkeletonTexture);
            skel2.Position = new Vector2(Game1.ScreenWidth - 400, Game1.ScreenHeight / 2);

            _levelStarted = false;
        }
    }
}
