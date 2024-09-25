using System;
using ScriptableObjects;
using Utils;

namespace DefaultNamespace.Models.Health
{
    public class HealthModel
    {
        public HealthModel(CharacterConfig characterConfig)
        {
            InvariantChecker.CheckObjectInvariant<HealthModel>(characterConfig);
            Health = characterConfig.Health;
            MaxHealth = characterConfig.Health;
        }

        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public event Action Died;
        public event Action<float> HealthChanged;

        public void Decrease(float value)
        {
            if (value >= Health)
            {
                Health = 0f;
                Died?.Invoke();
            }
            else
                Health -= value;
            HealthChanged?.Invoke(Health);
        }

        public void Reset()
        {
            Health = 100f;
        }
    }
}