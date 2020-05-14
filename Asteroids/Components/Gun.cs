using Asteroids.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoChrome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class Gun : Component
    {
        private double _timerCounter = 0;
        private float _shootSpeed = 0.2f;
        private void Update()
        {
            _timerCounter += Time.DeltaTime;
            if (_timerCounter > _shootSpeed)
            {
                _timerCounter = 0;
                var mouse = Mouse.GetState();
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    var point = mouse.Position.ToVector2();
                    var dir = Vector2.Subtract(point, Transform.Position);
                    dir.Normalize();
                    Instatiate(ActorFactory.CreateBullet(dir, Transform.Position));
                }
            }
        }
    }
}
