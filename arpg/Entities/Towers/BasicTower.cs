using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef;
using towerdef.Entities.Towers;
using towerdef.Managers;
using towerdef.Sprites;

namespace arpg.Entities.Towers
{
    public class BasicTower : Sprite
    {
        private float _timer = 0f;
        private MissileManager _missileManager;

        public BasicTower(Texture2D texture, MissileManager missileManager) : base(texture)
        {
            _missileManager = missileManager;
            Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > Missile.ShootInteval)
            {
                Console.WriteLine(_timer);
                _timer = 0f;
                Shoot(sprites);
            }

            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        private void Shoot(List<Sprite> sprites)
        {
            var missile = _missileManager.Generate();
            missile.Position = new Vector2(this.Position.X + (_texture.Width / 2), this.Position.Y);
            missile.Direction = this.Direction;
            missile.Parent = this;

            sprites.Add(missile);
        }
    }
}
