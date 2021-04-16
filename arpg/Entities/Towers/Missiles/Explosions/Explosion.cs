using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Models;
using towerdef.Sprites;

namespace towerdef.Entities.Towers.Missiles.Explosions
{
    public class Explosion : Sprite
    {
        protected AnimationManager _animationManager;
        protected Animation _animation;

        public Explosion(Vector2 position, Vector2 origin, float scale)
        {
            Position = position;
            Origin = origin;
            Scale = scale;

            _animation = new Animation(TextureHelper.ExplosionTextures, false)
            {
                FrameSpeed = 0.1f
            };
            _animationManager = new AnimationManager(_animation);

            _texture = _animationManager.Animation.Textures[_animationManager.Animation.CurrentFrame];
        }

        public override void Update(GameTime gameTime)
        {
            if (_animationManager.PlayedOnce)
                ExplosionManager.Remove(this);

            _animationManager.Position = Position;
            _animationManager.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _animationManager.Draw(spriteBatch, Origin, Scale);

            base.Draw(gameTime, spriteBatch);
        }
    }
}
