using System;
using Models.PlayerRotation;
using Presenters.Player;
using UnityEngine;
using Zenject;

namespace Views.Player
{
    public class PlayerRotatorView : MonoBehaviour
    {
        private PlayerRotatorPresenter _presenter;

        [Inject]
        public void Initialize(PlayerRotationModel _model)
        {
            _presenter = new(_model, GetComponent<Transform>());
        }

        private void Update()
        {
            _presenter.TryRotate();
        }
    }
}