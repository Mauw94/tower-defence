using arpg.Entities.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using towerdef.Entities;

namespace towerdef.Managers
{
    public class BuildManager
    {
        public static List<BasicTower> Towers;

        public BuildManager()
        {
            Towers = new List<BasicTower>();
        }

        public static BasicTower CreateTower(Texture2D texture, Vector2 position)
        {
            var tower = new BasicTower(texture)
            {
                Position = position
            };
            Towers.Add(tower);
            
            return tower;
        }

        public static void RemoveLastBuiltTower()
        {
            if (Towers.Count > 0)
            {
                Towers.Remove(Towers.Last());
                Level.AddGold(BasicTower.Cost);
            }
        }
    }
}
