using Models.MovementModel;
using Presenters.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveView : MonoBehaviour
    {
        private PlayerMovePresenter _movePresenter;

        [Inject]
        public void Initialize(MovementModel movementModel, CharacterConfig playerConfig)
        {
            _movePresenter = new PlayerMovePresenter(movementModel, playerConfig, GetComponent<Rigidbody>());
        }
        

        private void FixedUpdate()
        {
            _movePresenter.TryMove();
        }
    }
}