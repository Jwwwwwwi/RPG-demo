using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 继承自敌人类，描述骷髅敌人的行动
public class EnemySkeleton : Enemy
{

    #region States
    public SkeletonIdleState idleState{get; private set;}
    public SkeletonMoveState moveState{get; private set;}
    #endregion

    protected override void Awake()
    {
        // 从父类继承状态机，需要初始化自己的状态
        base.Awake();
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        
    }
}
