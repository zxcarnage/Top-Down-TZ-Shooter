using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using Utils;
using Views.Enemy;

namespace Models.DetectedEnemiesModel
{
    public class DetectedEnemiesModel
    {
        public DetectedEnemiesModel()
        {
            EnemyTransforms = new List<EnemyView>();
        }

        public List<EnemyView> EnemyTransforms { get; private set; }
        public event Action<EnemyView> DetectedEnemy;

        public void DetectEnemy(EnemyView enemy)
        {
            InvariantChecker.CheckObjectInvariant<DetectedEnemiesModel>(enemy);
            
            EnemyTransforms.Add(enemy);
            DetectedEnemy?.Invoke(enemy);
        }

        public void UndetectEnemy(EnemyView enemy)
        {
            EnemyTransforms.Remove(enemy);
        }
    }
}