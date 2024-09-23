using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private WeaponConfig _weaponConfig;
        
        public override void InstallBindings()
        {
            BindWeaponConfig();
            BindCameraConfig();
            BindConfigInstaller();
        }

        private void BindWeaponConfig()
        {
            Container.Bind<WeaponConfig>()
                .FromScriptableObject(_weaponConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindCameraConfig()
        {
            Container.Bind<CameraConfig>()
                .FromScriptableObject(_cameraConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindConfigInstaller()
        {
            Container.Bind<PlayerConfig>()
                .FromScriptableObject(_playerConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}