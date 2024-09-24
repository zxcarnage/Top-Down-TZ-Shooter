using System;
using Cysharp.Threading.Tasks;
using Models.DetectedEnemiesModel;
using Models.PlayerRotation;
using Models.WeaponModel;
using Presenters.ObjectPool.ShootObjectPool;
using Presenters.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    public class PlayerShootView : MonoBehaviour
    {
        [SerializeField] private Transform _shotsSpawnPoint;
        private PlayerShootPresenter _presenter;
        
        [Inject]
        public void Initialize(WeaponModel weaponModel, DetectedEnemiesModel detectedEnemiesModel, Transform playerTransform, PlayerConfig playerConfig, ShootObjectPool shootObjectPool, PlayerRotationModel rotationModel)
        {
            _presenter = new PlayerShootPresenter(weaponModel,detectedEnemiesModel,playerTransform,_shotsSpawnPoint,playerConfig, shootObjectPool, rotationModel);
        }

        /*private void OnEnable()
        {
            _presenter.Enable();
        }*/

        private void FixedUpdate()
        {
            _presenter.ShootClosest();
        }

        /*
        private void OnDisable()
        {
            _presenter.Disable();
        }*/
    }
}