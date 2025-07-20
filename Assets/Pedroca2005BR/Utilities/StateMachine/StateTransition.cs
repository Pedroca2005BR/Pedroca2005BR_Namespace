using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class StateTransition<EnumState> where EnumState : Enum
{
    public EnumState from;
    public EnumState to;
    public string requiredFlag;
}
