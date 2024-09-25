using Models.MovementModel;
using UnityEngine;
using Utils;

namespace Presenters.UI.Joystick
{
    public class JoystickInputHandlerPresenter
    {
        private readonly MovementModel _movementModel;
        private readonly InputService _inputService;

        public JoystickInputHandlerPresenter(MovementModel movementModel, InputService inputService)
        {
            InvariantChecker.CheckObjectInvariant<JoystickInputHandlerPresenter>(movementModel, inputService);

            _movementModel = movementModel;
            _inputService = inputService;
        }

        public void ReadInput()
        {
            var input = _inputService.Player.Joystick.ReadValue<Vector2>().normalized;
            _movementModel.MovePlayer(new Vector3(input.x, 0, input.y));
        }
    }
}