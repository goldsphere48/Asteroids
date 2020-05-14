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
    class EnemyController : Component
    {
        [InsertComponent(From = "StarShip")] private Transform _starShipTransform;
        [InsertComponent] TargetFollower _follower;
        public void Update()
        {
            _follower.Follow(_starShipTransform.Position, Vector2.One);
        }
    }
}
