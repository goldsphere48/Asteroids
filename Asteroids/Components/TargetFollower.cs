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
    class TargetFollower : Component
    {
        public event Action Finished;
        [InsertComponent] Transform _transform;

        public void Follow(Vector2 target, Vector2 speed)
        {
            _transform.MoveTowards(target, speed);
            var angle = Math.Atan2(_transform.Position.X - target.X, _transform.Position.Y - target.Y);
            _transform.Angle = -(float)angle;
            if (Vector2.Distance(_transform.Position, target) <= speed.Length())
            {
                Finished?.Invoke();
            }
        }
    }
}
