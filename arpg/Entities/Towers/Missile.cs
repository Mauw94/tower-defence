using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using towerdef.Entities.Enemies;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.Entities.Towers
{
    public class Missile : Sprite
    {
        public static int Damage { get; private set; }
        public static float ShootInteval = 3f;

        private Enemy _enemyToTarget;
        private Enemy _checkIfIsAlive;

        public Missile(Texture2D texture, Sprite parent) : base(texture)
        {
            // todo: create other types of missiles for different towers.
            // Missile will be super class.
            Damage = 40;
            LinearVelocity = 5f;
            Parent = parent;

            TargetRandomEnemy();
        }

        public override void Update(GameTime gameTime)
        {
            if (_enemyToTarget != null) 
                 _checkIfIsAlive = EnemyManager.Enemies.Find(e=>e.GetHashCode() == _enemyToTarget.GetHashCode());
            
            if (_checkIfIsAlive == null)
            {
                MissileManager.Remove(this);
                return;
            }

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
            if (_checkIfIsAlive != null)
                base.Draw(gameTime, spriteBatch);
        }

        void TargetRandomEnemy()
        {
            List<Enemy> enemiesInRange = new List<Enemy>();
            foreach (var enemy in EnemyManager.Enemies)
            {
                if (LevelStatsHelper.EnemyInShootingDistance(enemy, this.Parent))
                    enemiesInRange.Add(enemy);
            }

            var enemyIndex = Game1.Random.Next(0, enemiesInRange.Count);
            _enemyToTarget = enemiesInRange.Count > 0 ? enemiesInRange.ToArray()[enemyIndex] : null;
        }
    }
}