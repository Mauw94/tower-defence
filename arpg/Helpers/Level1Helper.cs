using Microsoft.Xna.Framework;
using towerdef.Sprites;

namespace towerdef.Helpers
{
    public class Level1Helper
    {
        /// <summary>
        /// Wave one.
        /// </summary>
        public static float SkeletonSpawnTimer = 3f;
        public static int WaveOneMaxSkeletons = 10;
        
        public static int CastleHealth = 100;
        |public static int AmountOfWaves = 5;

        public static bool WaveEnd { get; set; }
        public static int WaveKillCount { get; set; }

        public static bool EnemyInShootingDistance(Sprite enemy, Sprite tower)
        {
            var distance = Vector2.Distance(enemy.Position, tower.Position);
            if (distance <= 350)
                return true;

            return false;
        }

        public static void IncreaseWaveKillCount()
        {
            WaveKillCount++;
            if (WaveKillCount >= WaveOneMaxSkeletons)
                WaveEnd = true;
        }
    }
}
