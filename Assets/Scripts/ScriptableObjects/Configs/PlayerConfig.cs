using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Player config", menuName = "Configs/Player", order = 0)]
    public class PlayerConfig : CharacterConfig
    {
        [SerializeField] private float _rotateDuration;

        public float RotateDuration => _rotateDuration;
    }

}