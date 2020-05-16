using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class Score : Component
    {
        public int Points
        {
            get => _points;
            private set
            {
                UpdateText(value);
                _points = value;
            }
        }

        [InsertComponent] TextRenderer _text;
        private int _points = 0;

        private void Awake()
        {
            UpdateText(0);
        }

        public void IncreasePoints()
        {
            Points++;
        }

        public void Restart()
        {
            Points = 0;
        }

        private void UpdateText(int count)
        {
            _text.Text = $"Score: {count}";
        }
    }
}
