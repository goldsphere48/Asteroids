using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class GameController : Component, IGameState
    {
        public bool GameStoped 
        {
            get => _gameStoped = true;
            set
            {
                _gameStoped = value;
                if (_gameStoped)
                {
                    GameOver?.Invoke();
                } else
                {
                    GameStart?.Invoke();
                }
            }
        }
        public event Action GameOver;
        public event Action GameStart;

        private Vector2 Window => new Vector2(
            GraphicsDevice.PresentationParameters.BackBufferWidth,
            GraphicsDevice.PresentationParameters.BackBufferHeight
        );

        [InsertComponent(From = "StarShip")] private Health _health;
        [InsertComponent(From = "StarShip")] private StarShipController _shipController;
        [InsertComponent(From = "Spawner")] private EnemySpawner _spawner;
        [InsertGameObject("RestartPanel")] private GameObject _restartPanel;
        private bool _gameStoped;

        public void Restart()
        {
            GameStoped = false;
            _spawner.Enabled = true;
            _shipController.Enabled = true;
            _restartPanel.Enabled = false;
            _health.HealthCount = 3;
        }

        private void Start()
        {
            _health.HealthEnded += OnHealthEnded;
        }

        private void OnHealthEnded()
        {
            _spawner.Enabled = false;
            _shipController.Enabled = false;
            var gameOverText = _restartPanel.GetComponentInChildren<TextRenderer>();
            gameOverText.Text = "Game is over!";
            _restartPanel.Transform.Position = new Vector2(Window.X / 2 - gameOverText.Size.X / 2, Window.Y / 2 - gameOverText.Size.Y / 2);
            _restartPanel.Enabled = true;
            GameStoped = true;
        }
    }
}
