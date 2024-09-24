using Models.WeaponModel;
using Utils;
using Views.Enemy;

namespace Presenters.Projectile
{
    public class ProjectileDamagePresenter
    {
        private readonly WeaponModel _weaponModel;
        
        public ProjectileDamagePresenter(WeaponModel weaponModel)
        {
            InvariantChecker.CheckObjectInvariant<ProjectileDamagePresenter>();

            _weaponModel = weaponModel;
        }

        public void ApplyDamage(EnemyView enemyView)
        {
            enemyView.TakeDamage(_weaponModel.Damage);
        }
    }
}