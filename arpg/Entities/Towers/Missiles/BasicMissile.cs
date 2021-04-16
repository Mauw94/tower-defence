using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Sprites;

namespace towerdef.Entities.Towers.Missiles
{
    public class BasicMissile : Missile
    {
        public BasicMissile(Texture2D texture, Sprite parent) : base(texture, parent)
        {
            LinearVelocity = 5f;
            Damage = 50;
            FireRange = 500;

            TargetRandomEnemy();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
