using Asteroids.Scenes;
using Microsoft.Xna.Framework.Input;
using MonoChrome.Core;
using MonoChrome.SceneSystem;
using MonoChrome.SceneSystem.Input;

namespace Asteroids.Components
{
    internal class ReturnToMenuController : Component, IKeyboardHandler
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