using Microsoft.Xna.Framework;
using System.Collections.Generic;
using towerdef.Entities.Enemies;
using towerdef.Helpers;

namespace towerdef.Managers
{
    public class EnemyManager : IGameManager
    {
        public static List<Enemy> Enemies;

        private float _timer = 0f;

        private int _spawnedEnemies;

        public EnemyManager()
        {
            Enemies = new List<Enemy>();
        }

        public static Golem1 GenerateGolem()
        {
            var enemy = new Golem1(TextureHelper.Enemy2WalkingTextures);
            Enemies.Add(enemy);

            return enemy;
        }

        public void PeriodicallySpawnEnemy(GameTime gameTime)
        {
            _timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > Level.Level1.EnemySpawnTimer 
                && _spawnedEnemies <= Level.Level1.WaveOneMaxSkeletons)
            {
                _timer = 0f;
                _spawnedEnemies++;
                GenerateGolem();
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
            CheckEnemyAlive(enemy);
        }

        public static void AoeHit(Enemy enemy, int damage)
        {
            var radius = 100;
            var enemiesInRadius = new List<Enemy>();

            foreach (var e in Enemies)
            {
                if (e == enemy)
                    continue;

                var distance = Vector2.Distance(enemy.Position, e.Position);
                if (distance < radius)
                {
                    enemiesInRadius.Add(e);
                }
            }

            foreach (var e in enemiesInRadius)
            {
                e.HealthPoints -= (int)(damage * 0.7);
                CheckEnemyAlive(e);
            }

            enemy.HealthPoints -= damage;
            CheckEnemyAlive(enemy);
        }

        static void CheckEnemyAlive(Enemy enemy)
        {
            if (!enemy.IsAlive())
            {
                Remove(enemy);
                Level.IncreaseWaveKillCount();
                Level.AddGold(enemy.DropsGold);
            }
        }
    }
}