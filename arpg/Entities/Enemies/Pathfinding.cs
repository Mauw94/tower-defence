using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace towerdef.Entities.Enemies
{
    public class Pathfinding
    {
        public List<CoordinatePoint> CoordinatesLevel1;

        private int internalCounter = 0;

        public Pathfinding()
        {
            CoordinatesLevel1 = new List<CoordinatePoint>();

            CoordinatesLevel1.Add(
                new CoordinatePoint
                (new Vector2(-(TowerDefence.ScreenWidth - 200), -(TowerDefence.ScreenHeight / 2))));

            CoordinatesLevel1.Add(
                new CoordinatePoint(
                    new Vector2(-200, -200)));

            CoordinatesLevel1.Add(
                new CoordinatePoint(
                    new Vector2(-600, -600)));
        }

        public Vector2 GetNextPoint()
        {
            var coordinatePoints = CoordinatesLevel1.ToArray();
            var nextCoordinate = coordinatePoints[internalCounter].Point;
            internalCounter++;

            Console.WriteLine("##NEXT COORDINATE##");
            Console.WriteLine(nextCoordinate);

            return nextCoordinate;
        }

        public Vector2 MakeCoordinatePositive(Vector2 coordinate)
        {
            coordinate.X *= -1;
            coordinate.Y *= -1;

            return coordinate;
        }
    }
}