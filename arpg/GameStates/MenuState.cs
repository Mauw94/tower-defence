using towerdef.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using towerdef.Sprites;

namespace towerdef.GameStates
{
    public class MenuState : State
    {
        private List<Component> _components;

        public MenuState(Game1 game, ContentManager content)
            : base(game, content)
        {

        }

        public override void LoadContent()
        {
            var buttonTexture = _content.Load<Texture2D>("button");
            var buttonFont = _content.Load<SpriteFont>("game");

            _components = new List<Component>()
            {
                new Sprite(_content.Load<Texture2D>("bg"))
                {
                    Layer = 0f,
                    Position = new Vector2(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2)
                },
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Play",
                    Position = new Vector2(Game1.ScreenWidth / 2, 400),
                    Click = new EventHandler(Button_Play_Clicked),
                    Layer = 0.1f
                },
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Choose picker",
                    Position = new Vector2(Game1.ScreenWidth / 2, 440),
                    Click = new EventHandler(Button_LevelPicker_Clicked),
                    Layer = 0.1f
                },
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Settings",
                    Position = new Vector2(Game1.ScreenWidth / 2, 480),
                    Click = new EventHandler(Button_Settings_Clicked),
                    Layer = 0.1f
                },
                new Button(buttonTexture, buttonFont)
                {
                    Text = "Quit",
                    Position = new Vector2(Game1.ScreenWidth / 2, 520),
                    Click = new EventHandler(Button_Quit_Clicked),
                    Layer = 0.1f
                },
            };
        }

        private void Button_LevelPicker_Clicked(object sender, EventArgs e)
        {
            _game.ChangeState(new LevelPickerState(_game, _content));
        }

        private void Button_Play_Clicked(object sender, EventArgs args)
        {
            _game.ChangeState(new Level1State(_game, _content));
        }

        private void Button_Settings_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void Button_Quit_Clicked(object sender, EventArgs e)
        {
            _game.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
