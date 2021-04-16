using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Entities.Towers.Missiles;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.Entities.Towers
{
    public abstract class Tower : Sprite
    {
        public MissileType MissileType { get; protected set; }

        private float _timer;

        public Tower(Texture2D texture, Vector2 position) : base(texture)
        {
            Position = position;
        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= ShootIntervalFromType(MissileType))
            {
                _timer = 0f;
                if (EnemyManager.Enemies.Count > 0)
                    Shoot();
                else
                    MissileManager.Missiles.Clear();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        private void Shoot()
        {
            var missile = MissileManager.Generate(this, MissileType);
            missile.Position = new Vector2(this.Position.X + (_texture.Width / 2), this.Position.Y);
            missile.Direction = this.Direction;
        }

        float ShootIntervalFromType(MissileType type)
        {
            return type switch
            {
                MissileType.Basic => 2f,
                MissileType.Fire => 5f,
                MissileType.Frost => 3f,
                _ => 0f
            };
        }
    }
}
