using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class SkeletonDeadState : EnemyState
{
    private EnemySkeleton enemySkeleton;
    
    public SkeletonDeadState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemyskeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        enemySkeleton = _enemyskeleton;
    }

    public override void Enter()
    {
        base.Enter();
        enemySkeleton.anim.SetBool(enemySkeleton.lastAnimBoolName, true);
        enemy.anim.speed = 0;
        enemy.cd.enabled = false;

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
            rb.velocity = new Vector2(0, 10);
    }

    
}
