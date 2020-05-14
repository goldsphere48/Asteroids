using Asteroids.Actors;
using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class EnemySpawner : Component
    {
        [InsertComponent(From = "Meta")] private GameController _controller;
        private Vector2 _zone = Vector2.Zero;
        private double _timerCounter = 0;
        private double _timeToSpawn = 4;
        private Random _random = new Random();
        private List<EnemyController> _enemies = new List<EnemyController>();

        public void RemoveEnemy(GameObject enemy)
        {
            _enemies.Remove(enemy.GetComponent<EnemyController>());
            Scene.Destroy(enemy);
        }

        private void Start()
        {
            _zone.X = GraphicsDevice.PresentationParameters.BackBufferWidth;
            _zone.Y = GraphicsDevice.PresentationParameters.BackBufferHeight;
            _controller.GameOver += OnGameOver;
            _controller.GameStart += OnGameStart;
        }

        private void SpawnEnemy()
        {
            var enemy = ActorFactory.CreateEnemy();
            _enemies.Add(enemy.GetComponent<EnemyController>());
            enemy.Transform.Parent = Transform;
            enemy.Transform.Position = new Vector2(_random.Next((int)_zone.X),  _random.Next((int)_zone.Y));
            Scene.Instatiate(enemy);
        }

        private void Update()
        {
            _timerCounter += Time.DeltaTime;
            if (_timerCounter >= _timeToSpawn)
            {
                _timerCounter = 0;
                SpawnEnemy();
            }
        }

        private void OnGameOver()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Enabled = false;
            }
        }

        private void OnGameStart()
        {
            foreach (var enemy in _enemies)
            {
                Scene.Destroy(enemy.GameObject);
            }
            _enemies.Clear();
        }
    }
}
