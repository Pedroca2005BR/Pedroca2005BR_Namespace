using UnityEngine;


namespace Pedroca2005BR.DesignPatterns.FSM._Example
{
    public class BlueState : BaseState<CubeBehaviour>
    {
        public BlueState(CubeBehaviour context) : base(context) { }

        public override void EnterState()
        {
            context.GetComponent<Renderer>().material.color = Color.blue;
        }

        public override void ExitState()
        {
            Debug.Log("Exiting Blue State");
        }

        public override void UpdateState()
        {
            context.HandleMove();
        }
    }
}
