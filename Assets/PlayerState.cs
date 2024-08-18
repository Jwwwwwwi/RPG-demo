using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 玩家状态基类，其余状态由此继承
public class PlayerState 
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    // 用于获取玩家对应的刚体简化代码
    protected Rigidbody2D rb;

    protected float stateTimer;
    protected float yInput;
    protected float xInput;
    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        // 设置动画参数获取玩家刚体
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;

    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);

    }
}
