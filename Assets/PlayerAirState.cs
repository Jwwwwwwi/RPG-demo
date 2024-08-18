using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家在空中的状态
public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (player.ISGroundDetected())
        {
            stateMachine.ChangeState(player.moveState);
        }
        
        if (xInput != 0)
        {
            player.SetVelocity(xInput * player.moveSpeed * .8f, rb.velocity.y);
        }

        if (player.ISWallDetected())
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
    }

}
