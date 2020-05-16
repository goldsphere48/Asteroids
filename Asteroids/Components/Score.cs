using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;

namespace Asteroids.Components
{
    internal class Score : Component
    {
        [InsertComponent(From = "Meta")] private GameController _colntroller;
        [InsertComponent] private TextRenderer _text;
        public int Points
        {
            get => _points;
            private set
            {
                UpdateText(value);
                _points = value;
            }
        }

        private int _points = 0;

        private void Awake()
        {
            _colntroller.GameStart += Restart;
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