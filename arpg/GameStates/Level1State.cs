using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using towerdef.Entities.Towers.Missiles.Explosions;
using towerdef.Helpers;
using towerdef.Helpers.EventQueue;
using towerdef.Levels;
using towerdef.Main;
using towerdef.Managers;

namespace towerdef.GameStates
{
    public class Level1State : State
    {
        private Texture2D _gameMap;
        private Texture2D _basicTowerTexture;
        private Texture2D _fireTowerTexture;
        private Texture2D _missileTexture;
        private Texture2D _fireMissileTexture;
        private Texture2D _hudTexture;
        private Texture2D _undoButton;
        private Texture2D _healthTexture;

        private List<Texture2D> _enemy1WalkingTextures;
        private List<Texture2D> _enemy2WalkingTextures;
        private List<Texture2D> _explosionTextures;

        private SpriteFont _font;

        private EnemyManager _enemyManager;
        private MissileManager _missileManager;
        private BuildManager _buildManager;
        private ExplosionManager _explosionManager;

        private LevelBuilderHUD _builderHud;
        private CollisionDetection _collisionDetection;
        private EventMessageQueue _eventMessageQueue;

        private bool _levelStarted = false;

        public Level1State(TowerDefence game, ContentManager content, SessionStorageProvider sessionStorageProvider) 
            : base(game, content, sessionStorageProvider)
        {
        }

        public override void LoadContent()
        {
            // load textures.
            _gameMap = _content.Load<Texture2D>("level1");
            _basicTowerTexture = _content.Load<Texture2D>("tower1");
            _fireTowerTexture = _content.Load<Texture2D>("firetower");
            _missileTexture = _content.Load<Texture2D>("missile");
            _fireMissileTexture = _content.Load<Texture2D>("firemissile");
            _hudTexture = _content.Load<Texture2D>("builderhud");
            _undoButton = _content.Load<Texture2D>("undo");
            _healthTexture = _content.Load<Texture2D>("health");

            // load animation textures.
            _enemy1WalkingTextures = new List<Texture2D>
            {
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_000"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_001"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_002"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_003"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_004"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_005"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_006"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_007"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_008"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_009"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_010"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_011"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_012"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_013"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_014"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_015"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_016"),
                _content.Load<Texture2D>("Golem_01_Walking/Golem_01_Walking_017")
            };
            _enemy2WalkingTextures = new List<Texture2D>
            {
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_000"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_001"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_002"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_003"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_004"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_005"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_006"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_007"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_008"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_009"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_010"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_011"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_012"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_013"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_014"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_015"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_016"),
                _content.Load<Texture2D>("Golem_02_Walking/Golem_02_Walking_017")
            };
            _explosionTextures = new List<Texture2D>
            {
                _content.Load<Texture2D>("Explosion/explosion_1"),
                _content.Load<Texture2D>("Explosion/explosion_2"),
                _content.Load<Texture2D>("Explosion/explosion_3"),
                _content.Load<Texture2D>("Explosion/explosion_4"),
                _content.Load<Texture2D>("Explosion/explosion_5"),
                _content.Load<Texture2D>("Explosion/explosion_6"),
                _content.Load<Texture2D>("Explosion/explosion_7"),
            };

            // load fonts.
            _font = _content.Load<SpriteFont>("game");

            // set textures to use throughout the game.
            TextureHelper.HealthTexture = _healthTexture;
            TextureHelper.BasicTowerTexture = _basicTowerTexture;
            TextureHelper.FireTowerTexture = _fireTowerTexture;
            TextureHelper.HudTexture = _hudTexture;
            TextureHelper.UndoButtonTexture = _undoButton;
            TextureHelper.MissileTexture = _missileTexture;
            TextureHelper.FireMissileTexture = _fireMissileTexture;

            // animation textures
            TextureHelper.Enemy1WalkingTextures = _enemy1WalkingTextures;
            TextureHelper.Enemy2WalkingTextures = _enemy2WalkingTextures;
            TextureHelper.ExplosionTextures = _explosionTextures;

            // initialize managers.
            _enemyManager = new EnemyManager();
            _missileManager = new MissileManager();
            _buildManager = new BuildManager();
            _explosionManager = new ExplosionManager();

            // initialize helpers
            _builderHud = new LevelBuilderHUD();
            _collisionDetection = new CollisionDetection();
            _eventMessageQueue = new EventMessageQueue();

            var storage = _sessionStorageProvider.GetFromSessionStorage(TowerDefence.GameKey);
            storage.GoldEarned = Level.Level1.Gold;

            Init();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _levelStarted = true;
                Level.Reset();
            }

            if (Level.WaveEnd)
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

                foreach (var explosion in ExplosionManager.Explosions.ToArray())
                    explosion.Update(gameTime);

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
            spriteBatch.DrawString(_font, "Gold : " + Level.Level1.Gold.ToString(), 
                new Vector2(15, 10), Color.Black);

            // draw wave counter.
            spriteBatch.DrawString(_font, "Wave: " + Level.WaveCounter + "/"
                + Level.Level1.Waves, new Vector2(100, 10), Color.Black);

            // DEBUG STRINGS.
            spriteBatch.DrawString(_font, "Towers: " + BuildManager.Towers.Count,
                new Vector2(200, 10), Color.Black);
            spriteBatch.DrawString(_font, "Enemies " + EnemyManager.Enemies.Count,
                new Vector2(300, 10), Color.Black); 

            // draw towers that were placed before round start.
            foreach (var build in BuildManager.Towers.ToArray())
                build.Draw(gameTime, spriteBatch);

            // Show event messages.
            _eventMessageQueue.DisplayMessages(gameTime, spriteBatch, _font);

            // draw enemies and missiles being fired.
            if (_levelStarted)
            {
                foreach (var enemy in EnemyManager.Enemies.ToArray())
                    enemy.Draw(gameTime, spriteBatch);
                
                foreach (var missiles in MissileManager.Missiles.ToArray())
                    missiles.Draw(gameTime, spriteBatch);

                foreach (var explosion in ExplosionManager.Explosions.ToArray())
                    explosion.Draw(gameTime, spriteBatch);
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
