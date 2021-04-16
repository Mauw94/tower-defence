using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Sprites;

namespace towerdef.Entities.Towers.Missiles
{
    public class FireMissile : Missile
    {
        public float DamageRadius;

        public FireMissile(Texture2D texture, Sprite parent) : base(texture, parent)
        {
            ShootInteval = 5f;
            LinearVelocity = 5f;
            Damage = 80;

            HasSpecialAbility = true;
            DamageRadius = 30;
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
