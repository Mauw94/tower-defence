using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Models;
using towerdef.Sprites;

namespace towerdef.Entities.Enemies
{
    public class Enemy : Sprite
    {
        protected AnimationManager _animationManager;
        protected Animation _animation;

        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int DropsGold { get; set; }
        public new Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y,
                    _texture.Width / (int)(Scale * 100), _texture.Height / (int)(Scale * 100));
            }
        }

        private Rectangle _healthRec;

        public Enemy(Texture2D texture) : base(texture)
        {
        }

        public Enemy() : base()
        {
            Scale = 0.1f;

            _animation = new Animation(TextureHelper.EnemyWalkingTextures);
            _animationManager = new AnimationManager(_animation);
            _animationManager.Play(_animation);

            _texture = _animationManager.Animation.Textures[_animationManager.Animation.CurrentFrame];
            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        public bool IsAlive()
        {
            return HealthPoints > 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                IsRemoved = true;
            }

            if (_animationManager != null)
            {
                _animationManager.Position = Position;
                _animationManager.Update(gameTime);
            }

            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // draw hp bar above enemy.
            double currentHpPercentage =  HealthPoints / (double) MaxHealthPoints * 100.0;
            double hpBar = 50 / 100.0 * currentHpPercentage;

            _healthRec = new Rectangle(
                (int)Position.X - 25, (int)Position.Y - 45, 
                (int) hpBar, 
                10);
            spriteBatch.Draw(TextureHelper.HealthTexture, _healthRec, Color.White);

            if (_animationManager != null)
                _animationManager.Draw(spriteBatch, Origin, Scale);
            else 
                base.Draw(gameTime, spriteBatch);
        }

    }
}