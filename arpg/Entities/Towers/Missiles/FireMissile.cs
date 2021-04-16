using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Sprites;

namespace towerdef.Entities.Towers.Missiles
{
    public class FireMissile : Missile
    {
        public static float DamageRadius = 100;

        public FireMissile(Texture2D texture, Sprite parent) : base(texture, parent)
        {
            LinearVelocity = 2.5f;
            Damage = 80;
            FireRange = 300;

            HasSpecialAbility = true;
            DamageRadius = 100;

            TargetRandomEnemy();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

    }
}
