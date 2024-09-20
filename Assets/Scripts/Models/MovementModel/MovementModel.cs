using UnityEngine;

namespace Models.MovementModel
{
    public class MovementModel
    {
        public Vector3 MovementDirection { get; private set; }

        public void MovePlayer(Vector3 movementDirection)
        {
            MovementDirection = movementDirection;
        }
    }
}