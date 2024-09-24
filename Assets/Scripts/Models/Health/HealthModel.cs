using System;
using ScriptableObjects;
using Utils;

namespace DefaultNamespace.Models.Health
{
    public class HealthModel
    {
        public HealthModel(EnemyConfig enemyConfig)
        {
            InvariantChecker.CheckObjectInvariant<HealthModel>(enemyConfig);
            Health = enemyConfig.Health;
        }

        public float Health { get; private set; }
        public event Action Died;

        public void Decrease(float value)
        {
            if (value >= Health)
            {
                Health = 0f;
                Died?.Invoke();
            }
            else
                Health -= value;
        }

        public void Reset()
        {
            Health = 100f;
        }
    }
}