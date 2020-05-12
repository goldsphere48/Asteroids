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
        [InsertComponent] private Transform _transform;

        public void Update()
        {
            _transform.MoveTowards(_starShipTransform.Position, new Vector2(1, 1));
            var angle = Math.Atan2(_transform.Position.X - _starShipTransform.Position.X, _transform.Position.Y - _starShipTransform.Position.Y);
            _transform.Angle = -(float)angle;
        }
    }
}
