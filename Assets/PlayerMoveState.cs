using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor;
using UnityEngine;
using UnityEngine.Playables;

// 玩家移动状态，并不直接继承PlayerState，而是继承PlayerGroundState
public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player,PlayerStateMachine _stateMachine,  string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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
        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (xInput == 0 || player.ISWallDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }


}
