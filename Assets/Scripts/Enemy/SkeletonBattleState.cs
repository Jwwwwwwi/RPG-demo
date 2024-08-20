using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private EnemySkeleton enemySkeleton;
    private Transform player;
    private int moveDir;
    // 追击距离
    private int chaseDis = 15;

    public SkeletonBattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemySkeleton) : base(_enemy, _stateMachine, _animBoolName)
    {
        this.enemySkeleton = _enemySkeleton;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemySkeleton.IsPlayerDetected())
        {
            stateTimer = enemySkeleton.battleTime;
            if (enemySkeleton.IsPlayerDetected().distance < enemySkeleton.attackDistance && enemySkeleton.IsPlayerDetected().distance > 0)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemySkeleton.attackState);
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemySkeleton.transform.position) > chaseDis)
                stateMachine.ChangeState(enemySkeleton.idleState);
        }

        if (player.position.x > enemySkeleton.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemySkeleton.transform.position.x)
            moveDir = -1;
        enemySkeleton.SetVelocity(enemySkeleton.moveSpeed * moveDir, rb.velocity.y);


    }

    private bool CanAttack()
    {
        if (Time.time >= enemySkeleton.lastTimeAttacked + enemySkeleton.attackCooldown)
        {
            enemySkeleton.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }

}
