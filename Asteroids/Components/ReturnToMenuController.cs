using Asteroids.Scenes;
using Microsoft.Xna.Framework.Input;
using MonoChrome.Core;
using MonoChrome.SceneSystem;
using MonoChrome.SceneSystem.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class ReturnToMenuController : Component, IKeyboardHandler
    {
        public void KeyboardHandle(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Escape))
            {
                SceneManager.Instance.UnloadScene<GameScene>();
                SceneManager.Instance.SetActiveScene<MainMenuScene>();
            }
        }
    }
}
