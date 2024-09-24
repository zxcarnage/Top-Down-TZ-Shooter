using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy config", menuName = "Configs/Enemy", order = 0)]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField] private float _health;
        [SerializeField] private float _damage;

        public float Health => _health;
        public float Damage => _damage;
    }
}