using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Sprites;

namespace towerdef.Entities.Enemies
{
    public class Enemy : Sprite
    {
        public int HealthPoints { get; set; }
        public int Damage { get; set; }

        public Enemy(Texture2D texture) : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                IsRemoved = true;
            }

            base.Update(gameTime);
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public bool IsAlive()
        {
            return HealthPoints > 0;
        }
    }
}