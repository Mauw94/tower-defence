using arpg.Entities.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using towerdef.Entities.Towers;
using towerdef.Helpers;
using towerdef.Managers;
using towerdef.Sprites;

namespace towerdef.Levels
{
    public class LevelBuilderHUD
    {
        // example tower to draw in the build options.
        private Sprite _basicTowerExample;
        private Sprite _fireTowerExample;
        // sprite that is being dragged to location.
        private Sprite _draggedSprite;

        private readonly int xPosHud = 20;
        private readonly int yPosHud = 30;

        // rectangle around the select box.
        private Rectangle _basicTowerSelectBox;
        private Rectangle _fireTowerSelectBox;
        // rectangle around the undo button.
        private Rectangle _undoButtonRec;

        private Vector2 _mousePos;

        private bool _dragging;

        private TowerType _towerType;

        protected MouseState _currentMouseState;
        protected MouseState _previouseMouseState;

        public LevelBuilderHUD()
        {
            _undoButtonRec = new Rectangle(xPosHud, yPosHud + _basicTowerSelectBox.Height, TextureHelper.UndoButtonTexture.Width, TextureHelper.UndoButtonTexture.Height);

            // todo: textures not correct.
            _basicTowerSelectBox = new Rectangle(xPosHud, yPosHud, TextureHelper.HudTexture.Width, TextureHelper.HudTexture.Height);
            _fireTowerSelectBox = new Rectangle(xPosHud + _basicTowerSelectBox.Width, yPosHud, TextureHelper.HudTexture.Width, TextureHelper.HudTexture.Height);

            _basicTowerExample = new Sprite(TextureHelper.BasicTowerTexture);
            _basicTowerExample.Position = new Vector2(
                _basicTowerSelectBox.Width / 2 + _basicTowerExample.Rectangle.Width / 2, 
                _basicTowerSelectBox.Height / 2 + _basicTowerExample.Rectangle.Height / 2);

            _fireTowerExample = new Sprite(TextureHelper.FireTowerTexture);
            _fireTowerExample.Position = new Vector2(
                _basicTowerExample.Rectangle.Width + (_fireTowerSelectBox.Width / 2 + _fireTowerExample.Rectangle.Width / 2),
                _fireTowerSelectBox.Height / 2 + _fireTowerExample.Rectangle.Height / 2);
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
            // todo: add type of tower to build and pass to buildmanager.
            if (!_dragging)
            {
                if (_currentMouseState.LeftButton == ButtonState.Pressed
                    && _previouseMouseState.LeftButton == ButtonState.Released
                    && _basicTowerSelectBox.Contains(_currentMouseState.Position))
                {
                    Console.WriteLine("creating basic tower");
                    _dragging = true;
                    _towerType = TowerType.Basic;
                    CreateNewTower(_basicTowerExample);
                }
                else if (_currentMouseState.LeftButton == ButtonState.Pressed
                    && _previouseMouseState.LeftButton == ButtonState.Released
                    && _fireTowerSelectBox.Contains(_currentMouseState.Position))
                {
                    Console.WriteLine("creating fire tower");
                    _dragging = true;
                    _towerType = TowerType.Fire;
                    CreateNewTower(_fireTowerExample);
                }
            }

            if (_dragging)
            {
                _draggedSprite.Position = _mousePos;

                if (_currentMouseState.LeftButton == ButtonState.Released
                    && _previouseMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (Level.Buy(BasicTower.Cost))
                        BuildManager.CreateTower(_towerType, GetTextureFromType(_towerType), _mousePos);
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
            spriteBatch.Draw(TextureHelper.UndoButtonTexture, new Vector2(xPosHud, yPosHud + _basicTowerSelectBox.Height), Color.Black);
            spriteBatch.Draw(TextureHelper.HudTexture, new Vector2(xPosHud, yPosHud), Color.Black);
            spriteBatch.Draw(TextureHelper.HudTexture, new Vector2(xPosHud + _fireTowerSelectBox.Width, yPosHud), Color.Black);

            _basicTowerExample.Draw(gameTime, spriteBatch);
            _fireTowerExample.Draw(gameTime, spriteBatch);

            if (_dragging)
            {
                _draggedSprite.Draw(gameTime, spriteBatch);
            }
        }

        void CreateNewTower(Sprite spriteToClone)
        {
            _draggedSprite = spriteToClone.Clone() as Sprite;
        }

        Texture2D GetTextureFromType(TowerType type)
        {
            return type switch
            {
                TowerType.Basic => TextureHelper.BasicTowerTexture,
                TowerType.Fire => TextureHelper.FireTowerTexture,
                _ => null,
            };
        }
    }
}
