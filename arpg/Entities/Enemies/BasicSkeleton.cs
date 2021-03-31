using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using towerdef.Sprites;

namespace towerdef.Entities.Enemies
{
    public class BasicSkeleton : Enemy
    {
        public int HealthPoints { get; set; }

        public BasicSkeleton(Texture2D texture) : base(texture)
        {
            HealthPoints = 4;
            Position = new Vector2(Game1.ScreenWidth - 150, Game1.ScreenHeight / 2);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
