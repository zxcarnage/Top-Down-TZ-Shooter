using DefaultNamespace.Models.Health;
using DefaultNamespace.Presenters.Enemy;
using Dummies;
using Models.WeaponModel;
using Presenters.Projectile;
using UnityEngine;
using Zenject;

namespace Views.Enemy.EnemyStateMachine
{
    public class EnemyCollisionDetectionView : MonoBehaviour
    {
        private EnemyCollisionDetectionPresenter _presenter;

        [Inject]
        public void Initialize(WeaponModel weaponModel, HealthModel healthModel)
        {
            _presenter = new(weaponModel, healthModel);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ProjectileView projectileView))
            {
                _presenter.ApplyDamage();
                projectileView.gameObject.SetActive(false);
            }
        }
    }
}