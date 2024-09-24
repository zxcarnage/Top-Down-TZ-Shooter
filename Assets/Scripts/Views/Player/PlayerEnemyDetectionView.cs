using System;
using Models.DetectedEnemiesModel;
using Presenters.Player;
using UnityEngine;
using Views.Enemy;
using Zenject;

namespace Views.Player
{
    public class PlayerEnemyDetectionView : MonoBehaviour
    {
        private PlayerEnemyDetectionPresenter _presenter;

        [Inject]
        public void Initialize(DetectedEnemiesModel detectedEnemiesModel)
        {
            _presenter = new PlayerEnemyDetectionPresenter(detectedEnemiesModel);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out EnemyView enemyView))
            {
                _presenter.DetectEnemy(enemyView.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out EnemyView enemyView))
                Debug.Log("OnTriggerExit");
        }
    }
}