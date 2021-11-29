using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using towerdef.Main;

namespace towerdef.GameStates
{
    public class Level2State : BaseLevelState
    {
        public Level2State(TowerDefence game, ContentManager content, SessionStorageProvider sessionStorageProvider)
        : base(game, content, sessionStorageProvider)
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            
            spriteBatch.Begin();
            var hud = new Hud(spriteBatch);
            hud.DrawString(_font, "this is level 2", new Vector2(500, 100), Color.White);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            base.PostUpdate(gameTime);
        }
    }
}