using Microsoft.Xna.Framework;
using System.Collections.Generic;
using towerdef.Entities;
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

            if (_timer > LevelStatsHelper.Level1.EnemySpawnTimer 
                && _spawnedEnemies <= LevelStatsHelper.Level1.WaveOneMaxSkeletons)
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
            if (!enemy.IsAlive())
            {
                Remove(enemy);
                LevelStatsHelper.IncreaseWaveKillCount();
                Level.AddGold(enemy.DropsGold);
            }
        }
    }
}