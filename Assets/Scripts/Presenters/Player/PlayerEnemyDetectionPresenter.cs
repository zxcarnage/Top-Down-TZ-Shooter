using Models.DetectedEnemiesModel;
using UnityEngine;
using Utils;
using Views.Enemy;

namespace Presenters.Player
{
    public class PlayerEnemyDetectionPresenter
    {
        private readonly DetectedEnemiesModel _detectedEnemiesModel;
        
        public PlayerEnemyDetectionPresenter(DetectedEnemiesModel detectedEnemiesModel)
        {
            InvariantChecker.CheckObjectInvariant<PlayerEnemyDetectionPresenter>(detectedEnemiesModel);

            _detectedEnemiesModel = detectedEnemiesModel;
        }

        public void DetectEnemy(EnemyView enemyViewTransform)
        {
            _detectedEnemiesModel.DetectEnemy(enemyViewTransform);
        }

        public void UndetectEnemy(EnemyView enemyViewTransform)
        {
            _detectedEnemiesModel.UndetectEnemy(enemyViewTransform);
        }
    }
}