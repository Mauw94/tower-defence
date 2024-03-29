﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace towerdef.Sprites
{
    public class Sprite : Component, ICloneable
    {
        protected Texture2D _texture;
        protected float _rotation;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        protected MouseState _currentMouseState;
        protected MouseState _previouseMouseState;

        public Vector2 Position;
        public Vector2 Origin;
        public Vector2 Direction;

        public float RotationVelocity = 2.3f;
        public float LinearVelocity = 3.5f;
        public float Scale = 1f;
        public float Layer;

        public Sprite Parent;

        public bool IsRemoved = false;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 
                    _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;

            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public Sprite()
        {
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _rotation, Origin, Scale, SpriteEffects.FlipHorizontally, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
