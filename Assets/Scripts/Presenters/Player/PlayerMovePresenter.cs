using Models.MovementModel;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.Player
{

    public class PlayerMovePresenter
    {
        private readonly MovementModel _movementModel;
        private readonly Rigidbody _playerRigidbody;
        private readonly CharacterConfig _playerConfig;

        private Vector3 _moveDirection;

        public PlayerMovePresenter(MovementModel movementModel, CharacterConfig playerConfig, Rigidbody playerRigidbody)
        {
            InvariantChecker.CheckObjectInvariant<PlayerMovePresenter>(movementModel, playerRigidbody, playerConfig);
            _movementModel = movementModel;
            _playerConfig = playerConfig;
            _playerRigidbody = playerRigidbody;
        }
        
        public void TryMove()
        {
            _moveDirection = _movementModel.MovementDirection * _playerConfig.MovementSpeed * Time.fixedDeltaTime;
            _playerRigidbody.linearVelocity =
                new Vector3(_moveDirection.x, _playerRigidbody.linearVelocity.y, _moveDirection.z);
        }
    }

}