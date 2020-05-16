using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;
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
        [InsertComponent(From = "Score", Required = true)] private Score _score;
        private Vector2 _direction;

        public Bullet(Vector2 direction)
        {
            _direction = direction;
        }

        private void Start()
        {
            GetComponent<SpriteRenderer>().BecomeInvisible += BecomeInvisible;
        }

        private void BecomeInvisible(Renderer obj)
        {
            Destroy(GameObject);
        }

        private void OnCollision(Collision collision)
        {
            if (collision.GameObject.Name == "Enemy")
            {
                _spawner.RemoveEnemy(collision.GameObject);
                Destroy(GameObject);
                _score.IncreasePoints();
            }
        }

        private void Update()
        {
            Transform.Position += Vector2.Multiply(_direction, 8);
        }
    }
}
