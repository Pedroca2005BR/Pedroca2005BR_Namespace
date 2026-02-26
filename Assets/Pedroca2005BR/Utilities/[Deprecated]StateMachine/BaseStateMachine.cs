using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public abstract class BaseStateMachine<EnumState> : MonoBehaviour where EnumState : Enum
{
    [Header("States")]
    [SerializeField] private List<SerializableDictionaryCell<EnumState, BaseStateSO<EnumState>>> states;
    protected Dictionary<EnumState, BaseStateSO<EnumState>> stateInstances = new Dictionary<EnumState, BaseStateSO<EnumState>>();

    protected EnumState currentState;

    [Header("State Transitions Graph")]
    [SerializeField] protected List<StateTransition<EnumState>> stateGraph = new List<StateTransition<EnumState>>();

    // flag system
    private Dictionary<string, bool> transitionFlags = new Dictionary<string, bool>();


    private void Start()
    {
        CloneStates();
        currentState = default;
        stateInstances[currentState].EnterState(this);
    }

    private void Update()
    {
        stateInstances[currentState].UpdateState(this);
        TryTransition();
    }

    private void TryTransition()
    {
        foreach (var t in stateGraph)
        {
            if (EqualityComparer<EnumState>.Default.Equals(t.from, currentState) && GetFlag(t.requiredFlag))
            {
                stateInstances[currentState].ExitState(this);
                currentState = t.to;
                ResetAllFlags();
                stateInstances[currentState].EnterState(this);
                break;
            }
        }
    }


    private void CloneStates()
    {
        for (int i = 0; i < states.Count; i++)
        {
            stateInstances[states[i].key] = Instantiate(states[i].value);
        }
    }

    public void ResetAllFlags() => transitionFlags.Keys.ToList().ForEach(k => transitionFlags[k] = false);

    public void SetFlag(string flag, bool value = true) => transitionFlags[flag] = value;
    public bool GetFlag(string flag) => transitionFlags.TryGetValue(flag, out var v) && v;
}
