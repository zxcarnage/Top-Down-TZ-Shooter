using Models.DetectedEnemiesModel;
using UnityEngine;
using Utils;

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

        public void DetectEnemy(Transform enemyViewTransform)
        {
            _detectedEnemiesModel.DetectEnemy(enemyViewTransform);
        }
    }
}