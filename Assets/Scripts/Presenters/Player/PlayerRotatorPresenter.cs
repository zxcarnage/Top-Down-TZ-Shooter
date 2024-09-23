using Models.PlayerRotation;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerRotatorPresenter
    {
        private readonly PlayerRotationModel _model;
        private readonly Transform _playerTransform;

        public PlayerRotatorPresenter(PlayerRotationModel model, Transform playerTransform)
        {
            InvariantChecker.CheckObjectInvariant<PlayerRotatorPresenter>(model, playerTransform);

            _playerTransform = playerTransform;
            _model = model;
        }

        public void TryRotate()
        {
            if (_model.TargetRotationTransform != null)
                _playerTransform.forward =
                    (_model.TargetRotationTransform.position - _playerTransform.position).normalized;

        }
    }
}