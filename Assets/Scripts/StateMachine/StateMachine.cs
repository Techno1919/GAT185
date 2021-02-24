using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;

    Dictionary<string, State> states = new Dictionary<string, State>();

    public Agent Owner { get; set; }
    public State State { get; set; }

    void Start()
    {
        Owner = GetComponent<Agent>();
        State[] cStates = GetComponents<State>();

        foreach(State state in cStates)
        {
            states.Add(state.GetType().Name, state);
        }

        SetState(initialState);
    }

    public void Execute()
    {
        State?.Execute(Owner);
    }

    public void SetState(string stateName)
    {
        if(states.ContainsKey(stateName))
        {
            SetState(states[stateName]);
        }
    }

    public void SetState(State newState)
    {
        if(newState != State)
        {
            State?.Exit(Owner);
            State = newState;
            newState.Enter(Owner);
        }
    }
}
