using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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

        // texture box around build options.
        private Texture2D _hudSelectBox;
        // texture for basic towers.
        private Texture2D _towerTexture;
        // undo button texture.
        private Texture2D _undoButton;

        // rectangle around the select box.
        private Rectangle _hudSelectBoxRec;
        // rectangle around the undo button.
        private Rectangle _undoButtonRec;

        private Vector2 _mousePos;

        private bool _dragging;

        protected MouseState _currentMouseState;
        protected MouseState _previouseMouseState;

        public LevelBuilderHUD(Texture2D hudTexture, Texture2D towerTexture, Texture2D undoButton)
        {
            _hudSelectBox = hudTexture;
            _towerTexture = towerTexture;
            _undoButton = undoButton;

            _hudSelectBoxRec = new Rectangle(xPosHud, yPosHud, _hudSelectBox.Width, _hudSelectBox.Height);
            _undoButtonRec = new Rectangle(xPosHud, yPosHud + _hudSelectBoxRec.Height, _undoButton.Width, _undoButton.Height);

            _exampleTower = new Sprite(_towerTexture);
            _exampleTower.Position = new Vector2(
                _hudSelectBoxRec.Width / 2 + _exampleTower.Rectangle.Width / 2, 
                _hudSelectBoxRec.Height / 2 + _exampleTower.Rectangle.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            _previouseMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
            _mousePos = Mouse.GetState().Position.ToVector2();

            if (_currentMouseState.LeftButton == ButtonState.Pressed 
                && _previouseMouseState.LeftButton == ButtonState.Released
                && _undoButtonRec.Contains(_currentMouseState.Position))
            {
                // todo: remove last added tower.
                Console.WriteLine("removing last added tower");
                BuildManager.RemoveLastBuiltTower();
            }

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
                    BuildManager.CreateTower(_towerTexture, _mousePos);
                    _draggedSprite = null;
                    _dragging = false;
                }
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // todo: draw undo button
            spriteBatch.Draw(_undoButton, new Vector2(xPosHud, yPosHud + _hudSelectBoxRec.Height), Color.Black);
            spriteBatch.Draw(_hudSelectBox, new Vector2(xPosHud, yPosHud), Color.Black);

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
