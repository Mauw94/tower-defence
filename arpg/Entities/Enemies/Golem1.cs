using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace towerdef.Entities.Enemies
{
    public class Golem1 : Enemy
    {
        private Pathfinding _pathfinding { get; set; }
        private float _distance;
        private bool _moving = false;
        private Vector2 _startPos;
        private Vector2 _nextCoordinateToGoTo;

        public Golem1(List<Texture2D> animationTextures, Pathfinding pathfinding)
            : base(animationTextures)
        {
            MaxHealthPoints = 150;
            HealthPoints = MaxHealthPoints;
            Damage = 10;
            LinearVelocity = 0.5f;
            Position = new Vector2(TowerDefence.ScreenWidth, TowerDefence.ScreenHeight / 2);
            DropsGold = 50;

            _startPos = Position;
            _pathfinding = pathfinding;
        }

        public override void Update(GameTime gameTime)
        {
            if (_moving)
            {
                _nextCoordinateToGoTo.Normalize();
                Position += _nextCoordinateToGoTo * LinearVelocity;
                if (Vector2.Distance(_startPos, Position) >= _distance)
                {
                    Console.WriteLine("coordinate reached, get next coordinate");
                    _moving = false;
                    _animationManager.Stop();
                }
            }
            else
            {
                NextCoordinate();
            }

            base.Update(gameTime);
        }

        private void NextCoordinate()
        {
            _nextCoordinateToGoTo = _pathfinding.GetNextPoint();
            _startPos = Position;
            _distance = Vector2.Distance(Position, _pathfinding.MakeCoordinatePositive(_nextCoordinateToGoTo));
            _moving = true;
            _animationManager.Play();
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
