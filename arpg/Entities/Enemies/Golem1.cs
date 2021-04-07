using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace towerdef.Entities.Enemies
{
    public class Golem1 : Enemy
    {
        public Golem1(List<Texture2D> animationTextures) 
            : base(animationTextures)
        {
            MaxHealthPoints = 150;
            HealthPoints = MaxHealthPoints;
            Damage = 10;
            LinearVelocity = 0.5f;
            Position = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight / 2);
            DropsGold = 50;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 direction = new Vector2(0, Game1.ScreenHeight / 2) - Position;
            direction.Normalize();
            Position += direction * LinearVelocity;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
