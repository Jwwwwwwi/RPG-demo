using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 骷髅移动状态
public class SkeletonMoveState : SkeletonGroundState
{
    
    public SkeletonMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemySkeleton) : base(_enemy, _stateMachine, _animBoolName, _enemySkeleton)
    {
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
        enemySkeleton.SetVelocity(enemySkeleton.moveSpeed * enemySkeleton.facingDir, rb.velocity.y);

        if (enemySkeleton.ISWallDetected() || !enemySkeleton.ISGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemySkeleton.idleState);
        }

    }
}
