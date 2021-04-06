using Microsoft.Xna.Framework;
using towerdef.Sprites;

namespace towerdef.Helpers
{
    public class LevelStatsHelper
    {
        public class Level1
        {
            public static float EnemySpawnTimer = 3f;
            public static int WaveOneMaxSkeletons = 5;
            public static int AmountOfWaves = 2;
        }
        
        public static int CastleHealth = 100;
        public static bool WaveEnd { get; set; }
        public static int WaveKillCounter { get; set; }
        public static int WaveCounter = 1;

        public static bool EnemyInShootingDistance(Sprite enemy, Sprite tower)
        {
            var distance = Vector2.Distance(enemy.Position, tower.Position);
            if (distance <= 350)
                return true;

            return false;
        }

        public static void IncreaseWaveKillCount()
        {
            WaveKillCounter++;
            if (WaveKillCounter >= Level1.WaveOneMaxSkeletons)
            {
                WaveEnd = true;
                WaveCounter++;
            }
        }

        public static void Reset()
        {
            WaveCounter = 1;
            WaveEnd = false;
        }
    }
}
