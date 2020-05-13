using Asteroids.Actors;
using Asteroids.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoChrome.Core;
using MonoChrome.Core.Components;
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
    internal class MainMenuScene : Scene
    {
        private Vector2 Window => new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth,
               GraphicsDevice.PresentationParameters.BackBufferHeight);

        private GameObject _startButton;
        private GameObject _exitButton;

        public override void Setup()
        {
            _startButton = CreateCenterButton("play", new Vector2(0, -50), OnStartClick);
            _exitButton = CreateCenterButton("exit", new Vector2(0, 50), () => Game.Exit());
        }

        private GameObject CreateCenterButton(string name, Vector2 position, Action onClick)
        {
            var button = ActorFactory.CreateButton(name, name);
            Entity.Synchronize();
            Add(button);
            var box = button.GetComponent<BoxCollider2D>().Bounds;
            var center = GetCenter(box);
            button.GetComponent<ButtonController>().OnClick = onClick;
            button.Transform.Position = new Vector2(center.X + position.X, center.Y + position.Y);
            return button;
        }
        private Vector2 GetCenter(Rectangle box)
        {
            return new Vector2(
                Window.X / 2 - box.Width / 2,
                Window.Y / 2 - box.Height / 2
            );
        }
        private void OnStartClick()
        {
            SceneManager.Instance.LoadScene<GameScene>();
            SceneManager.Instance.SetActiveScene<GameScene>();
        }
    }
}