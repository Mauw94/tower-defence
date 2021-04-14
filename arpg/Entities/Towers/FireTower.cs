using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace towerdef.Entities.Towers
{
    public class FireTower : Tower
    {
        public static int Cost = 400;

        public FireTower(Texture2D texture, Vector2 position) : base(texture, position)
        {
            MissileType = Missiles.MissileType.Fire;
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
