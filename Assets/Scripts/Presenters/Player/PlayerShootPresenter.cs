using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using DG.Tweening;
using Dummies;
using Models.DetectedEnemiesModel;
using Models.PlayerRotation;
using Models.WeaponModel;
using Presenters.ObjectPool.ShootObjectPool;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.Enemy;

namespace Presenters.Player
{
    public class PlayerShootPresenter
    {
        private readonly WeaponModel _weaponModel;
        private readonly DetectedEnemiesModel _detectedEnemiesModel;
        private readonly Transform _playerModelTransform;
        private readonly ShootObjectPool _shootObjectPool;
        private readonly PlayerRotationModel _playerRotationModel;
        private readonly Transform _shotsParent;

        private Transform _target;
        private Vector3 _targetRotation;
        private float _shootDelay;

        public PlayerShootPresenter(WeaponModel weaponModel, DetectedEnemiesModel detectedEnemiesModel, Transform playerModelTransform, Transform shotsParent, 
            ShootObjectPool shootObjectPool, PlayerRotationModel playerRotationModel)
        {
            InvariantChecker.CheckObjectInvariant<PlayerShootPresenter>(weaponModel, detectedEnemiesModel, playerModelTransform,shotsParent, shootObjectPool,playerRotationModel);

            _weaponModel = weaponModel;
            _detectedEnemiesModel = detectedEnemiesModel;
            _playerModelTransform = playerModelTransform;
            _shootObjectPool = shootObjectPool;
            _playerRotationModel = playerRotationModel;
            _shotsParent = shotsParent;
        }

        public void ShootClosest()
        {
            var target = FindNearestActiveEnemy();
            if (target != null)
            {
                _target = target.transform;
                _playerRotationModel.RotatePlayer(_target);
                HandleShootTimer(_target);
            }
        }

        private EnemyView FindNearestActiveEnemy()
        {
            return _detectedEnemiesModel.EnemyTransforms
                .OrderBy(enemy => Vector3.Distance(enemy.transform.position, _playerModelTransform.position))
                .FirstOrDefault(enemy => enemy.gameObject.activeSelf == true);
        }

        private void HandleShootTimer(Transform target)
        {
            if (_shootDelay >= _weaponModel.FireRate)
                TryShoot(target);
            else
                _shootDelay += Time.fixedDeltaTime;
        }

        //Пока что предполагается что оружие одно, если бы оружий было несколько можно было бы сделать ObjectPool

        //Под несколько типов проджектайлов и менять их в рантайме

        private void TryShoot(Transform target)
        {
            _shootObjectPool.Get(ProjectileType.Common).TryGetComponent(out ProjectileView projectileView);
            if (projectileView != null)
            {
                projectileView.gameObject.SetActive(true);
                projectileView.transform.position = _shotsParent.position;
                projectileView.Shoot(target);
            }

            _shootDelay = 0f;
        }
    }
}