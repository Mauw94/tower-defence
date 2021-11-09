using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace towerdef.Entities.Enemies
{
    public class Pathfinding 
    {
        public List<CoordinatePoint> CoordinatesLevel1;

        public Pathfinding()
        {
            CoordinatesLevel1 = new List<CoordinatePoint>();
            CoordinatesLevel1.Add(
                new CoordinatePoint
                (new Vector2(-(TowerDefence.ScreenWidth - 200), -(TowerDefence.ScreenHeight / 2))));
                
            CoordinatesLevel1.Add(
                new CoordinatePoint(
                    new Vector2(-1800, -500)));
        }
    }
}