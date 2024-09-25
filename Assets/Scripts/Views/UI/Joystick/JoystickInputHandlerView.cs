using System;
using Models.MovementModel;
using Presenters.UI.Joystick;
using UnityEngine;
using Zenject;

namespace Views.UI.Joystick
{
    public class JoystickInputHandlerView : MonoBehaviour
    {
        private JoystickInputHandlerPresenter _presenter;

        [Inject]
        public void Initialize(MovementModel movementModel, InputService inputService)
        {
            _presenter = new(movementModel, inputService);
        }

        private void Update()
        {
            _presenter.ReadInput();
        }
    }
}