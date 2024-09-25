using UnityEngine;
using Views.Enemy.EnemyStateMachine.State;

namespace Views.Enemy.EnemyStateMachine.Transition
{

    public abstract class TransitionView : MonoBehaviour
    {
        [SerializeField] private StateView _targetState;

        public StateView TargetState => _targetState;
        
        public bool NeedTransit { get; protected set; }
        
        protected virtual void FixedUpdate()
        {
        }
    }

}