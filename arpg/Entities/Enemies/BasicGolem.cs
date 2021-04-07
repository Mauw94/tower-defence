using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace towerdef.Entities.Enemies
{
    public class BasicGolem : Enemy
    {
        public BasicGolem() 
            : base()
        {
            MaxHealthPoints = 150;
            HealthPoints = MaxHealthPoints;
            Damage = 10;
            LinearVelocity = 0.5f;
            Position = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight / 2);
            DropsGold = 150;
        }

        public override void Update(GameTime gameTime)
        {
            var goTo = new Vector2(0, Game1.ScreenHeight / 2);
            Vector2 direction = goTo - Position;
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
