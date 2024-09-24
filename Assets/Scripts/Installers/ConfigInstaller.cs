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
        [SerializeField] private SpawnerConfig _spawnerConfig;
        
        public override void InstallBindings()
        {
            BindSpawnConfig();
            BindWeaponConfig();
            BindCameraConfig();
            BindConfigInstaller();
        }

        private void BindSpawnConfig()
        {
            Container.Bind<SpawnerConfig>()
                .FromScriptableObject(_spawnerConfig)
                .AsSingle()
                .NonLazy();
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