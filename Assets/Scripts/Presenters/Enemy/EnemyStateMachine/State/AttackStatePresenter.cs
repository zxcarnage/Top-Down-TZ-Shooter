using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DefaultNamespace.Models.Health;
using Models;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Views.Enemy.EnemyStateMachine.Transition;

namespace Presenters.Enemy.State
{
    public class AttackStatePresenter : StatePresenter
    {
        private readonly HealthModel _playerHealthModel;
        private readonly EnemyConfig _config;
        private readonly NavMeshAgent _navMeshAgent;

        private CancellationTokenSource _cancellationTokenSource;

        public AttackStatePresenter(HealthModel playerHealthModel, EnemyConfig config, List<TransitionView> transitions, NavMeshAgent navMeshAgent) : base(transitions)
        {
            InvariantChecker.CheckObjectInvariant<AttackStatePresenter>(playerHealthModel, config, transitions, navMeshAgent);

            _playerHealthModel = playerHealthModel;
            _config = config;
            _navMeshAgent = navMeshAgent;

        }

        public async UniTask Enter()
        {
            StopEnemy();
            _cancellationTokenSource = new();
            await DamageTask(_cancellationTokenSource.Token);
        }

        private void StopEnemy()
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
        }

        private async UniTask DamageTask(CancellationToken token)
        {
            try
            {
                while (token.IsCancellationRequested == false)
                {
                    await UniTask.Delay((int) (_config.AttackDelay * 1000), cancellationToken: token);
                    _playerHealthModel.Decrease(_config.Damage);
                }
            }
            catch (OperationCanceledException)
            {
            }
            
        }

        public void Exit()
        {
            _cancellationTokenSource.Cancel();
        }
    }

}