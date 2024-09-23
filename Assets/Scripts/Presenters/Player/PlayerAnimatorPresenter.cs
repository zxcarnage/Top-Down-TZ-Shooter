using Models.MovementModel;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerAnimatorPresenter
    {
        private readonly Animator _animator;
        private readonly MovementModel _movementModel;
        private readonly Transform _playerTransform;
        
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");

        public PlayerAnimatorPresenter(Animator animator, MovementModel movementModel, Transform playerTransform)
        {
            InvariantChecker.CheckObjectInvariant<PlayerAnimatorPresenter>(animator,movementModel);

            _animator = animator;
            _movementModel = movementModel;
            _playerTransform = playerTransform;
        }

        public void Animate()
        {
            AnimateWalkBlending();
        }

        private void AnimateWalkBlending()
        {
            float vertical = Vector3.Dot(_movementModel.MovementDirection.normalized, _playerTransform.forward);
            float horizontal = Vector3.Dot(_movementModel.MovementDirection.normalized, _playerTransform.right);
            _animator.SetFloat(Horizontal, horizontal, 0.1f, Time.deltaTime);
            _animator.SetFloat(Vertical, vertical, 0.1f, Time.deltaTime);
        }
    }
}