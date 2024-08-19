using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 骷髅移动状态
public class SkeletonMoveState : EnemyState
{
    private EnemySkeleton enemySkeleton;

    // 构造方法中的Enemy可能描述了太多敌人信息，只需要自己的即可，因此添加EnemySkeleton，后续仅用改属性
    public SkeletonMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemySkeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        enemySkeleton = _enemySkeleton;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemySkeleton.SetVelocity(enemySkeleton.moveSpeed * enemySkeleton.facingDir, enemySkeleton.rb.velocity.y);

        if (enemySkeleton.ISWallDetected() || !enemySkeleton.ISGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemySkeleton.idleState);
        }

    }
}
