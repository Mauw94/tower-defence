
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace towerdef.GameStates
{
    public class Hud
    {
        private SpriteBatch _spriteBatch;

        public Hud(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Draw(Texture2D texture2D, Vector2 vector, Color color)
        {
            _spriteBatch.Draw(texture2D, vector, color);
        }

        public void DrawString(SpriteFont font, string text, Vector2 vector2, Color color)
        {
            _spriteBatch.DrawString(font, text, vector2, color);
        }
    }
}