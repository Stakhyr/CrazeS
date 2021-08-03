using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashine 
{
    public State CurrentState { get; private set; }

    public void InitializeState(State startingState) 
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState) 
    {
        CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }
}
