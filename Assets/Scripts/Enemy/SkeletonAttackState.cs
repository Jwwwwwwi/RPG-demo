using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private EnemySkeleton enemySkeleton;

    public SkeletonAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemySkeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.enemySkeleton = _enemySkeleton;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemySkeleton.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        enemySkeleton.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(enemySkeleton.battleState);
    }

}
