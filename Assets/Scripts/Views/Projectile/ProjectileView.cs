using System;
using Models.PlayerRotation;
using Models.WeaponModel;
using Presenters.Projectile;
using UnityEngine;
using Zenject;

namespace Dummies
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ProjectileView : MonoBehaviour
    {
        private ProjectilePresenter _presenter;
        
        public virtual void Initialize(WeaponModel weaponModel)
        {
            _presenter = new(weaponModel, GetComponent<Rigidbody>(), transform);
        }
        

        public void Shoot(Transform target)
        {
            _presenter.Shoot(target);
        }
    }
}