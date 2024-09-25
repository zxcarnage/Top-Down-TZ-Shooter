using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Configs/Enemy", order = 0)]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _attackDelay;
        [SerializeField] private float _attackDistance;


        public float AttackDistance => _attackDistance;
        public float Damage => _damage;
        public float AttackDelay => _attackDelay;
    }
}