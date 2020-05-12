using Asteroids.Actors;
using Asteroids.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoChrome.SceneSystem;

namespace Asteroids
{
    public class AsteroidGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public AsteroidGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ActorFactory.Content = Content;
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            SceneManager.Instance.GraphicsDevice = graphics.GraphicsDevice;
            SceneManager.Instance.Content = Content;
            SceneManager.Instance.Game = this;
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            SceneManager.Instance.LoadScene<MainMenuScene>();
            SceneManager.Instance.SetActiveScene<MainMenuScene>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            SceneManager.Instance.UnloadScene<MainMenuScene>();
        }


        protected override void Update(GameTime gameTime)
        {
            SceneManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SceneManager.Instance.Draw();
            base.Draw(gameTime);
        }
    }
}
