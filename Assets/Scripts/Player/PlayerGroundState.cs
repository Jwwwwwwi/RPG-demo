using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

// 玩家在地面的状态，是移动和闲置状态的父状态
public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.ChangeState(player.counterAttack);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.primaryAttack);
        }
        
        if (!player.ISGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.ISGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }
}