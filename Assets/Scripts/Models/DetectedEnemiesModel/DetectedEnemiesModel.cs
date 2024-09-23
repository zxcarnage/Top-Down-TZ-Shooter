using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Utils;

namespace Models.DetectedEnemiesModel
{
    public class DetectedEnemiesModel
    {
        private readonly Queue<Transform> _enemyTransforms;

        public DetectedEnemiesModel()
        {
            _enemyTransforms = new Queue<Transform>();
        }

        public event Action<Transform> EnemyDetected;

        public void DetectEnemy(Transform enemyTransform)
        {
            InvariantChecker.CheckObjectInvariant<DetectedEnemiesModel>(enemyTransform);
            
            _enemyTransforms.Enqueue(enemyTransform);
            EnemyDetected?.Invoke(DequeueEnemy());
        }

        private Transform DequeueEnemy()
        {
            return _enemyTransforms.IsEmpty() ? null : _enemyTransforms.Dequeue();
        }
    }
}