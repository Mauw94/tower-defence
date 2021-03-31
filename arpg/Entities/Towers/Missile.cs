using System;
using System.Collections.Generic;
using System.Linq;
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
            Damage = 1;
            LinearVelocity = 8f;
            ShootInteval = 1.2f;

            TargetRandomEnemy();
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Vector2 direction = _enemyToTarget.Position - Position;
            direction.Normalize();
            Position += direction * LinearVelocity;

            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        void TargetRandomEnemy()
        {
            // todo: target another enemy when the targeted one dies.
            var enemyIndex = Game1.Random.Next(0, EnemyManager.Enemies.Count);
            Console.WriteLine(enemyIndex);
            _enemyToTarget = EnemyManager.Enemies.ToArray()[enemyIndex];
        }
    }
}