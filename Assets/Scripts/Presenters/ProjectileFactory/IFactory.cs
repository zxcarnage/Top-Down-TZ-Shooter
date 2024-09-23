using DefaultNamespace;
using UnityEngine;

namespace Presenters.ProjectileFactory
{
    public interface IFactory
    {
        public GameObject Create(ProjectileType type, Vector2 at, Transform parent = null);
        public GameObject CreateContainer(string containerName, Transform parent);
    }
}