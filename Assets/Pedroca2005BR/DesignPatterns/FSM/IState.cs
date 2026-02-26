using UnityEngine;

namespace Pedroca2005BR.DesignPatterns.FSM
{
    public interface IState
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }
}