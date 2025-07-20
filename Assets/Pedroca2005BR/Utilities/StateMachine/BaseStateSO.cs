using System;
using UnityEngine;


public abstract class BaseStateSO<TEnum> : ScriptableObject, IState<TEnum> where TEnum : Enum
{
    public abstract void EnterState(BaseStateMachine<TEnum> context);
    public abstract void ExitState(BaseStateMachine<TEnum> context);
    public abstract void UpdateState(BaseStateMachine<TEnum> context);
}
