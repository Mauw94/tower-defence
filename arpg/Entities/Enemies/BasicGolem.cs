using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Helpers;

namespace towerdef.Entities.Enemies
{
    public class BasicGolem : Enemy
    {
        private Rectangle _healthRec;

        public BasicGolem(Texture2D texture) : base(texture)
        {
            HealthPoints = 100;
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

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, float scale)
        {
            // draw hp bar
            _healthRec = new Rectangle((int)Position.X - 30, (int)Position.Y - 50 , HealthPoints / 2, 10);
            spriteBatch.Draw(TextureHelper.HealthTexture, _healthRec, Color.White);
            base.Draw(gameTime, spriteBatch, scale);
        }
    }
}
