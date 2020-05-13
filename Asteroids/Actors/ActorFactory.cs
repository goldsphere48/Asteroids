using Asteroids.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoChrome.Core;
using MonoChrome.Core.Components;
using MonoChrome.Core.Components.CollisionDetection;
using MonoChrome.Core.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Actors
{
    static class ActorFactory
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
                },
                new DebugRenderer());
        }

        internal static GameObject CreateHeart()
        {
            var heart = Entity.Create("Heart",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("heart")
                }
            );
            Entity.Synchronize();
            return heart;
        }

        public static GameObject CreateShip()
        {
            return Entity.Create("StarShip",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("ship")
                },
                new BoxCollider2D(),
                new DebugRenderer(),
                new StarShipController(),
                new Health 
                { 
                    MaxHealthCount = 3,
                    HealthCount = 3
                }
            );
        }

        public static GameObject CreateEnemy()
        {
            var enemy = Entity.Create("Enemy",
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>("enemy")
                },
                new BoxCollider2D(),
                new DebugRenderer(),
                new EnemyController(),
                new Health
                {
                    MaxHealthCount = 1,
                    HealthCount = 1
                }
            );
            Entity.Synchronize();
            return enemy;
        }

        public static GameObject CreateGameOverText()
        {
            return Entity.Create("GameOverText", new TextRenderer { SpriteFont = Content.Load<SpriteFont>("font")});
        }
    }
}
