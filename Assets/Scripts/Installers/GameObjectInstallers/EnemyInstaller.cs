using DefaultNamespace.Models.Damage;
using DefaultNamespace.Models.Health;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers.GameObjectInstallers
{
    public class EnemyInstaller : MonoInstaller<EnemyInstaller>
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings()
        {
            BindEnemyConfig();
            BindHealthModel();
            BindDamageModel();
        }

        private void BindEnemyConfig()
        {
            Container.Bind<EnemyConfig>()
                .FromScriptableObject(_enemyConfig)
                .AsSingle()
                .NonLazy();
        }

        private void BindDamageModel()
        {
            Container.Bind<DamageModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindHealthModel()
        {
            Container.Bind<HealthModel>()
                .AsSingle()
                .NonLazy();
        }
    }
}