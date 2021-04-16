using arpg.Entities.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using towerdef.Entities.Towers;
using towerdef.Helpers;

namespace towerdef.Managers
{
    public class BuildManager
    {
        public static List<Tower> Towers;

        public BuildManager()
        {
            Towers = new List<Tower>();
        }

        public static Tower CreateTower(TowerType type, Texture2D texture, Vector2 position)
        {
            var tower = CreateTowerFromType(type, texture, position);
            Towers.Add(tower);
            
            return tower;
        }

        public static void RemoveLastBuiltTower(int goldRefund)
        {
            if (Towers.Count > 0)
            {
                Towers.Remove(Towers.Last());
                Level.AddGold(goldRefund);
            }
        }

        static Tower CreateTowerFromType(TowerType type, Texture2D texture, Vector2 position)
        {
            return type switch 
            {
                TowerType.Basic => new BasicTower(texture, position),
                TowerType.Fire => new FireTower(texture, position),
                _ => null,
            };
        }
    }
}
