﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef;
using towerdef.Entities.Towers;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Sprites;

namespace arpg.Entities.Towers
{
    public class BasicTower : Sprite
    {
        public static int Cost = 200;

        private float _timer = 0f;
        
        public BasicTower(Texture2D texture) : base(texture)
        {
            Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var enemy in EnemyManager.Enemies)
            {
                if (LevelStatsHelper.EnemyInShootingDistance(enemy, this))
                {
                    _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (_timer > Missile.ShootInteval)
                    {
                        _timer = 0f;
                        if (EnemyManager.Enemies.Count > 0)
                            Shoot();
                        else
                            MissileManager.Missiles.Clear();
                    }
                }
                
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, float scale)
        {
            base.Draw(gameTime, spriteBatch, scale);
        }

        private void Shoot()
        {
            var missile = MissileManager.Generate(this);
            missile.Position = new Vector2(this.Position.X + (_texture.Width / 2), this.Position.Y);
            missile.Direction = this.Direction;
        }
    }
}
