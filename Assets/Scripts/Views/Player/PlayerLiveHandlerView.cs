using System;
using DefaultNamespace.Models.Health;
using Presenters.Player;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    public class PlayerLiveHandlerView : MonoBehaviour
    {
        private PlayerLiveHandlerPresenter _presenter;

        [Inject]
        public void Initialize(HealthModel healthModel)
        {
            _presenter = new(healthModel);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}