using Dummies;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New weapon", menuName = "Configs/Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private float _fireRate;
        [SerializeField] private float _damage;
        [SerializeField] private float _projectileSpeed;
        
        public float FireRate => _fireRate;
        public float Damage => _damage;
        public float ProjectileSpeed => _projectileSpeed;
    }
}