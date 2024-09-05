using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// 敌人状态基类
public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;
    protected Rigidbody2D rb;

    private string animBoolname;

    protected float stateTimer;
    protected bool triggerCalled;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolname = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemy.rb;
        enemy.anim.SetBool(animBoolname, true);
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolname, false);
        enemy.AssignLastAnimBoolName(animBoolname);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
