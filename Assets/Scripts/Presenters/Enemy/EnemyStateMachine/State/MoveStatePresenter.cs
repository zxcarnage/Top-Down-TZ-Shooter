using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Utils;
using Views.Enemy.EnemyStateMachine.Transition;
using Views.Player;

namespace Presenters.Enemy.State
{
    public class MoveStatePresenter : StatePresenter
    {
        private readonly EnemyConfig _enemyConfig;
        private readonly Transform _target;
        private readonly NavMeshAgent _navMeshAgent;

        private Vector2 _movementVector;

        public MoveStatePresenter(EnemyConfig enemyConfig, PlayerMoveView target, NavMeshAgent navMeshAgent, List<TransitionView> transition) : base(transition)
        {
            InvariantChecker.CheckObjectInvariant<MoveStatePresenter>(enemyConfig, target, navMeshAgent, transition);
            _enemyConfig = enemyConfig;
            _target = target.transform;
            _navMeshAgent = navMeshAgent;

            SetNavMeshParameters();
        }

        private void SetNavMeshParameters()
        {
            _navMeshAgent.speed = _enemyConfig.MovementSpeed;
        }

        public void Enter()
        {
            _navMeshAgent.SetDestination(_target.position);
        }
    }
}