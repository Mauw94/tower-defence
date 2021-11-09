using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace towerdef.Entities.Enemies
{
    public class Golem1 : Enemy
    {
        private Pathfinding _pathfinding { get; set; }
        private int counter = 0;
        private float distance;
        private CoordinatePoint[] coordinatesArray;
        private bool moving = false;
        private Vector2 startPos;
        private Vector2 nextPoint;

        public Golem1(List<Texture2D> animationTextures, Pathfinding pathfinding)
            : base(animationTextures)
        {
            MaxHealthPoints = 150;
            HealthPoints = MaxHealthPoints;
            Damage = 10;
            LinearVelocity = 0.5f;
            Position = new Vector2(TowerDefence.ScreenWidth, TowerDefence.ScreenHeight / 2);
            DropsGold = 50;

            startPos = Position;

            _pathfinding = pathfinding;
            coordinatesArray = new CoordinatePoint[_pathfinding.CoordinatesLevel1.Count - 1];
            coordinatesArray = _pathfinding.CoordinatesLevel1.ToArray();
                        
            nextPoint = GetNextCoordinate();
        }

        public override void Update(GameTime gameTime)
        {
            // todo: move logic.
            if (moving)
            {                    
                nextPoint.Normalize();
                Position += nextPoint * LinearVelocity;
                var newDistance = Vector2.Distance(startPos, Position);
                Console.WriteLine(newDistance);
                if (Vector2.Distance(startPos, Position) >= distance)
                {
                    Console.WriteLine("point reached");
                    moving = false;
                    _animationManager.Stop();
                }
            }
            base.Update(gameTime);
        }

        private Vector2 GetNextCoordinate()
        {
            var nextCoordinate = coordinatesArray[counter];
            distance = Vector2.Distance(Position, PositiveCoordinate(nextCoordinate.Point));
            moving = true;
            Console.WriteLine("###########");
            Console.WriteLine(distance);

            return nextCoordinate.Point;
        }

        private Vector2 PositiveCoordinate(Vector2 point)
        {
            point.X *= -1;
            point.Y *= -1;

            return point;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
