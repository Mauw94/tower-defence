using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using towerdef;
using towerdef.Entities.Towers;
using towerdef.Managers;
using towerdef.Sprites;

namespace arpg.Entities.Towers
{
    public class BasicTower : Sprite
    {
        private float _timer = 0f;

        public BasicTower(Texture2D texture) : base(texture)
        {
            Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > Missile.ShootInteval)
            {
                _timer = 0f;
                if (EnemyManager.Enemies.Count > 0)
                    Shoot();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        private void Shoot()
        {
            var missile = MissileManager.Generate();
            missile.Position = new Vector2(this.Position.X + (_texture.Width / 2), this.Position.Y);
            missile.Direction = this.Direction;
            missile.Parent = this;
        }
    }
}
