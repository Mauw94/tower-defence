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
        private CoordinatePoint[] coordinatesArray;

        public Golem1(List<Texture2D> animationTextures, Pathfinding pathfinding)
            : base(animationTextures)
        {
            MaxHealthPoints = 150;
            HealthPoints = MaxHealthPoints;
            Damage = 10;
            LinearVelocity = 0.5f;
            Position = new Vector2(TowerDefence.ScreenWidth, TowerDefence.ScreenHeight / 2);
            DropsGold = 50;

            _pathfinding = pathfinding;
            coordinatesArray = new CoordinatePoint[_pathfinding.CoordinatesLevel1.Count - 1];
            coordinatesArray = _pathfinding.CoordinatesLevel1.ToArray();
        }

        public override void Update(GameTime gameTime)
        {
            // Vector2 direction = new Vector2(0, TowerDefence.ScreenHeight / 2) - Position;
            // direction.Normalize();
            // Position += direction * LinearVelocity;

            Vector2 nextPoint = GetNextCoordinate();
            float distance = Vector2.Distance(Position, nextPoint); 
            nextPoint.Normalize();
            Position += nextPoint * LinearVelocity;

            base.Update(gameTime);
        }

        private Vector2 GetNextCoordinate()
        {
            var nextPoint = coordinatesArray[counter];

            return nextPoint.Point;
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
