using System.Collections.Generic;
using Utils;
using Views.Enemy.EnemyStateMachine.State;
using Views.Enemy.EnemyStateMachine.Transition;

namespace Presenters.Enemy.State
{

    public abstract class StatePresenter
    {
        private readonly List<TransitionView> _transitions;
        
        public StatePresenter(List<TransitionView> transitions)
        {
            InvariantChecker.CheckObjectInvariant<StatePresenter>(_transitions = transitions);
        }

        public virtual StateView GetNext()
        {
            foreach (var transition in _transitions) 
            {
                if (transition.NeedTransit == true)
                    return transition.TargetState;
            }
        
            return null;
        }
    }

}