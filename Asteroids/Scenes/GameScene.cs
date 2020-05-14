using Asteroids.Actors;
using Asteroids.Components;
using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Components;
using MonoChrome.Core.Components.CollisionDetection;
using MonoChrome.Core.EntityManager;
using MonoChrome.SceneSystem;
using MonoChrome.SceneSystem.Layers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Scenes
{
    class GameScene : Scene
    {
        private GameObject _starShipController;
        private GameObject _meta;
        private GameObject _spawner;
        private GameObject _healthbar;
        private GameObject _panel;
        private GameObject _text;
        private GameObject _restartButton;

        private Vector2 Window => new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth,
               GraphicsDevice.PresentationParameters.BackBufferHeight);

        public override void Setup()
        {
            _meta = Entity.Create("Meta", new ReturnToMenuController(), new GameController());
            _starShipController = ActorFactory.CreateShip();
            _spawner = Entity.Create("Spawner", new EnemySpawner());
            _healthbar = Entity.Create("Healthbar", new Healthbar());
            _text = ActorFactory.CreateGameOverText();
            _restartButton = ActorFactory.CreateButton("Restart", "restart");
            _panel = Entity.ComposeNew("RestartPanel", _text, _restartButton);
            Entity.Synchronize();
        }

        public override void OnEnable()
        {
            Instatiate(_meta);
            SpawnShip();
            Instatiate(_spawner);
            CreateHealthbar();
            CreateRestrartPanel();
        }


        private void SpawnShip()
        {
            var size = _starShipController.GetComponent<SpriteRenderer>().Size;
            _starShipController.Transform.Position = new Vector2(400, 400);
            _starShipController.Transform.Origin = new Vector2(size.X / 2, size.Y / 2);
            Instatiate(_starShipController);
        }

        private void CreateHealthbar()
        {
            _healthbar.GetComponent<Healthbar>().Health = _starShipController.GetComponent<Health>();
            _healthbar.Transform.Position = new Vector2(500, 30);
            Instatiate(_healthbar);
        }

        private void CreateRestrartPanel()
        {
            _restartButton.GetComponent<ButtonController>().OnClick = _meta.GetComponent<GameController>().Restart;
            var renderer = _restartButton.GetComponent<SpriteRenderer>();
            _text.Transform.LocalPosition = new Vector2(0, -50);
            _restartButton.Transform.LocalPosition = new Vector2(0, 50);
            _panel.Enabled = false;
            Instatiate(_panel);
        }
    }
}
