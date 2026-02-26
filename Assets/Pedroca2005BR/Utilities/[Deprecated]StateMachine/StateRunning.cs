using UnityEngine;

[CreateAssetMenu(fileName = "StateRunning", menuName = "Pedroca2005BR/States/Testing/Running")]
public class StateRunning : BaseStateSO<StateTest>
{
    private Rigidbody rb;
    public float moveSpeed;

    public override void EnterState(BaseStateMachine<StateTest> context)
    {
        Debug.Log("Start running!");
        rb = context.GetComponent<Rigidbody>();
        moveSpeed = 0;
    }

    public override void ExitState(BaseStateMachine<StateTest> context)
    {
        Debug.Log("Until we meet again!");
    }

    public override void UpdateState(BaseStateMachine<StateTest> context)
    {
        rb.linearVelocity = new Vector3 (moveSpeed, moveSpeed/2, 0);

        moveSpeed -= Time.deltaTime;

        if (moveSpeed < -5)
        {
            context.SetFlag("RunningComplete");
        }
    }
}
