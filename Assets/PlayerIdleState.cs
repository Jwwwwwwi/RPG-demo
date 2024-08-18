using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 玩家闲置状态，并不直接继承PlayerState，而是继承PlayerGroundState
public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player,PlayerStateMachine _stateMachine,  string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, 0); 
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput == player.facingDir && player.ISWallDetected())
            return;

        if (xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

}
