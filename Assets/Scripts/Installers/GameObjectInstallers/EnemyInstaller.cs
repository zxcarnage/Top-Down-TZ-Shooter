using DefaultNamespace.Models.Damage;
using DefaultNamespace.Models.Health;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Installers.GameObjectInstallers
{
    public class EnemyInstaller : MonoInstaller<EnemyInstaller>
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public override void InstallBindings()
        {
            BindNavMeshAgent();
            BindEnemyConfig();
            BindHealthModel();
            BindDamageModel();
        }

        private void BindNavMeshAgent()
        {
            Container.Bind<NavMeshAgent>()
                .FromInstance(_navMeshAgent)
                .AsSingle()
                .NonLazy();
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