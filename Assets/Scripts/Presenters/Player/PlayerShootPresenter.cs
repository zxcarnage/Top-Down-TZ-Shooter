using System.Collections.Generic;
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

namespace Presenters.Player
{
    public class PlayerShootPresenter
    {
        private readonly WeaponModel _weaponModel;
        private readonly DetectedEnemiesModel _detectedEnemiesModel;
        private readonly Transform _playerModelTransform;
        private readonly PlayerConfig _playerConfig;
        private readonly CancellationTokenSource _cts;
        private readonly ShootObjectPool _shootObjectPool;
        private readonly PlayerRotationModel _playerRotationModel;
        private readonly Transform _shotsParent;

        private Transform _target;
        private Vector3 _targetRotation;

        public PlayerShootPresenter(WeaponModel weaponModel, DetectedEnemiesModel detectedEnemiesModel, Transform playerModelTransform, Transform shotsParent, 
            PlayerConfig playerConfig, ShootObjectPool shootObjectPool, PlayerRotationModel playerRotationModel)
        {
            InvariantChecker.CheckObjectInvariant<PlayerShootPresenter>(weaponModel, detectedEnemiesModel,playerConfig, playerModelTransform,shotsParent, shootObjectPool,playerRotationModel);

            _weaponModel = weaponModel;
            _detectedEnemiesModel = detectedEnemiesModel;
            _playerModelTransform = playerModelTransform;
            _playerConfig = playerConfig;
            _shootObjectPool = shootObjectPool;
            _playerRotationModel = playerRotationModel;
            _shotsParent = shotsParent;
            
            _cts = new CancellationTokenSource();
        }

        public void Enable()
        {
            _detectedEnemiesModel.EnemyDetected += OnEnemyDetected;
        }

        public void Disable()
        {
            _detectedEnemiesModel.EnemyDetected -= OnEnemyDetected;
        }

        private void OnEnemyDetected(Transform enemy)
        {
            if (_target != null)
                return;
            _target = enemy;
            RotateAndShootTask(enemy, _cts.Token).Forget();
        }

        private async UniTask RotateAndShootTask(Transform enemy, CancellationToken token)
        {
            _playerRotationModel.RotatePlayer(enemy);
            while (_target != null)
            {
                TryShoot();
                await UniTask.Delay((int) (1000 * _weaponModel.FireRate), cancellationToken:token);
            }
        }

        private async UniTask Rotate(Transform enemy)
        {
            _targetRotation = (enemy.transform.position - _playerModelTransform.position).normalized;
            while (_playerModelTransform.forward != _targetRotation)
            {
                await _playerModelTransform.DORotate(_targetRotation, _playerConfig.RotateDuration);
            }

            _playerRotationModel.RotatePlayer(enemy);
        }

        //Пока что предполагается что оружие одно, если бы оружий было несколько можно было бы сделать ObjectPool
        //Под несколько типов проджектайлов и менять их в рантайме
        private void TryShoot()
        {
            _shootObjectPool.Get(ProjectileType.Common).TryGetComponent(out ProjectileView projectileView);
            if (projectileView != null)
            {
                projectileView.gameObject.SetActive(true);
                projectileView.transform.position = _shotsParent.position;
                projectileView.Shoot(_target);
            }
        }
    }
}