using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家墙面跳跃状态
public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // 设置初始墙面起跳速度和该状态的时间,后续考虑将具体数值封装留出接口
    public override void Enter()
    {
        base.Enter();
        stateTimer = .4f;
        player.SetVelocity(5 * -player.facingDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    // 当起跳后0.4s进入空中状态
    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.airState);
        }

        // 起跳后0.4s内提前落地，需要转换状态为闲置
        if (player.ISGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
