using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;
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

        public void KeyboardHandle(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.W))
            {
                var mouse = Mouse.GetState().Position.ToVector2();
                _transform.MoveTowards(mouse, new Vector2(2, 2));
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
