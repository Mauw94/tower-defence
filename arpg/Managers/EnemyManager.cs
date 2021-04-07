using Microsoft.Xna.Framework;
using System.Collections.Generic;
using towerdef.Entities;
using towerdef.Entities.Enemies;
using towerdef.Helpers;
using towerdef.Models;

namespace towerdef.Managers
{
    public class EnemyManager : IGameManager
    {
        public static List<Enemy> Enemies;

        private float _timer = 0f;

        private int _spawnedEnemies;

        private static Dictionary<string, Animation> _animations;

        public EnemyManager(Dictionary<string, Animation> animations)
        {
            Enemies = new List<Enemy>();
            _animations = animations;
        }

        public static BasicGolem GenerateSkeleton()
        {
            var skeleton = new BasicGolem(_animations);
            Enemies.Add(skeleton);

            return skeleton;
        }

        public void PeriodicallySpawnEnemy(GameTime gameTime)
        {
            _timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > LevelStatsHelper.Level1.EnemySpawnTimer 
                && _spawnedEnemies <= LevelStatsHelper.Level1.WaveOneMaxSkeletons)
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
            {
                Remove(enemy);
                LevelStatsHelper.IncreaseWaveKillCount();
                Level.AddGold(enemy.DropsGold);
            }
        }
    }
}