using System;
using DefaultNamespace.Models.Health;
using DefaultNamespace.Presenters.Enemy;
using UnityEngine;
using Zenject;

namespace Views.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyPresenter _presenter;
        
        [Inject]
        public void Initialize(HealthModel healthModel)
        {
            _presenter = new(this, healthModel);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }

        public void TakeDamage(float damage)
        {
            _presenter.TakeDamage(damage);
        }
    }
}