using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家攻击状态
public class PlayerPrimaryAttackState : PlayerState
{
    // 连击计数
    private int comboCounter;
    private float lastTimeAttack;
    private float comboWindow = .5f;

    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || Time.time >= lastTimeAttack + comboWindow)
            comboCounter = 0;
        player.anim.SetInteger("ComboCounter", comboCounter);

        #region Choose attack direction
        xInput = Input.GetAxisRaw("Horizontal"); // 修复攻击方向上的bug，有时会读到之前的输入导致攻击反向，因此重新读入，如果设置为0会导致无法在攻击间隔中转向
        float attackDir = player.facingDir;
        if (xInput != 0)
        {
            attackDir = xInput;
        }
        #endregion

        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();
        // 退出时启动协程等待一小段时间，避免在连续攻击的间隔中切换到其他状态
        player.StartCoroutine("BusyFor", .15f);
        comboCounter ++;
        lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            player.SetZeroVelocity();
        }
        
        if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}
