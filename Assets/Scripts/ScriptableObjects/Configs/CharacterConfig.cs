using UnityEngine;

namespace ScriptableObjects
{
    //[CreateAssetMenu(fileName = "Character config", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _movementSpeed;

        public float MovementSpeed => _movementSpeed;
    }
}