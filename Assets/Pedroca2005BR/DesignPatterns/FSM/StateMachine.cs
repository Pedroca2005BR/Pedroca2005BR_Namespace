using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pedroca2005BR.DesignPatterns.FSM
{
    public class StateMachine
    {
        StateNode current;
        Dictionary<Type, StateNode> nodes = new();
        HashSet<Transition> anyTransitions = new();

        public void Update()
        {
            // Check for transitions and change state if necessary
            var transition = GetTransition();
            if (transition != null)
                ChangeState(transition.To);

            // Update the current state
            current.State.UpdateState();
        }

        public void ChangeState(IState state)
        {
            // If the current state is the same as the new state, do nothing
            if (current != null && current.State == state)
                return;
            if (current == null)
            {
                SetState(state);
                return;
            }

            var previousState = current.State;
            var nextState = nodes[state.GetType()].State;

            // Exit the previous state and enter the next state
            previousState.ExitState();
            nextState.EnterState();
            current = nodes[state.GetType()];
        }

        public void SetState(IState state)
        {
            current = nodes[state.GetType()];
            current.State.EnterState();
        }

        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }

        public void AddAnyTransition(IState to, IPredicate condition)
        {
            anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
        }


        Transition GetTransition()
        {
            foreach (var transition in anyTransitions)
                if (transition.Condition.Evaluate()) 
                    return transition;
            foreach (var transition in current.Transitions)
                if (transition.Condition.Evaluate())
                    return transition;
            return null;
        }

        StateNode GetOrAddNode(IState state)
        {
            var node = nodes.GetValueOrDefault(state.GetType());

            if (node == null)
            {
                node = new StateNode(state);
                nodes.Add(state.GetType(), node);
            }

            return node;
        }


        class StateNode
        {
            public IState State { get; }
            public HashSet<Transition> Transitions { get; }

            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<Transition>();
            }

            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(new Transition(to, condition));
            }
        }
    }
}
