using UnityEngine;

namespace Pedroca2005BR.DesignPatterns.FSM
{
    public abstract class BaseState<T> : IState where T : MonoBehaviour
    {
        protected readonly T context;

        protected BaseState(T context)
        {
            this.context = context;
        }

        public abstract void EnterState();

        public abstract void ExitState();

        public abstract void UpdateState();
    }
}