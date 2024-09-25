
using Utils;
using Views.Enemy.EnemyStateMachine.State;

namespace Presenters.StateMachine
{
    public class EnemyStateMachinePresenter
    {
        private readonly StateView _startingState;

        public EnemyStateMachinePresenter(StateView startingState)
        {
            InvariantChecker.CheckObjectInvariant<EnemyStateMachinePresenter>(startingState);
            _startingState = startingState;
        }
        
        public StateView CurrentState { get; private set; }

        public void Start()
        {
            Reset();
        }
        
        public void Reset()
        {
            Transit(_startingState);
        }
        
        public void Update()
        {
            if(CurrentState == null)
                return;
        
            var next = CurrentState.GetNext();
            if(next != null)
                Transit(next);
        }
        
        private void Transit(StateView next)
        {
            if(CurrentState != null)
                CurrentState.Exit();
        
            CurrentState = next;
            if(CurrentState != null)
                CurrentState.Enter();
        }
        
    }

}