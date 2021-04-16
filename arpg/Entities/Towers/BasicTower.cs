using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Entities.Towers;

namespace arpg.Entities.Towers
{
    public class BasicTower : Tower
    {
        public static int Cost = 150;

        public BasicTower(Texture2D texture, Vector2 position) : base(texture, position)
        {
            MissileType = towerdef.Entities.Towers.Missiles.MissileType.Basic;
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
