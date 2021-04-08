using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using towerdef.Entities.Enemies;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.Entities.Towers.Missiles
{
    public abstract class Missile : Sprite
    {
        public static int Damage { get; protected set; }
        public static float ShootInteval = 2f;
        public bool HasSpecialAbility { get; protected set; }

        private Enemy _enemyToTarget;
        // Enemy can do by another missile from another tower before a missile can hit,
        // so we need to check again before hit.
        private Enemy _checkIfAliveOrInRange;

        public Missile(Texture2D texture, Sprite parent) : base(texture)
        {
            Parent = parent;

            TargetRandomEnemy();
        }

        public override void Update(GameTime gameTime)
        {
            if (_enemyToTarget != null) 
                 _checkIfAliveOrInRange = EnemyManager.Enemies
                    .Find(e=>e.GetHashCode() == _enemyToTarget.GetHashCode());
            
            if (_checkIfAliveOrInRange == null)
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
            if (_checkIfAliveOrInRange != null)
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