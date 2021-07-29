using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using towerdef.Models;

namespace towerdef.Managers
{
    public class AnimationManager
    {
        private float _timer = 0f;

        public Vector2 Position { get; set; }

        public Animation Animation;

        public bool PlayedOnce { get; private set; }

        public AnimationManager(Animation animation)
        {
            Animation = animation;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 origin, float scale)
        {
            spriteBatch.Draw(
                Animation.Textures[Animation.CurrentFrame], 
                Position,
                null,
                Color.White,
                0f,
                origin,
                scale,
                SpriteEffects.FlipHorizontally, 0);
        }

        public void Play(Animation animation)
        {
            if (Animation == animation)
                return;

            Animation = animation;
            Animation.CurrentFrame = 0;
            _timer = 0f;
        }

        public void Stop()
        {
            Animation.CurrentFrame = 0;
            _timer = 0f;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float) gameTime.ElapsedGameTime.TotalSeconds;

            if (!(_timer > Animation.FrameSpeed)) return;
            _timer = 0f;
            Animation.CurrentFrame++;

            if (Animation.CurrentFrame < Animation.FrameCount) return;
            PlayedOnce = true;
            Animation.CurrentFrame = 0;
        }
    }
}
