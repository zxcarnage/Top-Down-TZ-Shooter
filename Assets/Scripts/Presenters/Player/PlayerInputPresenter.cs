using Models.MovementModel;
using UnityEngine;
using Utils;

namespace Presenters.Player
{
    public class PlayerInputPresenter
    {
        private readonly InputService _inputService;
        private readonly MovementModel _movementModel;

        public PlayerInputPresenter(InputService inputService, MovementModel movementModel)
        {
            InvariantChecker.CheckObjectInvariant<PlayerInputPresenter>(inputService, movementModel);

            _inputService = inputService;
            _movementModel = movementModel;
        }
        
        public void CaptureInput()
        {
            _movementModel.MovePlayer(_inputService.Player.Movement.ReadValue<Vector3>().normalized);
        }
    }
}