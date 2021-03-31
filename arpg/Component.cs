using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using towerdef.Sprites;

namespace towerdef
{
    public abstract class Component
    {
        public abstract void Update(GameTime gameTime, List<Sprite> sprites);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
