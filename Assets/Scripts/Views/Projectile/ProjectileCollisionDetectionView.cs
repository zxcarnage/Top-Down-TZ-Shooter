using System;
using Models.WeaponModel;
using Presenters.Projectile;
using UnityEngine;
using Views.Enemy;
using Zenject;

namespace Dummies
{
    public class ProjectileCollisionDetectionView : MonoBehaviour
    {
        private ProjectileDamagePresenter _presenter;

        [Inject]
        public void Initialize(WeaponModel weaponModel)
        {
            _presenter = new(weaponModel);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collide");
            if (collision.gameObject.TryGetComponent(out EnemyView enemyView))
                _presenter.ApplyDamage(enemyView);
            gameObject.SetActive(false);
        }
    }
}