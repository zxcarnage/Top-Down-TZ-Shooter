using ScriptableObjects;
using Utils;

namespace DefaultNamespace.Models.Damage
{
    public class DamageModel
    {
        public DamageModel(EnemyConfig enemyConfig)
        {
            InvariantChecker.CheckObjectInvariant<DamageModel>(enemyConfig);
            Damage = enemyConfig.Damage;
        }

        public float Damage { get; private set; }
    }
}