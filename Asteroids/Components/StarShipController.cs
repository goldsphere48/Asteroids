using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;
using MonoChrome.Core.Components.CollisionDetection;
using MonoChrome.SceneSystem.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class StarShipController : Component, IKeyboardHandler
    {
        [InsertComponent] private Transform _transform;
        [InsertComponent(From = "Spawner")] private EnemySpawner _spawner;
        [InsertComponent(From = "Meta")] private GameController _colntroller;
        [InsertComponent] private Gun _gun;
        [InsertComponent] private Health _health;

        public void KeyboardHandle(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.W))
            {
                var mouse = Mouse.GetState().Position.ToVector2();
                _transform.MoveTowards(mouse, new Vector2(2, 2));
            }
        }

        private void Awake()
        {
            _colntroller.GameOver += OnGameOver;
            _colntroller.GameStart += OnGameStart;
        }

        public void OnGameOver()
        {
            Enabled = false;
            _gun.Enabled = false;
        }

        public void OnGameStart()
        {
            Enabled = true;
            _gun.Enabled = true;
            Transform.Position = new Vector2(400, 400);
            Transform.Angle = 0;
            _health.HealthCount = 3;
        }

        private void OnCollision(Collision collission)
        {
            if (collission.GameObject.Name == "Enemy")
            {
                _spawner.RemoveEnemy(collission.GameObject);
                this.GetComponent<Health>().ApplyDamage(1);
            }
        }

        private void Update()
        {
            var mouse = Mouse.GetState();
            var angle = Math.Atan2(_transform.Position.X - mouse.Position.X, _transform.Position.Y - mouse.Position.Y);
            _transform.Angle = -(float)angle;
        }
    }
}
