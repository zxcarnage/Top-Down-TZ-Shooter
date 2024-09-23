using Dummies;
using ScriptableObjects;
using Utils;

namespace Models.WeaponModel
{
    public class WeaponModel
    {
        public WeaponModel(WeaponConfig weaponConfig)
        {
            InvariantChecker.CheckObjectInvariant<WeaponModel>(weaponConfig);
            FireRate = weaponConfig.FireRate;
            Damage = weaponConfig.Damage;
            ProjectileSpeed = weaponConfig.ProjectileSpeed;
        }
        public float FireRate { get; private set; }
        public float Damage { get; private set; }
        public float ProjectileSpeed { get; private set; }
    }
}