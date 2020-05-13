using MonoChrome.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class Health : Component
    {
        public event Action<int> HealthChanged;
        public event Action HealthEnded;

        public int MaxHealthCount 
        { 
            get => _maxHealthCount; 
            set
            {
                if (value >= 0)
                {
                    _maxHealthCount = value;
                    if (_healthCount > _maxHealthCount)
                    {
                        _healthCount = _maxHealthCount;
                    }
                }
            } 
        }

        public int HealthCount 
        {
            get => _healthCount;
            set
            {
                if (value <= MaxHealthCount && value >= 0)
                {
                    _healthCount = value;
                    HealthChanged?.Invoke(_healthCount);
                    if (_healthCount == 0)
                    {
                        HealthEnded?.Invoke();
                    }
                }
            }
        }

        public void ApplyDamage(int damage)
        {
            if (damage >= 0)
            {
                if (_healthCount - damage >= 0)
                {
                    _healthCount -= damage;
                    if (_healthCount <= 0)
                    {
                        _healthCount = 0;
                        HealthEnded?.Invoke();
                    }
                    HealthChanged?.Invoke(_healthCount);
                }
            }
        }

        private int _healthCount = 0;
        private int _maxHealthCount = 0;
    }
}
