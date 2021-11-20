using Microsoft.Xna.Framework;

namespace towerdef.Entities.Enemies
{
    public class CoordinatePoint
    {
        public bool Reached { get; set; } = false;
        public Vector2 Point { get; set; }

        public CoordinatePoint(Vector2 point)
        {
            Point = point;
        }
    }
}