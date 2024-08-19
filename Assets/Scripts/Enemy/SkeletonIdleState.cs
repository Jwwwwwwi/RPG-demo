using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 骷髅闲置状态
public class SkeletonIdleState : EnemyState
{
    private EnemySkeleton enemySkeleton;

    // 构造方法中的Enemy可能描述了太多敌人信息，只需要自己的即可，因此添加EnemySkeleton，后续仅用该属性
    public SkeletonIdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemySkeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        enemySkeleton = _enemySkeleton;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemySkeleton.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemySkeleton.moveState);
    }
}
