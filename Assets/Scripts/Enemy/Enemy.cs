using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Resources;
using UnityEngine;

// 从实体类继承，只描述敌人特有状态
public class Enemy : Entity
{
    [Header("Move innfo")]
    public float moveSpeed;
    public float idleTime;
    public EnemyStateMachine stateMachine {get; private set;}

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
}
