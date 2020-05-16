using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;

namespace Asteroids.Components
{
    internal class EnemyController : Component
    {
        [InsertComponent(From = "StarShip")] private Transform _starShipTransform;
        [InsertComponent] private TargetFollower _follower;

        public void Update()
        {
            _follower.Follow(_starShipTransform.Position, Vector2.One);
        }
    }
}