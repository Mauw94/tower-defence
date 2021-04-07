using arpg.Entities.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using towerdef.Entities;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.Levels
{
    public class LevelBuilderHUD
    {
        // example tower to draw in the build options.
        private Sprite _exampleTower;
        // sprite that is being dragged to location.
        private Sprite _draggedSprite;

        private readonly int xPosHud = 20;
        private readonly int yPosHud = 30;

        // rectangle around the select box.
        private Rectangle _hudSelectBoxRec;
        // rectangle around the undo button.
        private Rectangle _undoButtonRec;

        private Vector2 _mousePos;

        private bool _dragging;

        protected MouseState _currentMouseState;
        protected MouseState _previouseMouseState;

        public LevelBuilderHUD()
        {
            _hudSelectBoxRec = new Rectangle(xPosHud, yPosHud, TextureHelper.HudTexture.Width, TextureHelper.HudTexture.Height);
            _undoButtonRec = new Rectangle(xPosHud, yPosHud + _hudSelectBoxRec.Height, TextureHelper.UndoButtonTexture.Width, TextureHelper.UndoButtonTexture.Height);

            _exampleTower = new Sprite(TextureHelper.BasicTowerTexture);
            _exampleTower.Position = new Vector2(
                _hudSelectBoxRec.Width / 2 + _exampleTower.Rectangle.Width / 2, 
                _hudSelectBoxRec.Height / 2 + _exampleTower.Rectangle.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            _previouseMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mousePos = Mouse.GetState().Position.ToVector2();

            // clicked on undo button.
            if (_currentMouseState.LeftButton == ButtonState.Pressed 
                && _previouseMouseState.LeftButton == ButtonState.Released
                && _undoButtonRec.Contains(_currentMouseState.Position))
            {
                BuildManager.RemoveLastBuiltTower();
            }

            // clicked on basic tower.
            if (!_dragging)
            {
                if (_currentMouseState.LeftButton == ButtonState.Pressed
                    && _previouseMouseState.LeftButton == ButtonState.Released
                    && _hudSelectBoxRec.Contains(_currentMouseState.Position))
                {
                    _dragging = true;
                    CreateNewTower();
                }
            }

            if (_dragging)
            {
                _draggedSprite.Position = _mousePos;

                if (_currentMouseState.LeftButton == ButtonState.Released
                    && _previouseMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (Level.Buy(BasicTower.Cost))
                        BuildManager.CreateTower(TextureHelper.BasicTowerTexture, _mousePos);
                    else
                        // todo: sent event that tower cannot be build.
                        Console.WriteLine("not enough cold to buy tower.");

                    _draggedSprite = null;
                    _dragging = false;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureHelper.UndoButtonTexture, new Vector2(xPosHud, yPosHud + _hudSelectBoxRec.Height), Color.Black);
            spriteBatch.Draw(TextureHelper.HudTexture, new Vector2(xPosHud, yPosHud), Color.Black);

            _exampleTower.Draw(gameTime, spriteBatch);

            if (_dragging)
            {
                _draggedSprite.Draw(gameTime, spriteBatch);
            }
        }

        void CreateNewTower()
        {
            _draggedSprite = _exampleTower.Clone() as Sprite;
        }
    }
}
