using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Pedroca2005BR/States/Testing/StateTesting")]
public class StateTesting : BaseStateSO<StateTest>
{
    public float test;

    public override void EnterState(BaseStateMachine<StateTest> context)
    {
        Debug.Log("Welcome to Test 101!");
        test = 0;
    }

    public override void ExitState(BaseStateMachine<StateTest> context)
    {
        Debug.Log("Asta la vista, baby!"); 
    }

    public override void UpdateState(BaseStateMachine<StateTest> context)
    {
        test += Time.deltaTime;
        Debug.Log("Testing stuff...");

        if (test > 5)
        {
            context.SetFlag("TestComplete");
        }
    }
}
