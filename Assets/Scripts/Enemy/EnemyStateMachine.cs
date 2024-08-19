using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敌人状态机
public class EnemyStateMachine 
{
    public EnemyState currentState {get; private set;}

    public void Initialize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
