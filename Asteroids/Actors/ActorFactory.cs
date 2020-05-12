using Asteroids.Components;
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
            var button = Entity.Create(name,
                new BoxCollider2D(),
                new ButtonController(),
                new SpriteRenderer
                {
                    Texture = Content.Load<Texture2D>(textureName)
                },
                new DebugRenderer());
            Entity.Synchronize();
            return button;
        }
    }
}
