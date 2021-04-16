using Microsoft.Xna.Framework;
using towerdef.Entities.Towers.Missiles;
using towerdef.Sprites;

namespace towerdef.Helpers
{
    public class Level
    {
        public class Level1
        {
            public static float EnemySpawnTimer = 2.5f;
            public static int EnemiesToSpawn = 10;
            public static int Waves = 2;
            public static int Health = 50;
            public static int Gold = 500;
        }
        
        public static bool WaveEnd { get; set; }
        public static int WaveKillCounter { get; set; }
        public static int WaveCounter = 1;

        public static bool EnemyInShootingDistance(Sprite enemy, Missile missile)
        {
            var distance = Vector2.Distance(enemy.Position, missile.Parent.Position);
            if (distance <= missile.FireRange)
                return true;

            return false;
        }

        public static void IncreaseWaveKillCount()
        {
            WaveKillCounter++;
            if (WaveKillCounter >= Level1.EnemiesToSpawn)
            {
                WaveEnd = true;
                WaveCounter++;
            }
        }

        public static bool Buy(int cost)
        {
            if (Level1.Gold >= cost)
            {
                Level1.Gold -= cost;
                return true;
            }
            return false;
        }

        public static void AddGold(int gold)
        {
            Level1.Gold += gold;
        }

        public static void Reset()
        {
            WaveCounter = 1;
            WaveEnd = false;
            WaveKillCounter = 0;
        }
    }
}
