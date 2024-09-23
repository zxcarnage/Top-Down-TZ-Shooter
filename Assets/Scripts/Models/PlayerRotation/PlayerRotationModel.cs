using UnityEngine;

namespace Models.PlayerRotation
{
    public class PlayerRotationModel
    {
        public Transform TargetRotationTransform { get; private set; }

        public void RotatePlayer(Transform target)
        {
            TargetRotationTransform = target;
        }
    }
}