using Asteroids.Actors;
using Microsoft.Xna.Framework;
using MonoChrome.Core;
using MonoChrome.Core.Components;

namespace Asteroids.Components
{
    internal class Healthbar : Component
    {
        public Health Health { private get; set; }
        private GameObject[] _hearts;

        private void Start()
        {
            _hearts = new GameObject[Health.MaxHealthCount];
            for (int i = 0; i < Health.MaxHealthCount; ++i)
            {
                InitHeart(i);
            }
            Health.HealthChanged += OnHealthChanged;
            Health.DamageApplied += OnDamageApplied;
        }

        private void InitHeart(int index)
        {
            _hearts[index] = ActorFactory.CreateHeart();
            _hearts[index].Transform.Parent = Transform;
            Instatiate(_hearts[index]);
            PlaceHeart(_hearts[index], index);
        }

        private void PlaceHeart(GameObject heart, int position)
        {
            var transform = heart.Transform;
            var renderer = heart.GetComponent<SpriteRenderer>();
            transform.LocalPosition = new Vector2(renderer.Size.X * position + 10, 0);
        }

        private void OnHealthChanged(int newHealth)
        {
            for (int i = 0; i < newHealth; ++i)
            {
                _hearts[i].Enabled = true;
            }
        }

        private void OnDamageApplied(int newHealth)
        {
            _hearts[newHealth].Enabled = false;
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= OnHealthChanged;
        }
    }
}