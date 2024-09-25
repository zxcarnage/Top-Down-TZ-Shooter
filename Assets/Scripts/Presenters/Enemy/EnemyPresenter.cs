using System;
using DefaultNamespace.Models.Health;
using UnityEngine;
using Utils;
using Views.Enemy;

namespace DefaultNamespace.Presenters.Enemy
{
    public class EnemyPresenter
    {
        private readonly HealthModel _healthModel;
        private readonly EnemyView _enemyView;

        public EnemyPresenter(EnemyView enemyView, HealthModel healthModel)
        {
            InvariantChecker.CheckObjectInvariant<EnemyPresenter>(enemyView,healthModel);
            _enemyView = enemyView;
            _healthModel = healthModel;
        }
        
        public void TakeDamage(float damage)
        {
            _healthModel.Decrease(damage);
            Debug.Log($"{_healthModel.Health}");
        }

        public void Enable()
        {
            _healthModel.Died += OnEnemyDied;
        }

        public void Disable()
        {
            _healthModel.Died -= OnEnemyDied;
        }

        private void OnEnemyDied()
        {
            _healthModel.Reset();
            _enemyView.gameObject.SetActive(false);
        }
    }
}