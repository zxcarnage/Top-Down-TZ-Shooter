using Presenters.StateMachine;
using UnityEngine;
using Views.Enemy.EnemyStateMachine.State;
using Zenject;

namespace Views.Enemy.EnemyStateMachine
{

    public class EnemyStateMachineView : MonoBehaviour
    {
        [SerializeField] private StateView _startingState;

        private EnemyStateMachinePresenter _presenter;

        [Inject]
        public void Initialize()
        {
            _presenter = new EnemyStateMachinePresenter(_startingState);
        }

        void Start()
        {
            _presenter.Start();
        }

        private void Update()
        {
            _presenter.Update();
        }
    }

}