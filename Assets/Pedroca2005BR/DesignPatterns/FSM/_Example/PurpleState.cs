using UnityEngine;


namespace Pedroca2005BR.DesignPatterns.FSM._Example
{
    public class PurpleState : BaseState<CubeBehaviour>
    {
        HingeJoint hinge;

        public PurpleState(CubeBehaviour context) : base(context)
        {
            hinge = context.GetComponent<HingeJoint>();
        }

        public override void EnterState()
        {
            context.GetComponent<Renderer>().material.color = Color.purple;
            hinge.useMotor = true;
        }

        public override void ExitState()
        {
            hinge.useMotor = false;
            Debug.Log("Exiting Purple State");
        }

        public override void UpdateState()
        {
            if (context.MoveInput != Vector2.zero)
                hinge.axis = new Vector3(context.MoveInput.y, 0, -context.MoveInput.x);
            else
                hinge.axis = Vector3.down;
        }
    }
}
