﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace towerdef.Helpers.EventQueue
{
    public class EventMessageQueue
    {
        public static Queue<QueueMessage> Messages { get; set; }

        private float _timer;
        private string _message = string.Empty;
        private bool _noMessagesToShow = true;
        private QueueMessage _currentMessage;

        public EventMessageQueue()
        {
            Messages = new Queue<QueueMessage>();
        }

        public void DisplayMessages(GameTime gameTime, SpriteBatch spriteBatch, SpriteFont font)
        {
            if (_noMessagesToShow)
                _currentMessage = Messages.Count > 0 ? Messages.Dequeue() : null;

            if (_currentMessage != null)
            {
                _noMessagesToShow = false;
                _message = _currentMessage.Message;
                _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                spriteBatch.DrawString(font, _message, new Vector2(TowerDefence.ScreenWidth / 2, TowerDefence.ScreenHeight / 2), Color.Black);

                if (_timer >= _currentMessage.DisplayTime)
                {
                    _timer = 0f;
                    _message = string.Empty;
                    _noMessagesToShow = true;
                }
            }
        }

        public static void Add(QueueMessage message)
        {
            Messages.Enqueue(message);
        }
    }
}
