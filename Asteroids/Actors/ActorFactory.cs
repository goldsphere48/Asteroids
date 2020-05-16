using Asteroids.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoChrome.Core;
using MonoChrome.Core.Components;
using MonoChrome.Core.Components.CollisionDetection;
using MonoChrome.Core.EntityManager;

namespace Asteroids.Actors
{
    internal static class ActorFactory
    {
        public static ContentManager Content;

        public static GameObject CreateButton(string name, string textureName)
        {
            return Entity.Create(name,
                new BoxCollider2D(),
                new ButtonController(),
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>(textureName)
                });
        }

        internal static GameObject CreateHeart()
        {
            return Entity.Create("Heart",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("heart")
                }
            );
        }

        public static GameObject CreateShip()
        {
            return Entity.Create("StarShip",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("ship")
                },
                new BoxCollider2D(),
                new StarShipController(),
                new Gun(),
                new Health
                {
                    MaxHealthCount = 3,
                    HealthCount = 3
                }
            );
        }

        public static GameObject CreateScoreBoard()
        {
            return Entity.Create("Score",
                new TextRenderer
                {
                    SpriteFont = Content.Load<SpriteFont>("font")
                },
                new Score());
        }

        public static GameObject CreateBullet(Vector2 dir, Vector2 position)
        {
            var bullet = Entity.Create("Bullet",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("bullet")
                },
                new Bullet(dir),
                new TargetFollower()
            );
            bullet.Transform.Position = position;
            return bullet;
        }

        public static GameObject CreateEnemy()
        {
            return Entity.Create("Enemy",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("enemy")
                },
                new EnemyController(),
                new TargetFollower(),
                new Health
                {
                    MaxHealthCount = 1,
                    HealthCount = 1
                }
            );
        }

        public static GameObject CreateGameOverText()
        {
            return Entity.Create("GameOverText", new TextRenderer { SpriteFont = Content.Load<SpriteFont>("font") });
        }
    }
}