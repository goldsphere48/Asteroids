using Asteroids.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoChrome.Core;

namespace Asteroids.Components
{
    internal class Gun : Component
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