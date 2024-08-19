using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家滑墙状态
public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        // 在墙上按空格进入墙面跳跃状态
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        // 在墙上按相反方向键下墙
        if (xInput != 0 && player.facingDir != xInput)
        {
            stateMachine.ChangeState(player.idleState);
        }

        // 在墙上按下，允许更快下墙
        if (yInput < 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y * .7f);
        }

        // 如果滑到地面直接进入闲置状态
        if (player.ISGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
