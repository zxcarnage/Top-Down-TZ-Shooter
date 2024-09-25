using System;
using Presenters.Enemy.State;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Views.Player;
using Zenject;

namespace Views.Enemy.EnemyStateMachine.State
{

    public class MoveStateView : StateView
    {
        private MoveStatePresenter _presenter;
        
        [Inject]
        protected void Initialize(EnemyConfig enemyConfig, PlayerMoveView playerMoveView, NavMeshAgent navMeshAgent)
        {
            _presenter = new MoveStatePresenter(enemyConfig, playerMoveView, navMeshAgent, TransitionViews);
        }

        public override void Enter()
        {
            base.Enter();
            _presenter.Enter();
        }

        public override StateView GetNext()
        {
            return _presenter.GetNext();
        }
    }

}