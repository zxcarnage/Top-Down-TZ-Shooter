using System.Collections.Generic;
using UnityEngine;
using Views.Enemy.EnemyStateMachine.Transition;

namespace Views.Enemy.EnemyStateMachine.State
{

    public abstract class StateView : MonoBehaviour
    {
        [SerializeField, Tooltip("List of transitions from this state.")] 
        protected List<TransitionView> TransitionViews = new ();

        public abstract StateView GetNext();

        public virtual void Enter()
        {
            if(enabled == false)
            {
                enabled = true;
                ChangeTransitionsState(true);
            }
        }
        public virtual void Exit()
        {
            if(enabled == true)
            {
                ChangeTransitionsState(false);
                enabled = false;
            }
        }

        private void ChangeTransitionsState(bool state)
        {
            foreach(var transition in TransitionViews)
            {
                transition.enabled = state;
            }
        }
        
        protected virtual void FixedUpdate()
        {
        }
        
    }

}