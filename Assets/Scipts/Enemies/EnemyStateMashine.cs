using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMashine
{
    public EnemyState CurrentState { get; private set; }

    public void InitializeState(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }
}