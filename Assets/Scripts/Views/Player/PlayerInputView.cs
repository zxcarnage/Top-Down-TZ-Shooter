using Models.MovementModel;
using Presenters.Player;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    public class PlayerInputView : MonoBehaviour
    {
        private PlayerInputPresenter _presenter;
        private InputService _inputService;

        [Inject]
        public void Initialize(InputService inputService, MovementModel movementModel)
        {
            _presenter = new(inputService, movementModel);

            _inputService = inputService;
        }
        
        private void OnEnable()
        {
            _inputService.Enable();
        }

        private void OnDisable()
        {
            _inputService.Disable();
        }

        public void Update()
        {
            _presenter.CaptureInput();
        }
        
    }
}