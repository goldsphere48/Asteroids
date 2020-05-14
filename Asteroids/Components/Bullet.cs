using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components.CollisionDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class Bullet : Component
    {
        [InsertComponent(From = "Spawner", Required = true)] private EnemySpawner _spawner;
        private Vector2 _direction;

        public Bullet(Vector2 direction)
        {
            _direction = direction;
        }

        private void OnCollision(Collision collision)
        {
            if (collision.GameObject.Name == "Enemy")
            {
                _spawner.RemoveEnemy(collision.GameObject);
                Destroy(GameObject);
            }
        }

        private void Update()
        {
            Transform.Position += Vector2.Multiply(_direction, 8);
            if (Transform.Position.X < 0 || Transform.Position.Y > 0)
            {
                Destroy(GameObject);
            }
        }
    }
}
