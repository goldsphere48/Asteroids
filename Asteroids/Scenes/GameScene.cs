using Asteroids.Actors;
using Asteroids.Components;
using Microsoft.Xna.Framework;
using MonoChrome.Core.Components.CollisionDetection;
using MonoChrome.Core.EntityManager;
using MonoChrome.SceneSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Scenes
{
    class GameScene : Scene
    {
        public override void Setup()
        {
            var meta = Entity.Create("Meta", new ReturnToMenuController());
            Entity.Synchronize();
            Add(meta);
            SpawnShip();
            CreateEnemySpawner();
        }

        private void SpawnShip()
        {
            var ship = ActorFactory.CreateShip();
            Add(ship);
            var bounds = ship.GetComponent<BoxCollider2D>().Bounds;
            ship.Transform.Position = new Vector2(300, 300);
            ship.Transform.Origin = new Vector2(bounds.Width / 2, bounds.Height / 2);
        }

        private void CreateEnemySpawner()
        {
            var spawner = Entity.Create("Spawner", new EnemySpawner());
            Entity.Synchronize();
            Add(spawner);
        }
    }
}
