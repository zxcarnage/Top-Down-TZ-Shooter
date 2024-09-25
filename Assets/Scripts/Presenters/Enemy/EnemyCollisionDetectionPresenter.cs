using DefaultNamespace.Models.Health;
using Models.WeaponModel;
using Utils;

namespace DefaultNamespace.Presenters.Enemy
{
    public class EnemyCollisionDetectionPresenter
    {
        private readonly WeaponModel _weaponModel;
        private readonly HealthModel _healthModel;

        public EnemyCollisionDetectionPresenter(WeaponModel weaponModel, HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant<EnemyCollisionDetectionPresenter>(weaponModel,healthModel);

            _weaponModel = weaponModel;
            _healthModel = healthModel;
        }

        public void ApplyDamage()
        {
            _healthModel.Decrease(_weaponModel.Damage);
        }
    }
}