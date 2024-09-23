using Models.PlayerRotation;
using Models.WeaponModel;
using UnityEngine;
using Utils;

namespace Presenters.Projectile
{
    public class ProjectilePresenter
    {
        private readonly WeaponModel _weaponModel;
        private readonly Rigidbody _rigidbody;
        private readonly Transform _projectileTransform;

        public ProjectilePresenter(WeaponModel weaponModel, Rigidbody projectileRigidbody, Transform projectileTransform)
        {
            InvariantChecker.CheckObjectInvariant<ProjectilePresenter>(weaponModel, projectileRigidbody,projectileTransform);
            _weaponModel = weaponModel;
            _rigidbody = projectileRigidbody;
            _projectileTransform = projectileTransform;
        }

        public void Shoot(Transform target)
        {
            _rigidbody.linearVelocity = (target.position  - _projectileTransform.position).normalized * _weaponModel.ProjectileSpeed;
        }
    }
}