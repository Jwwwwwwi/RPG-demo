using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 重构，将闲置状态和移动状态归为地面状态
public class SkeletonGroundState : EnemyState
{
    protected EnemySkeleton enemySkeleton;

    protected Transform player;

    // 构造方法中的Enemy可能描述了太多敌人信息，只需要自己的即可，因此添加EnemySkeleton，后续仅用该属性 
    public SkeletonGroundState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName, EnemySkeleton _enemySkeleton) : base(_enemy, _stateMachine, _animBoolName)
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
        if (enemySkeleton.IsPlayerDetected() || Vector2.Distance(enemySkeleton.transform.position, player.position) < 2)
            stateMachine.ChangeState(enemySkeleton.battleState);
    }

}
