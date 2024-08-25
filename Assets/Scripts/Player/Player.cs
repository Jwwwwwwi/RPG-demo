using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

// 重构，从实体类继承，只描述玩家特有状态
public class Player : Entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = .2f;


    [Header("Move info")]
    public float moveSpeed = 8f;
    public float jumpForce;
    public float swordReturnImpact;

    [Header("Dash info")]
    public float dashSpeed;
    public float dashDuration;
    public float dashDir;

    public bool isBusy {get; private set;}

    public SkillManager skill {get; private set;}
    public GameObject sword {get; private set;}

    #region States
    public PlayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState idleState {get; private set;}
    public PlayerMoveState moveState {get; private set;}
    public PlayerJumpState jumpState {get; private set;}
    public PlayerAirState airState {get; private set;}
    public PlayerWallSlideState wallSlideState {get; private set;}
    public PlayerWallJumpState wallJumpState {get; private set;}
    public PlayerDashState dashState {get; private set;}
    public PlayerPrimaryAttackState primaryAttack {get; private set;}
    public PlayerCounterAttackState counterAttack {get; private set;}
    public PlayerAimSwordState aimSwordState {get; private set;}
    public PlayerCatchSwordState catchSwordState {get; private set;}
    #endregion

    // 设置状态机和初始状态
    protected override void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        aimSwordState = new PlayerAimSwordState(this, stateMachine, "AimSword");
        catchSwordState = new PlayerCatchSwordState(this, stateMachine, "CatchSword");
    }

    // 状态机初始化
    protected override void Start()
    {
        base.Start();
        skill = SkillManager.instance;
        stateMachine.Initialize(idleState);
    }

    
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();
        
    }

    public void AssignNewSword(GameObject _newsword)
    {   
        sword = _newsword;
    }

    public void CatchTheSword()
    {
        stateMachine.ChangeState(catchSwordState);
        Destroy(sword);
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    // 冲刺检测
    public void CheckForDashInput()
    {

        // 在墙边无法冲刺
        if (ISWallDetected())
            return;
        
        if (Input.GetKeyDown(KeyCode.LeftShift) &&  SkillManager.instance.dash.CanUseSkill())
        {

            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
            {
                dashDir = facingDir;
            }
            stateMachine.ChangeState(dashState);
        }
    }

}
