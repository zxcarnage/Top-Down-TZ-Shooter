using System;
using DefaultNamespace.Dummies;
using ScriptableObjects;
using UnityEngine;
using Views.Player;
using Zenject;

namespace Views.Enemy.EnemyStateMachine.Transition
{

    public class AttackTransitionView : TransitionView
    {
        private PlayerMoveView _player;
        private Transform _selfTransform;
        private EnemyConfig _enemyConfig;

        [Inject]
        public void Initialize(PlayerMoveView player, EnemyConfig enemyConfig)
        {
            _player = player;
            _enemyConfig = enemyConfig;
        }

        private void Start()
        {
            _selfTransform = transform;
        }

        private void OnEnable()
        {
            NeedTransit = false;
        }

        private void Update()
        {
            if (Vector3.Distance(_selfTransform.position, _player.transform.position) >= _enemyConfig.AttackDistance)
                NeedTransit = true;
        }
    }

}