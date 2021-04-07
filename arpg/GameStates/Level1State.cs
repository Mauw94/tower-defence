using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using towerdef.Entities;
using towerdef.Helpers;
using towerdef.Levels;
using towerdef.Managers;

namespace towerdef.GameStates
{
    public class Level1State : State
    {
        private Texture2D _gameMap;
        private Texture2D _basicTowerTexture;
        private Texture2D _missileTexture;
        private Texture2D _basicGolemTexture;
        private Texture2D _hudTexture;
        private Texture2D _undoButton;
        private Texture2D _healthTexture;

        private List<Texture2D> _enemyWalkingTextures;

        private SpriteFont _font;

        private EnemyManager _enemyManager;
        private MissileManager _missileManager;
        private BuildManager _buildManager;

        private LevelBuilderHUD _builderHud;
        private CollisionDetection _collisionDetection;

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
            _basicGolemTexture = _content.Load<Texture2D>("Golem_01_Idle_000");
            _hudTexture = _content.Load<Texture2D>("builderhud");
            _undoButton = _content.Load<Texture2D>("undo");
            _healthTexture = _content.Load<Texture2D>("health");

            // load animation images.
            _enemyWalkingTextures = new List<Texture2D>
            {
                _content.Load<Texture2D>("Golem_01_Walking_000"),
                _content.Load<Texture2D>("Golem_01_Walking_001"),
                _content.Load<Texture2D>("Golem_01_Walking_002"),
                _content.Load<Texture2D>("Golem_01_Walking_003"),
                _content.Load<Texture2D>("Golem_01_Walking_004"),
                _content.Load<Texture2D>("Golem_01_Walking_005"),
                _content.Load<Texture2D>("Golem_01_Walking_006"),
                _content.Load<Texture2D>("Golem_01_Walking_007"),
                _content.Load<Texture2D>("Golem_01_Walking_008"),
                _content.Load<Texture2D>("Golem_01_Walking_009"),
                _content.Load<Texture2D>("Golem_01_Walking_010"),
                _content.Load<Texture2D>("Golem_01_Walking_011"),
                _content.Load<Texture2D>("Golem_01_Walking_012"),
                _content.Load<Texture2D>("Golem_01_Walking_013"),
                _content.Load<Texture2D>("Golem_01_Walking_014"),
                _content.Load<Texture2D>("Golem_01_Walking_015"),
                _content.Load<Texture2D>("Golem_01_Walking_016"),
                _content.Load<Texture2D>("Golem_01_Walking_017")
            };

            // load fonts.
            _font = _content.Load<SpriteFont>("game");

            // set textures to use throughout the game.
            TextureHelper.HealthTexture = _healthTexture;
            TextureHelper.BasicSkeletonTexture = _basicGolemTexture;
            TextureHelper.BasicTowerTexture = _basicTowerTexture;
            TextureHelper.HudTexture = _hudTexture;
            TextureHelper.UndoButtonTexture = _undoButton;
            TextureHelper.MissileTexture = _missileTexture;
            TextureHelper.EnemyWalkingTextures = _enemyWalkingTextures;

            // initialize managers.
            _enemyManager = new EnemyManager();
            _missileManager = new MissileManager();
            _buildManager = new BuildManager();

            // initialize helpers
            _builderHud = new LevelBuilderHUD();
            _collisionDetection = new CollisionDetection();

            Init();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _levelStarted = true;
                LevelStatsHelper.Reset();
            }

            if (LevelStatsHelper.WaveEnd)
            {
                _levelStarted = false;
                Reset();
            }

            if (_levelStarted)
            {
                foreach (var enemy in EnemyManager.Enemies.ToArray())
                    enemy.Update(gameTime);

                foreach (var build in BuildManager.Towers.ToArray())
                    build.Update(gameTime);

                foreach (var missile in MissileManager.Missiles.ToArray())
                    missile.Update(gameTime);

                _collisionDetection.DetectCollision();
                _enemyManager.PeriodicallySpawnEnemy(gameTime);
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

            // todo: move to separate class -> DrawHudClass?
            // draw gold.
            spriteBatch.DrawString(_font, "Gold : " + Level.Gold.ToString(), new Vector2(15, 10), Color.Black);

            // draw wave counter.
            spriteBatch.DrawString(_font, "Wave: " + LevelStatsHelper.WaveCounter + "/"
                + LevelStatsHelper.Level1.AmountOfWaves, new Vector2(100, 10), Color.Black);

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
            // EnemyManager.GenerateSkeleton();
            // el2 = EnemyManager.GenerateSkeleton();
            //skel2.Position = new Vector2(Game1.ScreenWidth - 400, Game1.ScreenHeight / 2);

            // _levelStarted = false;
        }

        void Reset()
        {
            _enemyManager.Reset();
            _missileManager.Reset();
        }
    }
}
