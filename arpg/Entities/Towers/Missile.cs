using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Entities.Enemies;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.Entities.Towers
{
    public class Missile : Sprite
    {
        public static int Damage { get; private set; }
        public static float ShootInteval { get; private set; }

        private Enemy _enemyToTarget;

        public Missile(Texture2D texture) : base(texture)
        {
            // todo: create other types of missiles for different towers.
            // Missile will be super class.
            Damage = 40;
            LinearVelocity = 5f;
            ShootInteval = 2.5f;

            TargetRandomEnemy();
        }

        public override void Update(GameTime gameTime)
        {
            if (_enemyToTarget != null)
            {
                Vector2 direction = _enemyToTarget.Position - Position;
                direction.Normalize();
                Position += direction * LinearVelocity;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        void TargetRandomEnemy()
        {
            // todo: target another enemy when the targeted one dies.
            var enemyIndex = Game1.Random.Next(0, EnemyManager.Enemies.Count);
            _enemyToTarget = EnemyManager.Enemies.ToArray()[enemyIndex];
        }
    }
}