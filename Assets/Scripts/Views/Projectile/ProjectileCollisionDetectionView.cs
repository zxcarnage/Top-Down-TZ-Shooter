using System;
using UnityEngine;
using Views.Enemy;

namespace Dummies
{
    public class ProjectileCollisionDetectionView : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out EnemyView enemyView))
                Debug.Log("Apply damage");
            else
                gameObject.SetActive(false);
        }
    }
}