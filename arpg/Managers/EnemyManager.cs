using Microsoft.Xna.Framework;
using System.Collections.Generic;
using towerdef.Entities.Enemies;
using towerdef.Helpers;

namespace towerdef.Managers
{
    public class EnemyManager
    {
        public static List<Enemy> Enemies;

        private float _timer = 0f;

        private int _spawnedEnemies;

        public EnemyManager()
        {
            Enemies = new List<Enemy>();
        }

        public static BasicSkeleton GenerateSkeleton()
        {
            var skeleton = new BasicSkeleton(TextureHelper.BasicSkeletonTexture);
            Enemies.Add(skeleton);

            return skeleton;
        }

        public void PeriodicallySpawnEnemy(GameTime gameTime)
        {
            _timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > Level1Helper.SkeletonSpawnTimer 
                && _spawnedEnemies <= Level1Helper.WaveOneMaxSkeletons)
            {
                _timer = 0f;
                _spawnedEnemies++;
                GenerateSkeleton();
            }
        }

        public void Reset()
        {
            Enemies = new List<Enemy>();
            _spawnedEnemies = 0;
        }

        public static void Remove(Enemy enemy)
        {
            if (enemy != null)
                Enemies.Remove(enemy);
        }

        public static void Hit(Enemy enemy, int damage)
        {
            enemy.HealthPoints -= damage;
            if (!enemy.IsAlive())
                Remove(enemy);
        }

        // todo: AI pathing for enemies.
    }
}