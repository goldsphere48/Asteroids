using Asteroids.Actors;
using Microsoft.Xna.Framework;
using MonoChrome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class EnemySpawner : Component
    {
        private Vector2 _zone = Vector2.Zero;
        private double _timerCounter = 0;
        private double _timeToSpawn = 4;
        private Random _random = new Random();

        private void Start()
        {
            _zone.X = GraphicsDevice.PresentationParameters.BackBufferWidth;
            _zone.Y = GraphicsDevice.PresentationParameters.BackBufferHeight;
        }

        private void SpawnEnemy()
        {
            var enemy = ActorFactory.CreateEnemy();
            enemy.Transform.Parent = Transform;
            enemy.Transform.Position = new Vector2(_random.Next((int)_zone.X),  _random.Next((int)_zone.Y));
            Scene.Add(enemy);
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
    }
}
