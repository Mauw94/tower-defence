using System;
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
            public static int EnemiesToSpawn = 1;
            public static int Waves = 1;
            public static int Health = 150;
            public static int Gold = 500;
            public static bool GameOver = false;
            public static bool LevelWon = false;
        }
        
        public static int WaveKillCounter { get; set; }

        public static bool EnemyInShootingDistance(Sprite enemy, Missile missile)
        {
            var distance = Vector2.Distance(enemy.Position, missile.Parent.Position);
            return distance <= missile.FireRange;
        }

        public static void IncreaseWaveKillCount()
        {
            WaveKillCounter++;
            Console.WriteLine("killed enemy");
            if (WaveKillCounter >= Level1.EnemiesToSpawn)
            {
                Level1.LevelWon = true;
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
            WaveKillCounter = 0;
        }
    }
}
