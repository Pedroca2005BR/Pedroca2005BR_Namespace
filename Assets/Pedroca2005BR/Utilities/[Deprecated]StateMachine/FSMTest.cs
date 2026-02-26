using UnityEngine;

public enum StateTest
{
    Testing = 0,
    Running = 1,
    Debugging = 2
}

[RequireComponent(typeof(Rigidbody))]
public class FSMTest : BaseStateMachine<StateTest>
{
    
}
